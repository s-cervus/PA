using System;
using System.IO;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace PA
{
    public enum DbMode { Local, Server }

    public static class ControlUnit
    {
        // ========================================================
        // CONFIGURACIÓN Y ESTADOS DE SESIÓN GLOBALES
        // ========================================================
        public static DbMode CurrentMode { get; set; } = DbMode.Local; // Switch maestro

        public static string Uniq_ID { get; private set; } = "";
        public static string CurrentRole { get; private set; } = "";
        public static int IntentosFallidos { get; private set; } = 0;

        // Directorio exclusivo de tu sistema para evitar colisiones en la USB o disco
        private const string DirectorioBunker = "data_PDC7";
        private const string LocalConnectionString = @"Data Source=data_PDC7\login.db;Version=3;Foreign Keys=True;";
        private const string ServerConnectionString = @"Server=tu_servidor_vps;Database=EmpresaDB;Integrated Security=True;";

        private const string PEPPER = "Equipo█7";
        private const int _GOLD_HEARTH = 65537; // Constante mutante para Key Stretching
        private const string LOCK_SIGNATURE = "system_final_door_lock"; // Identificador DOM

        // ========================================================
        // CRIPTO DE BAJO NIVEL (BYTES PUROS)
        // ========================================================

        /// <summary>
        /// Genera una sal (Caramel) de 16 bytes crudos usando entropía criptográfica por hardware.
        /// </summary>
        private static byte[] _get_caramel()
        {
            byte[] buffer = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buffer);
            }
            return buffer;
        }

        /// <summary>
        /// Procesa la contraseña de forma paramétrica uniendo bloques Unicode nativos.
        /// Ejecuta 65,537 iteraciones de SHA256 y retorna un BLOB puro de 32 bytes.
        /// </summary>
        private static byte[] _get_data(string usuario, string password, byte[] caramel)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] userBytes = Encoding.Unicode.GetBytes(usuario);
                byte[] passBytes = Encoding.Unicode.GetBytes(password);
                byte[] pepperBytes = Encoding.Unicode.GetBytes(PEPPER);
                byte[] blockBytes = Encoding.Unicode.GetBytes("███████");

                int totalLength = blockBytes.Length * 2 + userBytes.Length + passBytes.Length + caramel.Length + pepperBytes.Length;
                byte[] srecipeBytes = new byte[totalLength];
                int offset = 0;

                Buffer.BlockCopy(blockBytes, 0, srecipeBytes, offset, blockBytes.Length); offset += blockBytes.Length;
                Buffer.BlockCopy(userBytes, 0, srecipeBytes, offset, userBytes.Length); offset += userBytes.Length;
                Buffer.BlockCopy(passBytes, 0, srecipeBytes, offset, passBytes.Length); offset += passBytes.Length;
                Buffer.BlockCopy(caramel, 0, srecipeBytes, offset, caramel.Length); offset += caramel.Length;
                Buffer.BlockCopy(pepperBytes, 0, srecipeBytes, offset, pepperBytes.Length); offset += pepperBytes.Length;
                Buffer.BlockCopy(blockBytes, 0, srecipeBytes, offset, blockBytes.Length);

                byte[] procBytes = srecipeBytes;
                for (int i = 0; i < _GOLD_HEARTH; i++)
                {
                    procBytes = sha256.ComputeHash(procBytes);
                }

                return procBytes;
            }
        }

        private static bool _compare_bytes(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length) return false;
            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i]; // XOR en tiempo constante para anular ataques de canal lateral (Timing Attacks)
            }
            return result == 0;
        }

        private static string _generate_uniq_id(string usuario)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] input = Encoding.Unicode.GetBytes(usuario.ToLower().Trim() + PEPPER);
                byte[] hash = sha256.ComputeHash(input);
                return BitConverter.ToString(hash).Replace("-", "").Substring(0, 16).ToLower();
            }
        }

        /// <summary>
        /// Capa de abstracción superior: Consulta dinámicamente la tabla cID 
        /// para resolver el rol en RAM sin usar condicionales rígidos.
        /// </summary>
        private static void _establecer_sesion(string usuario, int uid, SQLiteConnection conCompartida = null)
        {
            Uniq_ID = _generate_uniq_id(usuario);
            int rolId = uid / 100000; // Extrae el prefijo del rol (Ej: 100045 -> 1)

            if (CurrentMode == DbMode.Server)
            {
                // Fallback de seguridad si consultas el srv remoto.
                if (rolId == 1) CurrentRole = "SUPER_ADMIN";
                else if (rolId == 2) CurrentRole = "ADMIN_RW";
                else CurrentRole = "NORMAL_USER";
                return;
            }

            string query = "SELECT element FROM cID WHERE ID = @id LIMIT 1";

            // Reutilizamos la conexión activa del login para no reabrir el descriptor de archivo
            bool viajaConexionInterna = (conCompartida == null);
            SQLiteConnection con = viajaConexionInterna ? new SQLiteConnection(LocalConnectionString) : conCompartida;

            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", rolId);
                try
                {
                    if (viajaConexionInterna) con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        // Transformamos el valor de la tabla cID a mayúsculas para control de RAM
                        CurrentRole = result.ToString().ToUpper() + (rolId == 1 ? "_ADMIN" : (rolId == 5 || rolId == 2 ? "_RW" : "_RO"));
                    }
                    else
                    {
                        CurrentRole = "UNKNOWN_ROLE_DENIED";
                    }
                }
                catch
                {
                    CurrentRole = "GUEST_RESTRICTED";
                }
                finally
                {
                    if (viajaConexionInterna) con.Close();
                }
            }

            /* * ===================================================================
             * ⚠️ POLÍTICAS DE DENEGACIÓN
             * ===================================================================
             * Aqui van las políitcas de denegación
             * ===================================================================
             */
        }

        // ========================================================
        // GESTIÓN DEL SISTEMA DE CASTIGO ACUMULATIVO (DOM)
        // ========================================================

        public static bool IsLockedDown()
        {
            string query = "SELECT Lockdown FROM Login WHERE Username = @lockSig";
            using (SQLiteConnection con = new SQLiteConnection(LocalConnectionString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@lockSig", LOCK_SIGNATURE);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            long unixTimestampBaneo = Convert.ToInt64(result);
                            long unixTimeActual = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                            if (unixTimeActual < unixTimestampBaneo)
                            {
                                return true; // El escudo protector del DOM sigue activo
                            }
                            else
                            {
                                _limpiar_lockdown(con); // El castigo expiró, restauramos.
                            }
                        }
                    }
                    catch { return false; }
                }
            }
            return false;
        }

        public static void IncrementarOActivarLockdown()
        {
            long unixTimeActual = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            long nuevoBloqueoUnix;

            string queryBuscar = "SELECT Lockdown FROM Login WHERE Username = @lockSig";
            using (SQLiteConnection con = new SQLiteConnection(LocalConnectionString))
            {
                try
                {
                    con.Open();
                    object actualLock = null;
                    using (SQLiteCommand cmdBuscar = new SQLiteCommand(queryBuscar, con))
                    {
                        cmdBuscar.Parameters.AddWithValue("@lockSig", LOCK_SIGNATURE);
                        actualLock = cmdBuscar.ExecuteScalar();
                    }

                    if (actualLock != null && actualLock != DBNull.Value)
                    {
                        // LÓGICA ACUMULATIVA: Si intentas golpear la puerta estando en DOM, sumamos 1 hora (3600s) extra en caliente
                        long timestampActualDb = Convert.ToInt64(actualLock);
                        long baseCalculo = Math.Max(timestampActualDb, unixTimeActual);
                        nuevoBloqueoUnix = baseCalculo + 3600;
                    }
                    else
                    {
                        // Primer baneo por fallar 3 veces consecutivas
                        nuevoBloqueoUnix = unixTimeActual + 3600;
                    }

                    string queryUpsert = @"
                        INSERT INTO Login (Username, uID, Data, Caramel, Lockdown) 
                        VALUES (@sig, 0, x'00', x'00', @lockTime)
                        ON CONFLICT(Username) DO UPDATE SET Lockdown = @lockTime;";

                    using (SQLiteCommand cmdUpsert = new SQLiteCommand(queryUpsert, con))
                    {
                        cmdUpsert.Parameters.AddWithValue("@sig", LOCK_SIGNATURE);
                        cmdUpsert.Parameters.AddWithValue("@lockTime", nuevoBloqueoUnix);
                        cmdUpsert.ExecuteNonQuery();
                    }
                }
                catch { /* Manejo sigiloso ante colisión de hilos */ }
            }
            _establecer_sesion("nobody", 0, null); // Degradación instantánea de credenciales en RAM
        }

        private static void _limpiar_lockdown(SQLiteConnection con)
        {
            string query = "DELETE FROM Login WHERE Username = @lockSig";
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@lockSig", LOCK_SIGNATURE);
                cmd.ExecuteNonQuery();
                IntentosFallidos = 0; // Reseteamos la telemetría local de errores
            }
        }

        // ========================================================
        // INFRAESTRUCTURA DE REGISTRO SEGURO (Códigos: 1, 2, 3)
        // ========================================================

        public static int RegistrarUsuario(string username, string password, int uid)
        {
            if (IsLockedDown()) return 3; // Operación denegada por infraestructura bajo fuego DOM

            string userClean = username.ToLower().Trim();
            byte[] caramel = _get_caramel();
            byte[] dataBytes = _get_data(userClean, password, caramel);

            if (CurrentMode == DbMode.Local)
            {
                using (SQLiteConnection con = new SQLiteConnection(LocalConnectionString))
                {
                    string query = "INSERT INTO Login (Username, uID, Data, Caramel, Lockdown) VALUES (@user, @uid, @data, @caramel, NULL)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@user", userClean);
                        cmd.Parameters.AddWithValue("@uid", uid);
                        cmd.Parameters.Add("@data", DbType.Binary).Value = dataBytes;
                        cmd.Parameters.Add("@caramel", DbType.Binary).Value = caramel;

                        try
                        {
                            con.Open();
                            int ejecutado = cmd.ExecuteNonQuery();
                            return ejecutado > 0 ? 1 : 3;
                        }
                        catch (SQLiteException ex)
                        {
                            if (ex.ResultCode == SQLiteErrorCode.Constraint) return 2; // El Username o el uID violan la restricción UNIQUE
                            return 3;
                        }
                    }
                }
            }
            else
            {
                // Réplica en espejo para el srv corporativo
                using (SqlConnection con = new SqlConnection(ServerConnectionString))
                {
                    string query = "INSERT INTO Login (Username, uID, Data, Caramel, Lockdown) VALUES (@user, @uid, @data, @caramel, NULL)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@user", userClean);
                        cmd.Parameters.AddWithValue("@uid", uid);
                        cmd.Parameters.Add("@data", SqlDbType.VarBinary).Value = dataBytes;
                        cmd.Parameters.Add("@caramel", SqlDbType.VarBinary).Value = caramel;

                        try
                        {
                            con.Open();
                            int ejecutado = cmd.ExecuteNonQuery();
                            return ejecutado > 0 ? 1 : 3;
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627 || ex.Number == 2601) return 2; // Clave duplicada en SQL Server
                            return 3;
                        }
                    }
                }
            }
        }

        public static int AutoRegistrarEmpleado(string username, string password)
        {
            int nuevoUid = 300001; // El prefijo de rol es 3 (empleado)
            string queryMax = "SELECT MAX(uID) FROM Login WHERE uID >= 300000 AND uID < 400000";

            using (SQLiteConnection con = new SQLiteConnection(LocalConnectionString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(queryMax, con))
                {
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            nuevoUid = Convert.ToInt32(result) + 1; // Generación secuencial automática
                        }
                    }
                    catch { }
                }
            }
            return RegistrarUsuario(username, password, nuevoUid);
        }

        // ========================================================
        // AUTENTICACIÓN DIRECTA E INSTANTÁNEA
        // ========================================================

        public static bool ValidarYMutarLogin(string usuario, string password)
        {
            if (IsLockedDown())
            {
                IncrementarOActivarLockdown(); // Castigo por intentar vulnerar el sistema congelado
                return false;
            }

            string userClean = usuario.ToLower().Trim();

            if (CurrentMode == DbMode.Local)
            {
                // Traemos una única fila específica eliminando los escaneos lineales costosos
                string query = "SELECT uID, Data, Caramel FROM Login WHERE Username = @user";
                using (SQLiteConnection con = new SQLiteConnection(LocalConnectionString))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@user", userClean);
                        try
                        {
                            con.Open();
                            using (SQLiteDataReader lector = cmd.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    int uidDb = Convert.ToInt32(lector["uID"]);
                                    byte[] dataDb = (byte[])lector["Data"];
                                    byte[] caramelDb = (byte[])lector["Caramel"];

                                    byte[] hashIntento = _get_data(userClean, password, caramelDb);

                                    if (_compare_bytes(hashIntento, dataDb))
                                    {
                                        lector.Close();
                                        IntentosFallidos = 0; // Limpiamos el contador

                                        // Resolvemos la sesión inyectando la conexión compartida para máxima velocidad
                                        _establecer_sesion(userClean, uidDb, con);

                                        // Destruimos el Caramel previo forzando la mutación criptográfica instantánea
                                        _mutar_caramel_local(con, userClean, password);
                                        return true;
                                    }
                                }
                            }
                        }
                        catch { return false; }
                    }
                }
            }
            else
            {
                // Autenticación remota
                string query = "SELECT uID, Data, Caramel FROM Login WHERE Username = @user";
                using (SqlConnection con = new SqlConnection(ServerConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@user", userClean);
                        try
                        {
                            con.Open();
                            using (SqlDataReader lector = cmd.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    int uidDb = Convert.ToInt32(lector["uID"]);
                                    byte[] dataDb = (byte[])lector["Data"];
                                    byte[] caramelDb = (byte[])lector["Caramel"];

                                    byte[] hashIntento = _get_data(userClean, password, caramelDb);

                                    if (_compare_bytes(hashIntento, dataDb))
                                    {
                                        lector.Close();
                                        IntentosFallidos = 0;
                                        _establecer_sesion(userClean, uidDb, null);
                                        _mutar_caramel_server(con, userClean, password);
                                        return true;
                                    }
                                }
                            }
                        }
                        catch { return false; }
                    }
                }
            }

            // Si la ejecución llega a este punto, las credenciales fallaron
            IntentosFallidos++;
            if (IntentosFallidos >= 3)
            {
                IncrementarOActivarLockdown(); // Detonación automática del DOM
            }
            return false;
        }

        private static void _mutar_caramel_local(SQLiteConnection con, string user, string pass)
        {
            byte[] nuevoCaramel = _get_caramel();
            byte[] nuevoData = _get_data(user, pass, nuevoCaramel);

            string query = "UPDATE Login SET Data = @nd, Caramel = @nc WHERE Username = @user";
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.Add("@nd", DbType.Binary).Value = nuevoData;
                cmd.Parameters.Add("@nc", DbType.Binary).Value = nuevoCaramel;
                cmd.Parameters.AddWithValue("@user", user);
                cmd.ExecuteNonQuery();
            }
        }

        private static void _mutar_caramel_server(SqlConnection con, string user, string pass)
        {
            byte[] nuevoCaramel = _get_caramel();
            byte[] nuevoData = _get_data(user, pass, nuevoCaramel);

            string query = "UPDATE Login SET Data = @nd, Caramel = @nc WHERE Username = @user";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@nd", SqlDbType.VarBinary).Value = nuevoData;
                cmd.Parameters.Add("@nc", SqlDbType.VarBinary).Value = nuevoCaramel;
                cmd.Parameters.AddWithValue("@user", user);
                cmd.ExecuteNonQuery();
            }
        }

        // ========================================================
        // SECCIÓN DE INICIALIZACIÓN
        // ========================================================

        public static void InicializarEntornoLocal()
        {
            // Forzar la creación de la carpeta de datos PDC7
            if (!Directory.Exists(DirectorioBunker))
            {
                Directory.CreateDirectory(DirectorioBunker);
            }

            string rutaArchivo = Path.Combine(DirectorioBunker, "login.db");
            bool recienCreado = !File.Exists(rutaArchivo);

            using (SQLiteConnection con = new SQLiteConnection(LocalConnectionString))
            {
                con.Open();

                if (recienCreado)
                {
                    // Tabla Login adaptada al estándar STRICT binario puro
                    string tablaLogin = @"
                        CREATE TABLE ""Login"" (
                            ""Username"" TEXT UNIQUE,
                            ""uID""      INTEGER NOT NULL UNIQUE,
                            ""Data""     BLOB NOT NULL,
                            ""Caramel""  BLOB NOT NULL,
                            ""Lockdown"" INTEGER,
                            PRIMARY KEY(""Username"")
                        ) STRICT;";

                    // Tabla cID con llave compuesta para control estricto de roles
                    string tablaCID = @"
                        CREATE TABLE ""cID"" (
                            ""ID""      INTEGER,
                            ""element"" TEXT,
                            PRIMARY KEY(""ID"", ""element"")
                        );";

                    using (SQLiteCommand cmd = new SQLiteCommand(tablaLogin, con)) cmd.ExecuteNonQuery();
                    using (SQLiteCommand cmd = new SQLiteCommand(tablaCID, con)) cmd.ExecuteNonQuery();

                    // Alimentamos la abstracción de roles
                    string insertarCat = @"
                        INSERT INTO cID (ID, element) VALUES 
                        (0, 'DOM'),
                        (1, 'super'),
                        (2, 'admin'),
                        (3, 'empleado'),
                        (4, 'auditor'),
                        (5, 'ajustes');";

                    using (SQLiteCommand cmdCat = new SQLiteCommand(insertarCat, con)) cmdCat.ExecuteNonQuery();

                    // Cuentas de desarrollo iniciales empaquetadas (Formato uID: [Rango][Secuencia])
                    _registrar_init_local(con, "super", "super7", 100001);
                    _registrar_init_local(con, "gerente_admin", "admin123", 200001);
                    _registrar_init_local(con, "cajero_push", "push99", 300001);
                    _registrar_init_local(con, "sat_auditor", "readonly", 400001);
                    _registrar_init_local(con, "conta_ajustes", "rw_conta", 500001);
                }
            }

            // ========================================================
            // EXTRACCIÓN AUTOMÁTICA DE PLANTILLAS EXTRA DESDE .RESX
            // ========================================================
            // Aquí es donde el ControlUnit crea la carpeta data_PDC7
            // inyectando los archivos vacíos de las otras bases contables desde tus recursos internos:
            /*
            string rutaProductos = Path.Combine(DirectorioBunker, "store.db");
            if (!File.Exists(rutaProductos))
            {
                File.WriteAllBytes(rutaProductos, Properties.Resources.store_template_db);
            }
            */
        }

        private static void _registrar_init_local(SQLiteConnection con, string user, string pass, int uid)
        {
            byte[] caramel = _get_caramel();
            byte[] data = _get_data(user, pass, caramel);
            string query = "INSERT INTO Login (Username, uID, Data, Caramel, Lockdown) VALUES (@user, @uid, @data, @caramel, NULL)";
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.Add("@data", DbType.Binary).Value = data;
                cmd.Parameters.Add("@caramel", DbType.Binary).Value = caramel;
                cmd.ExecuteNonQuery();
            }
        }

        internal static void flaged_screen()
        {
            throw new NotImplementedException();
        }
    }
}





