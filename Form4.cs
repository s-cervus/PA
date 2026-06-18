using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static DataTable TablaMinerales = new DataTable(); // <-- NUEVA

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

        private void btnContabilidad_Click(object sender, EventArgs e)
        {

        }

        private void btnCompras_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void FormVenta_Load(object sender, EventArgs e)
        {

        }
    }
}