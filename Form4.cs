using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PA
{
    public partial class FormVenta : Form
    {
        // El carrito funcional
        public static List<ProductoCarrito> Carrito = new List<ProductoCarrito>();

        // Las tres tablas globales
        public static DataTable TablaLaptops = new DataTable();
        public static DataTable TablaCelulares = new DataTable();
        public static DataTable TablaComponentes = new DataTable();
        public static DataTable TablaMinerales = new DataTable();
        // ====== ¡NUEVO: ALMACÉN GLOBAL DE SCRAP COMPRADO POR KILO! ======
        public static List<ScrapComprado> HistorialScrap = new List<ScrapComprado>();

        // Estructura para almacenar los datos del Form5 de tu compañera
        public class ScrapComprado
        {
            public int ID { get; set; }
            public string Material { get; set; }
            public int Cantidad { get; set; }
            public double Peso { get; set; }
            public double PrecioKg { get; set; }
            public double Subtotal { get; set; }
            public string Estado { get; set; }
            public string Fecha { get; set; }
        }

        // CANDADO DE RUTA SEGURA: Guardamos los archivos directo en la carpeta de ejecución del programa
        private static string archivoLaptops = Path.Combine(Application.StartupPath, "inventario_laptops.xml");
        private static string archivoCelulares = Path.Combine(Application.StartupPath, "inventario_celulares.xml");
        private static string archivoComponentes = Path.Combine(Application.StartupPath, "inventario_componentes.xml");
        private static string archivoMinerales = Path.Combine(Application.StartupPath, "inventario_minerales.xml"); // <-- NUEVA

        public FormVenta()
        {
            InitializeComponent();

            // Configurar columnas y cargar/guardar datos
            ConfigurarTablasAlmacen();
        }

        private void ConfigurarTablasAlmacen()
        {
            // 1. CONFIGURAR TABLA LAPTOPS
            if (TablaLaptops.Columns.Count == 0)
            {
                TablaLaptops.TableName = "Laptops";
                TablaLaptops.Columns.Add("ID");
                TablaLaptops.Columns.Add("Componente/Equipo");
                TablaLaptops.Columns.Add("Stock", typeof(int));
                TablaLaptops.Columns.Add("Precio Pub");
            }

            // 2. CONFIGURAR TABLA CELULARES
            if (TablaCelulares.Columns.Count == 0)
            {
                TablaCelulares.TableName = "Celulares";
                TablaCelulares.Columns.Add("ID");
                TablaCelulares.Columns.Add("Componente/Equipo");
                TablaCelulares.Columns.Add("Stock", typeof(int));
                TablaCelulares.Columns.Add("Precio Pub");
            }

            // 3. CONFIGURAR TABLA COMPONENTES
            if (TablaComponentes.Columns.Count == 0)
            {
                TablaComponentes.TableName = "Componentes";
                TablaComponentes.Columns.Add("ID");
                TablaComponentes.Columns.Add("Componente/Equipo");
                TablaComponentes.Columns.Add("Stock", typeof(int));
                TablaComponentes.Columns.Add("Precio Pub");
            }

            // --- Estructura de Minerales / Scrap Pesado ---
            if (TablaMinerales.Columns.Count == 0)
            {
                TablaMinerales.TableName = "Minerales";
                TablaMinerales.Columns.Add("ID");
                TablaMinerales.Columns.Add("Componente/Equipo");
                TablaMinerales.Columns.Add("Stock", typeof(int));
                TablaMinerales.Columns.Add("Precio Pub");
            }

            // =========================================================================
            // LÓGICA DE PERSISTENCIA BLINDADA
            // =========================================================================

            // --- Carga de Laptops ---
            if (File.Exists(archivoLaptops))
            {
                try
                {
                    TablaLaptops.Clear();
                    TablaLaptops.ReadXml(archivoLaptops);
                }
                catch { CargarLaptopsPredeterminadas(); }
            }
            else
            {
                CargarLaptopsPredeterminadas();
            }

            // --- Carga de Celulares ---
            if (File.Exists(archivoCelulares))
            {
                try
                {
                    TablaCelulares.Clear();
                    TablaCelulares.ReadXml(archivoCelulares);
                }
                catch { CargarCelularesPredeterminados(); }
            }
            else
            {
                CargarCelularesPredeterminados();
            }

            // --- Carga de Componentes ---
            if (File.Exists(archivoComponentes))
            {
                try
                {
                    TablaComponentes.Clear();
                    TablaComponentes.ReadXml(archivoComponentes);
                }
                catch { CargarComponentesPredeterminados(); }
            }
            else
            {
                CargarComponentesPredeterminados();
            }

            // Minerales / Reciclaje Metales
            if (File.Exists(archivoMinerales)) { TablaMinerales.ReadXml(archivoMinerales); }
            else { TablaMinerales.Rows.Add("R01", "Cobre Recuperado (Kg)", 50, "$ 120"); GuardarInventarioEnDisco(); }
        }

        // Métodos auxiliares para inyectar datos solo si los archivos no existen
        private void CargarLaptopsPredeterminadas()
        {
            TablaLaptops.Rows.Add("L01", "Laptop Dell Inspiron R", 5, "$ 8,500");
            TablaLaptops.Rows.Add("L02", "MacBook Pro Mid 2012", 3, "$ 12,000");
            GuardarInventarioEnDisco(); // Crea el archivo inmediatamente
        }

        private void CargarCelularesPredeterminados()
        {
            TablaCelulares.Rows.Add("C01", "iPhone 11 Pro Max", 4, "$ 9,800");
            GuardarInventarioEnDisco();
        }

        private void CargarComponentesPredeterminados()
        {
            TablaComponentes.Rows.Add("M01", "Batería iPhone X", 15, "$ 650");
            GuardarInventarioEnDisco();
        }

        private void CargarMineralesPredeterminados()
        {
            TablaMinerales.Rows.Add("R01", "Cobre Recuperado (Kg)", 50, "$ 120");
            GuardarInventarioEnDisco();
        }

        // =========================================================================
        // MÉTODO MAESTRO GLOBAL PARA ESCRIBIR EN DISCO
        // =========================================================================
        public static void GuardarInventarioEnDisco()
        {
            try
            {
                TablaLaptops.WriteXml(archivoLaptops);
                TablaCelulares.WriteXml(archivoCelulares);
                TablaComponentes.WriteXml(archivoComponentes);
                TablaMinerales.WriteXml(archivoMinerales);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al guardar: " + ex.Message, "Sistema de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPantalla(UserControl pantallaHija)
        {
            pnlContenedor.Controls.Clear();
            pantallaHija.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(pantallaHija);
            pantallaHija.BringToFront();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            MostrarPantalla(new uc_VentasCatalogo());
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            MostrarPantalla(new uc_NuevaVenta());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            MostrarPantalla(new uc_InventarioGeneral());
        }

        private void btnVerMapa_Click(object sender, EventArgs e)
        {
            // Limpias tu panel contenedor e inyectas el mapa
            pnlContenedor.Controls.Clear();
            uc_MapaExpress miMapa = new uc_MapaExpress();
            miMapa.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(miMapa);
        }

        // ====== ¡NUEVO: BOTÓN DE CONTROL CONTABLE CENTRALIZADO! ======
        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            string rutaDiarioHtml = Path.Combine(Application.StartupPath, "diario.html");

            if (File.Exists(rutaDiarioHtml))
            {
                // Ejecuta el archivo .html en el navegador web predeterminado del sistema
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(rutaDiarioHtml) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("No se han generado movimientos contables en este turno de trabajo.", "Diario Vacante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            MostrarPantalla(new uc_CompraScrap());
        }

        private void FormVenta_Load(object sender, EventArgs e)
        {
            // 1. Leemos el rol actual dictaminado por la base de datos local
            string rolActual = PA.ControlUnit.CurrentRole;

            // 2. Aplicamos la regla de negocio acordada
            // Si el rol es de empleado, cajero o auditor, el botón de inventario manual se apaga
            if (rolActual == "EMPLEADO_RO" || rolActual == "AUDITOR_RO" || rolActual == "cajero")
            {
                btnInventario.Enabled = false;

                MessageBox.Show($"Sesión actual: {rolActual}. El módulo de edición manual de almacén ha sido deshabilitado para tu perfil.",
                                "Control de Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rolActual == "SUPER_ADMIN" || rolActual == "AJUSTES_RW")
            {
                // Administradores y contadores tienen vía libre
                btnInventario.Enabled = true;
            }
        }

        // ====== ¡MÉTODO MAESTRO COMPARTIDO: REGISTRO DE VENTAS EN HTML! ======
        public static void RegistrarVentaEnDiarioGeneralHTML(double totalVenta)
        {
            double subtotalVentas = totalVenta / 1.16;
            double ivaTrasladado = subtotalVentas * 0.16;
            double costoVenta = subtotalVentas * 0.50; // Costo estimado al 50% para Inventarios Perpetuos

            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            string folioFactura = "FAC-" + DateTime.Now.ToString("yyyyMMddHHmm");
            string rutaDiario = Path.Combine(Application.StartupPath, "Libro_Diario_General.html");

            try
            {
                // Si no existe, creamos la estructura base igual que en las compras
                if (!File.Exists(rutaDiario))
                {
                    using (StreamWriter sw = new StreamWriter(rutaDiario, false))
                    {
                        sw.WriteLine("<html><head><style>");
                        sw.WriteLine("body { font-family: Arial, sans-serif; margin: 30px; }");
                        sw.WriteLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
                        sw.WriteLine("th, td { border: 1px solid #333; padding: 10px; text-align: left; }");
                        sw.WriteLine("th { background-color: #f2f2f2; }");
                        sw.WriteLine(".subcuenta { font-style: italic; padding-left: 20px; color: #555; }");
                        sw.WriteLine(".redaccion { font-size: 12px; color: #666; font-style: italic; }");
                        sw.WriteLine("</style></head><body>");
                        sw.WriteLine("<h2>CECyT 13 - Sistema TechBuilders / Eco-Tech</h2>");
                        sw.WriteLine("<h1>LIBRO DE DIARIO GENERAL AUTOGENERADO</h1>");
                        sw.WriteLine("<table>");
                        sw.WriteLine("<tr><th>Fecha</th><th>Concepto / Cuentas</th><th>Parcial</th><th>Debe</th><th>Haber</th></tr>");
                    }
                }

                // Insertamos el asiento de la venta al final del archivo
                using (StreamWriter sw = new StreamWriter(rutaDiario, true))
                {
                    // === ASVENTA 1: INGRESO ===
                    sw.WriteLine($"<tr><td>{fechaActual}</td><td><strong>Bancos</strong></td><td></td><td>$ {totalVenta:N2}</td><td></td></tr>");
                    sw.WriteLine($"<tr><td></td><td class='subcuenta'>BBVA Bancomer</td><td>$ {totalVenta:N2}</td><td></td><td></td></tr>");
                    sw.WriteLine($"<tr><td></td><td>&nbsp;&nbsp;&nbsp;&nbsp;<strong>Ventas</strong></td><td></td><td></td><td>$ {subtotalVentas:N2}</td></tr>");
                    sw.WriteLine($"<tr><td></td><td>&nbsp;&nbsp;&nbsp;&nbsp;<strong>I.V.A. Trasladado</strong></td><td></td><td></td><td>$ {ivaTrasladado:N2}</td></tr>");
                    sw.WriteLine($"<tr><td></td><td colspan='4' class='redaccion'>Redacción: Venta de equipos comerciales de contado según {folioFactura}.</td></tr>");

                    sw.WriteLine("<tr><td colspan='5' style='border:none; height:5px;'></td></tr>");

                    // === ASVENTA 1A: COSTO DE VENTAS ===
                    sw.WriteLine($"<tr><td>{fechaActual}</td><td><strong>Costo de Ventas</strong></td><td></td><td>$ {costoVenta:N2}</td><td></td></tr>");
                    sw.WriteLine($"<tr><td></td><td>&nbsp;&nbsp;&nbsp;&nbsp;<strong>Almacén</strong></td><td></td><td></td><td>$ {costoVenta:N2}</td></tr>");
                    sw.WriteLine($"<tr><td></td><td class='subcuenta'>&nbsp;&nbsp;&nbsp;&nbsp;Equipos Reparados</td><td>$ {costoVenta:N2}</td><td></td><td></td></tr>");
                    sw.WriteLine($"<tr><td></td><td colspan='4' class='redaccion'>Redacción: Registro del costo correspondiente a la venta anterior.</td></tr>");

                    sw.WriteLine("<tr><td colspan='5' style='border:none; height:15px; background-color:#e6f2ff;'></td></tr>");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar contabilidad de la venta: " + ex.Message);
            }
        }
    }
}