/*
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace PA
{
    public enum DbMode { Local, Server }

    // Considero que el uID se debe manejar en base a otra db que diga que rol pertenece, eso agrega una capa de abstracion, en ves de un switch,
    // en este caso la tabla permanece solo RO y solo se consulta el rol, en si solo seleccionamos el rol segun la tabla, ve si hay agujeros de
    // codigo codigo como el que vimos de ayer de que se ponia a calcular la contraseña con cada caramelo. Otra cosa esw que cuando haga :
    // SELECT Usernamer, uID, Data, Caramel, LockdownD FROM Login WHERE Data != @lockSig seleccione toda la fila para evitar lo de calcular cada hash
    // Si hay inicio en modo local, la funcion debe crear los trabajos, la base si la generamos ante codigo(LocalLogin.db), las otras bases como las de productos y asi
    // las agregaremos mediante archivos de la .resx que extraeremos de el codigo tipo las que usaremos, Las demas clases ovbiamente se encargan de manejar los datos,
    // pero nosotros solo les damos el archivo si es el caso local, basicamente el control unit tiene que darse esa molestia de mas paara generar la carpeta de data,
    // dentro del mismo directorio, aunque le vamos a cambiar el nombre a esa carpeta ya que el usuario puede tener una como esa, la carpeta se llamara data_PDC7, ahi
    //  vamos a soltar los archivos de las otras data bases.
    // asegurate de cambiar este valor:
    // private const string LocalConnectionString = @"Data Source=Data\login.db;Version=3;Foreign Keys=True;";
    public static class ControlUnit
    {
        // ========================================================
        // 🎛️ CONFIGURACIÓN Y ESTADOS DE SESIÓN GLOBALES
        // ========================================================
        public static DbMode CurrentMode { get; set; } = DbMode.Local; // Switch maestro maestro

        public static string Uniq_ID { get; private set; } = "";
        public static string CurrentRole { get; private set; } = "";

        // Ubicación soberana aislada de las librerías del %TEMP%
        private const string LocalConnectionString = @"Data Source=Data\login.db;Version=3;";
        private const string ServerConnectionString = @"Server=tu_servidor_vps;Database=EmpresaDB;Integrated Security=True;";

        private const string PEPPER = "Equipo█7";
        private const int _GOLD_HEARTH = 65537; // Constante mutante de Fermat
        private const string LOCK_SIGNATURE = "system_final_door_lock"; // Fila fantasma

        // ========================================================
        // 🛠️ FONTANERÍA CRIPTOGRÁFICA PRIVADA
        // ========================================================

        private static string _get_caramel()
        {
            byte[] buffer = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buffer); // Entropía pura por hardware
            }
            return BitConverter.ToString(buffer).Replace("-", "").ToLower();
        }

        private static byte[] _get_data(string usuario, string password, string caramel)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // "THE SECRET RECIPE" con el aislamiento estricto de ruido
                string srecipe = "███████" + usuario + password + caramel + PEPPER + "███████";
                byte[] procBytes = Encoding.Unicode.GetBytes(srecipe); // UTF-16 Nativo

                // Key Stretching de alta densidad
                for (int i = 0; i < _GOLD_HEARTH; i++)
                {
                    procBytes = sha256.ComputeHash(procBytes);
                }
                return procBytes;
            }
        }

        private static bool _compare_bytes(byte[] a, byte[] b)
        {
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }

        private static string _generate_uniq_id(string usuario)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] input = Encoding.Unicode.GetBytes(usuario.ToLower().Trim() + PEPPER);
                byte[] hash = sha256.ComputeHash(input);
                return BitConverter.ToString(hash).Replace("-", "").Substring(0, 16).ToLower();
            }
        }

        private static void _establecer_sesion(string usuario, int uid)
        {
            Uniq_ID = _generate_uniq_id(usuario);

            // Mapeo veloz en RAM basado en tu jerarquía de rangos numéricos (uID)
            switch (uid)
            {
                case 1:
                    CurrentRole = "SUPER_ADMIN";         // El Dios del sistema
                    break;
                case 2:
                    CurrentRole = "VENTAS_CLIENT";       // Vendedor común (Push-only)
                    break;
                case 3:
                    CurrentRole = "AJUSTES_RW";          // Contabilidad Escritura
                    break;
                case 4:
                    CurrentRole = "AUDITOR_CONTABLE";    // Auditor de Solo Lectura
                    break;
                case 5:
                    CurrentRole = "COMPRAS_OPERATOR";    // Operario de mercancías
                    break;
                case 6:
                    CurrentRole = "TESTER";              // Entorno de depuración
                    break;
                case 0:
                    CurrentRole = "TERMINATED_BY_SECURITY"; // Baneo/Infracción activa
                    break;
                default:
                    CurrentRole = "NORMAL_USER";         // Cuentas comunes sin privilegios
                    break;
            }
        }

        // Ajuste complementario: Ahora busca y destruye usando la llave primaria binaria
        private static void _force_mutation(SQLiteConnection conexion, byte[] hashViejo, string usuario, string password)
        {
            string nuevoCaramel = _get_caramel();
            byte[] nuevoDataHash = _get_data(usuario, password, nuevoCaramel);

            string updateQuery = "UPDATE Login SET Data = @nuevoData, Caramel = @nuevoCaramel WHERE Data = @hashViejo";

            using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conexion))
            {
                updateCmd.Parameters.Add("@nuevoData", DbType.Binary).Value = nuevoDataHash;
                updateCmd.Parameters.AddWithValue("@nuevoCaramel", nuevoCaramel);
                updateCmd.Parameters.Add("@hashViejo", DbType.Binary).Value = hashViejo;

                updateCmd.ExecuteNonQuery();
            }
        }


        // ========================================================
        // 🔒 SISTEMA DE PREVENCIÓN ACTIVA (FinalDoor BLOB 1 Hora)
        // ========================================================

        

        public static bool IsLockedDown()
        {
            string query = "SELECT Lockdown FROM Login WHERE Username = @lockSig";
            using (SQLiteConnection con = new SQLiteConnection(LocalConnectionString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@lockSig", LOCK_SIGNATURE);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            long unixTimestampBaneo = Convert.ToInt64(result);
                            long unixTimeActual = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                            if (unixTimeActual < unixTimestampBaneo)
                            {
                                return true; // El baneo de 1 hora sigue vigente
                            }
                            else
                            {
                                // El tiempo expiró, limpiamos la fila de control
                                _limpiar_final_door(con);
                            }
                        }
                    }
                    catch { return false; }
                }
            }
            return false;
        }

        public static void ActivarFinalDoor()
            //Ajusta a segundoa, de momento lo haremos con el reloj de sistema
        {
            // Calculamos el tiempo actual en segundos Unix y le sumamos 3600 segundos (1 hora)
            long tiempoExpiracionUnix = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds();

            string query = @"
        INSERT INTO Login (Username, Data, Caramel, uID, Lockdown) 
        VALUES (@sig, x'00', x'00', 0, @lockTime)
        ON CONFLICT(Username) DO UPDATE SET Lockdown = @lockTime;";

            using (SQLiteConnection con = new SQLiteConnection(LocalConnectionString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@sig", LOCK_SIGNATURE);
                    cmd.Parameters.AddWithValue("@lockTime", tiempoExpiracionUnix);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch { }// Colapso controlado
                }
            }
            _establecer_sesion("nobody", 0); // Forzar rango infracción en RAM
        }


        private static void _limpiar_final_door(SQLiteConnection con)
        {
            string query = "DELETE FROM Login WHERE Data = @sig";
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@sig", LOCK_SIGNATURE);
                cmd.ExecuteNonQuery();
            }
        }

        // ========================================================
        // 🌐 INTERFAZ GESTIONADA PÚBLICA (Lógica de los Forms)
        // ========================================================

        public static void InicializarEntornoLocal()
        {
            string rutaArchivo = Path.Combine("Data", "login.db");

            if (!File.Exists(rutaArchivo))
            {
                // Creamos el archivo dentro de tu directorio ./Data dedicado
                using (SQLiteConnection conexion = new SQLiteConnection(LocalConnectionString))
                {
                    conexion.Open();

                    // Tu nueva tabla robusta con uID numérico y celda BLOB binaria para Lockdown
                    string scriptTabla = @"
                        CREATE TABLE ""Login"" (
                            ""Data"" TEXT COLLATE UTF16,
                            ""Caramel"" TEXT COLLATE UTF16,
                            ""uID"" INTEGER,
                            ""Lockdown"" BLOB,
                            PRIMARY KEY(""Data"")
                        ) STRICT;";

                    using (SQLiteCommand comando = new SQLiteCommand(scriptTabla, conexion))
                    {
                        comando.ExecuteNonQuery();
                    }
                }

                // Inyección del catálogo maestro de credenciales iniciales por uID
                _registrar_local_directo_init("super", "admin7", 1);       // Super
                _registrar_local_directo_init("ventas", "vende123", 2);    // VentasClient
                _registrar_local_directo_init("ajustes", "conta_rw", 3);   // Ajustes RW
                _registrar_local_directo_init("auditor", "conta_ro", 4);   // Auditor RO
                _registrar_local_directo_init("compras", "prov99", 5);     // Mercancías
                _registrar_local_directo_init("test", "1234", 999);          // Tester

                // Los uID se estructuraran de una manera similar a 8 bits o 16 bits, para que la memoria se sienta familiarizada con esta estructura
                // uID: primero va el rol, rol de 3 numeros; ejemplo: [999]+[numero unico] = uID
            }
        }

        private static void _registrar_local_directo_init(string usuario, string password, int uid)
        {
            string caramel = _get_caramel();
            byte[] dataBytes = _get_data(usuario, password, caramel); // Ahora es byte[]

            using (SQLiteConnection conexion = new SQLiteConnection(LocalConnectionString))
            {
                string query = "INSERT INTO Login (Data, Caramel, uID, Lockdown) VALUES (@data, @caramel, @uid, NULL)";
                using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                {
                    // Ammaramos el parámetro como Binario Estricto
                    comando.Parameters.Add("@data", DbType.Binary).Value = dataBytes;
                    comando.Parameters.AddWithValue("@caramel", caramel);
                    comando.Parameters.AddWithValue("@uid", uid); // Tu nuevo formato numérico

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Registra una nueva cuenta en caliente respetando el estándar criptográfico y de rangos.
        /// </summary>
        public static bool RegistrarUsuario(string usuario, string password, int uid)
        {
            if (IsLockedDown()) return false;

            string caramel = _get_caramel();
            byte[] dataBytes = _get_data(usuario, password, caramel);

            using (SQLiteConnection conexion = new SQLiteConnection(LocalConnectionString))
            {
                string query = "INSERT INTO Login (Data, Caramel, uID, Lockdown) VALUES (@data, @caramel, @uid, NULL)";
                using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                {
                    comando.Parameters.Add("@data", DbType.Binary).Value = dataBytes;
                    comando.Parameters.AddWithValue("@caramel", caramel);
                    comando.Parameters.AddWithValue("@uid", uid);

                    try
                    {
                        conexion.Open();
                        return comando.ExecuteNonQuery() > 0;
                    }
                    catch (SQLiteException)
                    {
                        throw new Exception("Violación de integridad: El registro de este usuario ya existe.");
                    }
                }
            }
        }

        public static bool ValidarYMutarLogin(string usuario, string password)
        {
            if (IsLockedDown())
            {
                throw new UnauthorizedAccessException("INFRAESTRUCTURA LOCK-END. Terminal congelada temporalmente.");
            }

            if (CurrentMode == DbMode.Server)
            {
                return _check_login_server(usuario, password);
            }
            else
            {
                return _validar_login_local(usuario, password);
            }
        }

        private static bool _validar_login_local(string usuario, string password)
        {
            string query = "SELECT Data, Caramel, uID FROM Login WHERE Data != @lockSig";

            using (SQLiteConnection conexion = new SQLiteConnection(LocalConnectionString))
            {
                using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                {
                    // Convertimos el texto del candado a bytes para mantener la coherencia del BLOB
                    byte[] lockBytes = Encoding.UTF8.GetBytes(LOCK_SIGNATURE);
                    comando.Parameters.Add("@lockSig", DbType.Binary).Value = lockBytes;

                    try
                    {
                        conexion.Open();
                        using (SQLiteDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                // Succionamos el bloque de memoria crudo del registro
                                byte[] dataEnDB = (byte[])lector["Data"];
                                string caramelEnDB = lector["Caramel"].ToString();
                                int uidEnDB = Convert.ToInt32(lector["uID"]);

                                byte[] hashIntento = _get_data(usuario, password, caramelEnDB);

                                // Comparación binaria a bajo nivel
                                if (_compare_bytes(hashIntento, dataEnDB))
                                {
                                    lector.Close();

                                    _establecer_sesion(usuario, uidEnDB);

                                    // Pasamos el array de bytes para ejecutar la trituradora
                                    _force_mutation(conexion, dataEnDB, usuario, password);
                                    return true;
                                }
                            }
                        }
                    }
                    catch { return false; }
                }
            }
            return false;
        }

        private static bool _check_login_server(string user, string passwd)
        {
            string query = "SELECT uID FROM UsuariosCentral WHERE UserID = @id AND PassHash = @pass";

            string userIdServer = _generate_uniq_id(user);
            byte[] passHashServer = _get_data(user, passwd, "ServerSaltStatic"); // Cambiado a byte[]

            using (SqlConnection connection = new SqlConnection(ServerConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", userIdServer);
                    // SqlClient inyecta el array de bytes directo a las celdas binarias de SQL Server
                    command.Parameters.AddWithValue("@pass", passHashServer);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int uidServer = Convert.ToInt32(result);
                            _establecer_sesion(user, uidServer);
                            return true;
                        }
                    }
                    catch { return false; }
                }
            }
            return false;
        }

        public static void PushRegistrosAlServidor()/// Esta funcion hay que checarla ya que de momento no se usa, asi que sera futuramente esta
        {
            if (CurrentRole != "SUPER_ADMIN")
            {
                throw new UnauthorizedAccessException("Acceso denegado. Operación restringida a la Consola Suprema.");
            }

            using (SQLiteConnection conLocal = new SQLiteConnection(LocalConnectionString))
            using (SqlConnection conServer = new SqlConnection(ServerConnectionString))
            {
                string queryLocal = "SELECT Data, Caramel, uID FROM Login WHERE Data != @lockSig";
                string queryServer = @"INSERT INTO HistorialPush (DataRespaldada, CaramelRespaldado, uIDRespaldado, FechaPush, SincronizadoPor) 
                                       VALUES (@d, @c, @u, GETDATE(), @by)";

                using (SQLiteCommand cmdLocal = new SQLiteCommand(queryLocal, conLocal))
                {
                    cmdLocal.Parameters.AddWithValue("@lockSig", LOCK_SIGNATURE);
                    try
                    {
                        conLocal.Open();
                        conServer.Open();

                        using (SQLiteDataReader lector = cmdLocal.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                using (SqlCommand cmdServer = new SqlCommand(queryServer, conServer))
                                {
                                    cmdServer.Parameters.AddWithValue("@d", lector["Data"].ToString());
                                    cmdServer.Parameters.AddWithValue("@c", lector["Caramel"].ToString());
                                    cmdServer.Parameters.AddWithValue("@u", Convert.ToInt32(lector["uID"]));
                                    cmdServer.Parameters.AddWithValue("@by", Uniq_ID);

                                    cmdServer.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Fallo en el transporte del Push corporativo: " + ex.Message);
                    }
                }
            }
        }
    }
}
*/
// ============================

