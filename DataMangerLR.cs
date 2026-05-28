using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SQLite;



namespace PA
{
    public static class DataManagerLR
    {
        // Configuración Maestra del Sistema
        private const string ConnectionString = "Data Source=local.db;Version=3;";
        private const string PEPPER = "Equipo 7";

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
                // Tu receta exacta: Usuario + Passwd + Caramel + Sazón del Equipo 7
                string cadenaCruda = usuario + password + caramel + PEPPER;

                byte[] inputBytes = Encoding.Unicode.GetBytes(cadenaCruda); // UTF-16 Nativo
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
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

        public static bool RegistrarUsuario(string usuario, string password)
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
                        throw new Exception("Error de infraestructura: El identificador ya existe.");
                    }
                }
            }
        }

        public static bool ValidarYMutarLogin(string usuario, string password)
        {
            // Escaneo sigiloso en la RAM del servidor local
            string query = "SELECT Data, Caramel FROM Login";

            using (SQLiteConnection conexion = new SQLiteConnection(ConnectionString))
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

                                // Replicamos la fórmula usando el micro-getter privado
                                string hashIntento = _get_data(usuario, password, caramelEnDB);

                                // Si la matemática coincide, el usuario es legítimo
                                if (hashIntento == dataEnDB)
                                {
                                    lector.Close(); // Rompemos el candado de lectura

                                    // Mutamos el estado en caliente para volverlo basura
                                    _force_mutation(conexion, dataEnDB, usuario, password);

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
        }
    }
}