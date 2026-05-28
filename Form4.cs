using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // <-- SÚPER IMPORTANTE: Para manejar la lectura y escritura de archivos
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA
{
    public partial class FormEntrada : Form
    {
        // El carrito que ya te funciona al 100%
        public static List<ProductoCarrito> Carrito = new List<ProductoCarrito>();

        // LAS TRES TABLAS GLOBALES DEL ALMACÉN (Bases de datos en memoria)
        public static DataTable TablaLaptops = new DataTable();
        public static DataTable TablaCelulares = new DataTable();
        public static DataTable TablaComponentes = new DataTable();

        // Nombres de los archivos físicos locales (.xml) donde se guardarán los datos para siempre
        private static string archivoLaptops = "inventario_laptops.xml";
        private static string archivoCelulares = "inventario_celulares.xml";
        private static string archivoComponentes = "inventario_componentes.xml";

        public FormEntrada()
        {
            InitializeComponent();

            // Inicializamos las columnas y los productos de prueba o cargamos los guardados
            ConfigurarTablasAlmacen();
        }

        private void ConfigurarTablasAlmacen()
        {
            // 1. ESTRUCTURA PARA LAPTOPS
            if (TablaLaptops.Columns.Count == 0)
            {
                TablaLaptops.TableName = "Laptops"; // <-- ¡ESTA LÍNEA ES EL TRUCO MAESTRO!

                TablaLaptops.Columns.Add("ID");
                TablaLaptops.Columns.Add("Componente/Equipo");
                TablaLaptops.Columns.Add("Stock", typeof(int));
                TablaLaptops.Columns.Add("Precio Pub");

                TablaLaptops.Rows.Add("L01", "Laptop Dell Inspiron R", 5, "$ 8,500");
                TablaLaptops.Rows.Add("L02", "MacBook Pro Mid 2012", 3, "$ 12,000");
            }

            // 2. ESTRUCTURA PARA CELULARES
            if (TablaCelulares.Columns.Count == 0)
            {
                TablaCelulares.TableName = "Celulares"; // <-- ¡ESTA TAMBIÉN!

                TablaCelulares.Columns.Add("ID");
                TablaCelulares.Columns.Add("Componente/Equipo");
                TablaCelulares.Columns.Add("Stock", typeof(int));
                TablaCelulares.Columns.Add("Precio Pub");

                TablaCelulares.Rows.Add("C01", "iPhone 11 Pro Max", 4, "$ 9,800");
            }

            // 3. ESTRUCTURA PARA COMPONENTES
            if (TablaComponentes.Columns.Count == 0)
            {
                TablaComponentes.TableName = "Componentes"; // <-- Y ESTA ÚLTIMA

                TablaComponentes.Columns.Add("ID");
                TablaComponentes.Columns.Add("Componente/Equipo");
                TablaComponentes.Columns.Add("Stock", typeof(int));
                TablaComponentes.Columns.Add("Precio Pub");

                TablaComponentes.Rows.Add("M01", "Batería iPhone X", 15, "$ 650");
            }
        }

        // =========================================================================
        // MÉTODO MAESTRO GLOBAL: Escribe el estado de las tablas en el disco de la compu.
        // Este método es el que llaman tus UserControls al vender o insertar cosas.
        // =========================================================================
        public static void GuardarInventarioEnDisco()
        {
            try
            {
                TablaLaptops.WriteXml(archivoLaptops);
                TablaCelulares.WriteXml(archivoCelulares);
                TablaComponentes.WriteXml(archivoComponentes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de persistencia de datos al guardar: " + ex.Message, "Error de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPantalla(UserControl pantallaHija)
        {
            pnlContenedor.Controls.Clear(); // Limpia lo que haya en el centro
            pantallaHija.Dock = DockStyle.Fill; // Hace que el UC se estire al tamaño del panel
            pnlContenedor.Controls.Add(pantallaHija); // Lo mete al panel
            pantallaHija.BringToFront(); // Lo trae al frente
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            MostrarPantalla(new uc_VentasCatalogo());
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            // Llamamos a la pantalla de la caja pasando el nuevo User Control
            MostrarPantalla(new uc_NuevaVenta());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3();
            menu.Show();
            this.Hide();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            MostrarPantalla(new uc_InventarioGeneral());
        }
    }
}