/*
public static void ActivarFinalDoor0()
{
    // Modificado a baneo estricto de 1 hora
    string tiempoExpiracion = DateTime.Now.AddHours(1).ToString("o");
    byte[] lockdownBytes = Encoding.UTF8.GetBytes(tiempoExpiracion); // Conversión a modo byte pura

    string query = @"
        INSERT INTO Login (Data, Caramel, uID, Lockdown) VALUES (@sig, '', 0, @lockData)
        ON CONFLICT(Data) DO UPDATE SET Lockdown = @lockData;";

    using (SQLiteConnection con = new SQLiteConnection(LocalConnectionString))
    {
        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@sig", LOCK_SIGNATURE);
            cmd.Parameters.AddWithValue("@lockData", lockdownBytes);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch {} // Colapso controlado
        }
    }
    _establecer_sesion("nobody", 0); // Forzar rango 0 (Infracción) en RAM de inmediato
}

public static bool IsLockedDown0()
{
    string query = "SELECT Lockdown FROM Login WHERE Data = @lockSig";
    using (SQLiteConnection con = new SQLiteConnection(LocalConnectionString))
    {
        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@lockSig", LOCK_SIGNATURE);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    byte[] blob = (byte[])result;
                    if (blob.Length > 0)
                    {
                        // Reconstruimos el string ISO guardado en las celdas del BLOB
                        string timestamp = Encoding.UTF8.GetString(blob);
                        DateTime tiempoBloqueo = DateTime.Parse(timestamp);

                        if (DateTime.Now < tiempoBloqueo)
                        {
                            return true; // El baneo de 1 hora sigue corriendo
                        }
                        else
                        {
                            _limpiar_final_door(con); // Tiempo cumplido, se levanta el castigo
                        }
                    }
                }
            }
            catch { return false; }
        }
    }
    return false;
}







*/


















/*
namespace PA
{
    public enum DbMode { Local, Server }

    public static class ControlUnit
    {
        // ========================================================
        // CONFIGURACIÓN Y ESTADOS DE SESIÓN GLOBALES
        // ========================================================
        public static DbMode CurrentMode { get; set; } = DbMode.Local; // Switch maestro

        // Sesión activa (Accesible desde cualquier Form para bloquear componentes)
        public static string Uniq_ID { get; private set; } = "";
        public static string CurrentRole { get; private set; } = "";

        private const string LocalConnectionString = "Data Source=local.db;Version=3;";
        private const string ServerConnectionString = @"Server=tu_servidor_vps;Database=EmpresaDB;Integrated Security=True;";
        private const string PEPPER = "Equipo█7";
        private const int _GOLD_HEARTH = 65537;

        // ========================================================
        // Func Priv------------
        // ========================================================

        private static string _get_caramel()
        {
            byte[] buffer = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buffer); // Criptografía por hardware
            }
            return BitConverter.ToString(buffer).Replace("-", "").ToLower();
        }


        private static string _get_data(string usuario, string password, string caramel)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // "THE SECRET RECIPE"
                string srecipe = "███████" + usuario + password + caramel + PEPPER + "███████";

                byte[] procBytes = Encoding.Unicode.GetBytes(srecipe); // UTF-16 Nativo
                
                // Estirar el dulce hasta quedar irreconocible :)
                for (int i = 0; i < _GOLD_HEARTH ; i++)
                {
                    procBytes = sha256.ComputeHash(procBytes);
                }
                
                return BitConverter.ToString(procBytes).Replace("-", "").ToLower();
            }
            

        }

        private static string _generate_uniq_id(string usuario)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] input = Encoding.Unicode.GetBytes(usuario.ToLower().Trim() + PEPPER);
                byte[] hash = sha256.ComputeHash(input);
                return BitConverter.ToString(hash).Replace("-", "").Substring(0, 16).ToLower(); // Token de 16 caracteres
            }
        }
        private static void _establecer_sesion(string usuario)
        {
            Uniq_ID = _generate_uniq_id(usuario);
            string userLower = usuario.ToLower().Trim();

            if (userLower == "super") CurrentRole = "SUPER_ADMIN";
            else if (userLower == "auditor") CurrentRole = "AUDITOR_CONTABLE";
            else if (userLower == "test") CurrentRole = "TESTER";
            else CurrentRole = "NORMAL_USER";
        }


        private static void _force_mutation(SQLiteConnection conexion, string hashViejo, string usuario, string password)
        {
            string nuevoCaramel = _get_caramel();
            string nuevoDataHash = _get_data(usuario, password, nuevoCaramel);

            string updateQuery = "UPDATE Login SET Data = @nuevoData, Caramel = @nuevoCaramel WHERE Data = @hashViejo";

            using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conexion))
            {
                updateCmd.Parameters.AddWithValue("@nuevoData", nuevoDataHash);
                updateCmd.Parameters.AddWithValue("@nuevoCaramel", nuevoCaramel);
                updateCmd.Parameters.AddWithValue("@hashViejo", hashViejo);

                updateCmd.ExecuteNonQuery();
            }
        }


        // ========================================================
        // INTERFAZ PÚBLICA
        // ========================================================

        public static void InicializarEntornoLocal()
        {
            string archivoDb = "local.db";

            // Si la base de datos no existe, el programa la pare en caliente
            if (!File.Exists(archivoDb))
            {
                SQLiteConnection.CreateFile(archivoDb);

                using (SQLiteConnection conexion = new SQLiteConnection(LocalConnectionString))
                {
                    conexion.Open();

                    // Creamos tu tabla con modo STRICT y UTF16
                    string scriptTabla = @"
                        CREATE TABLE ""Login"" (
                            ""Data"" TEXT COLLATE UTF16 PRIMARY KEY,
                            ""Caramel"" TEXT COLLATE UTF16
                        ) STRICT;";

                    using (SQLiteCommand comando = new SQLiteCommand(scriptTabla, conexion))
                    {
                        comando.ExecuteNonQuery();
                    }
                }

                // Inyectamos los usuarios experimentales por defecto para la escuela
                // Las contraseñas quedan trituradas inmediatamente con sus propios salts mutantes
                _registrar_local_directo("super", "admin7");
                _registrar_local_directo("test", "1234");
                _registrar_local_directo("auditor", "conta2026");
            }
        }

        private static void _registrar_local_directo(string usuario, string password)
        {
            string caramel = _get_caramel();
            string dataHash = _get_data(usuario, password, caramel);

            using (SQLiteConnection conexion = new SQLiteConnection(LocalConnectionString))
            {
                string query = "INSERT INTO Login (Data, Caramel) VALUES (@data, @caramel)";
                using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@data", dataHash);
                    comando.Parameters.AddWithValue("@caramel", caramel);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        // ========================================================
        // 🌐 INTERFAZ PÚBLICA DE CONTROL (Métodos del Form)
        // ========================================================

        public static bool ValidarYMutarLogin(string usuario, string password)
        {
            InicializarEntornoLocal();
            if (CurrentMode == DbMode.Server)
            {
                return _validar_login_server(usuario, password);
            }
            else
            {
                return _validar_login_local(usuario, password);
            }
        }

        private static bool _validar_login_local(string usuario, string password)
        {
            string query = "SELECT Data, Caramel FROM Login";
            using (SQLiteConnection conexion = new SQLiteConnection(LocalConnectionString))
            {
                using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                {
                    try
                    {
                        conexion.Open();
                        using (SQLiteDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                string dataEnDB = lector["Data"].ToString();
                                string caramelEnDB = lector["Caramel"].ToString();

                                if (_get_data(usuario, password, caramelEnDB) == dataEnDB)
                                {
                                    lector.Close();
                                    
                                    // Activamos las credenciales y el Uniq_ID en RAM
                                    _establecer_sesion(usuario);

                                    // Mutamos el Caramel para volver basura el estado anterior
                                    string nuevoCaramel = _get_caramel();
                                    string nuevoDataHash = _get_data(usuario, password, nuevoCaramel);
                                    
                                    string update = "UPDATE Login SET Data = @nd, Caramel = @nc WHERE Data = @hv";
                                    using (SQLiteCommand upCmd = new SQLiteCommand(update, conexion))
                                    {
                                        upCmd.Parameters.AddWithValue("@nd", nuevoDataHash);
                                        upCmd.Parameters.AddWithValue("@nc", nuevoCaramel);
                                        upCmd.Parameters.AddWithValue("@hv", dataEnDB);
                                        upCmd.ExecuteNonQuery();
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                    catch { return false; }
                }
            }
            return false;
        }

        private static bool _validar_login_server(string usuario, string password)
        {
            // CONTROL INTERNO EMPRESARIAL: En servidor no dependemos de variables del cliente.
            // Mandamos los hashes parametrizados directamente al motor central.
            string query = "SELECT COUNT(1) FROM UsuariosCentral WHERE UserID = @id AND PassHash = @pass";
            
            string userIdServer = _generate_uniq_id(usuario);
            // El servidor usa una sal fija del sistema o un esquema robusto centralizado
            string passHashServer = _get_data(usuario, password, "ServerSaltStatic"); 

            using (SqlConnection conexion = new SqlConnection(ServerConnectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", userIdServer);
                    comando.Parameters.AddWithValue("@pass", passHashServer);

                    try
                    {
                        conexion.Open();
                        int num = Convert.ToInt32(comando.ExecuteScalar());
                        if (num == 1)
                        {
                            _establecer_sesion(usuario);
                            return true;
                        }
                    }
                    catch { return false; }
                }
            }
            return false;
        }

        // ========================================================
        // CONTROL COMPLIANCE: PUSH DE REGISTROS (NO PULL)
        // ========================================================
        public static void PushRegistrosAlServidor()
        {
            // Solo se permite ejecutar el Push si eres el SuperUsuario
            if (CurrentRole != "SUPER_ADMIN")
            {
                throw new UnauthorizedAccessException("Acceso denegado. Solo la consola suprema puede empujar auditorías.");
            }

            // Flujo seguro: Leemos local, inyectamos en remoto. Jamás al revés.
            using (SQLiteConnection conLocal = new SQLiteConnection(LocalConnectionString))
            using (SqlConnection conServer = new SqlConnection(ServerConnectionString))
            {
                string queryLocal = "SELECT Data, Caramel FROM Login";
                string queryServer = "INSERT INTO HistorialPush (DataRespaldada, CaramelRespaldado, FechaPush, SincronizadoPor) VALUES (@d, @c, GETDATE(), @by)";

                using (SQLiteCommand cmdLocal = new SQLiteCommand(queryLocal, conLocal))
                {
                    conLocal.Open();
                    conServer.Open();

                    using (SQLiteDataReader lector = cmdLocal.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            using (SqlCommand cmdServer = new SqlCommand(queryServer, conServer))
                            {
                                cmdServer.Parameters.AddWithValue("@d", lector["Data"].ToString());
                                cmdServer.Parameters.AddWithValue("@c", lector["Caramel"].ToString());
                                cmdServer.Parameters.AddWithValue("@by", Uniq_ID); // Firmado con el token
                                
                                cmdServer.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    }
}

        public static bool RegUserPW(string usuario, string password)
        {
            string caramel = _get_caramel();
            string dataHash = _get_data(usuario, password, caramel);

            string query = "INSERT INTO Login (Data, Caramel) VALUES (@data, @caramel)";

            using (SQLiteConnection conexion = new SQLiteConnection(ConnectionString))
            {
                using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@data", dataHash);
                    comando.Parameters.AddWithValue("@caramel", caramel);

                    try
                    {
                        conexion.Open();
                        return comando.ExecuteNonQuery() > 0;
                    }
                    catch (SQLiteException)
                    {
                        throw new Exception("Error: El identificador ya existe.");
                    }
                }
            }
        }

        public static bool CheckLogin(string usuario, string password)
        {
            // Escaneo sigiloso en la RAM del servidor local
            string query = "SELECT Data, Caramel FROM Login";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                using (SQLiteCommand comando = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string dataEnDB = reader["Data"].ToString();
                                string caramelEnDB = reader["Caramel"].ToString();

                                // Replicamos la fórmula usando el micro-getter privado
                                string hashIntento = _get_data(usuario, password, caramelEnDB);

                                // Si la matemática coincide, el usuario es legítimo
                                if (hashIntento == dataEnDB)
                                {
                                    reader.Close(); // Rompemos el candado de lectura

                                    // Mutamos el estado en caliente para volverlo basura
                                    _force_mutation(connection, dataEnDB, usuario, password);

                                    return true;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return false; // Denegado ante cualquier fallo físico
                    }
                }
            }
            return false; // No hubo coincidencia

*/