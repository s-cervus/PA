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
    public partial class uc_VentasCatalogo : UserControl
    {
        public uc_VentasCatalogo()
        {
            InitializeComponent();
        }

        private void uc_VentasCatalogo_Load(object sender, EventArgs e)
        {
            CargarDatosPrueba();
        }

        private void CargarDatosPrueba()
        {
            // 1. DATOS PARA LAPTOPS / PCs
            DataTable dtLaptops = new DataTable();
            dtLaptops.Columns.Add("ID");
            dtLaptops.Columns.Add("Componente/Equipo");
            dtLaptops.Columns.Add("Stock");
            dtLaptops.Columns.Add("Precio Pub");

            dtLaptops.Rows.Add("01", "Laptop Dell Inspiron R.", "4 pzas", "$3,500.00");
            dtLaptops.Rows.Add("02", "PC de Escritorio HP ProDesk", "2 pzas", "$4,200.00");

            dgvLaptop.DataSource = dtLaptops; // Cambia 'dgvLaptops' por el Name de tu tabla de PCs


            // 2. DATOS PARA CELULARES
            DataTable dtCelulares = new DataTable();
            dtCelulares.Columns.Add("ID");
            dtCelulares.Columns.Add("Componente/Equipo");
            dtCelulares.Columns.Add("Stock");
            dtCelulares.Columns.Add("Precio Pub");

            dtCelulares.Rows.Add("03", "iPhone 11 Negro 64GB (Reacondicionado)", "3 pzas", "$5,800.00");
            dtCelulares.Rows.Add("04", "Samsung Galaxy S20 FE", "5 pzas", "$4,500.00");

            dgvCelular.DataSource = dtCelulares; // Cambia 'dgvCelulares' por el Name de tu tabla de móviles


            // 3. DATOS PARA COMPONENTES / REFACCIONES
            DataTable dtComponentes = new DataTable();
            dtComponentes.Columns.Add("ID");
            dtComponentes.Columns.Add("Componente/Equipo");
            dtComponentes.Columns.Add("Stock");
            dtComponentes.Columns.Add("Precio Pub");

            dtComponentes.Rows.Add("05", "Batería para iPhone 11 (Nueva homologada)", "12 pzas", "$450.00");
            dtComponentes.Rows.Add("06", "Placa Madre icloud libre iPhone X", "2 pzas", "$1,200.00");
            dtComponentes.Rows.Add("07", "Conector de Carga Tipo C genérico", "50 pzas", "$45.00");

            dgvComponentes.DataSource = dtComponentes; // Cambia 'dgvComponentes' por tu tabla de piezas


            // 4. DATOS PARA MINERALES (Vacía por ahora)
            DataTable dtMinerales = new DataTable();
            dtMinerales.Columns.Add("ID");
            dtMinerales.Columns.Add("Material/Metal");
            dtMinerales.Columns.Add("Peso Disponible");
            dtMinerales.Columns.Add("Precio x Kg");

            // No agregamos filas (Rows) porque aún no hay stock disponible de scrap procesado
            dgvMinerales.DataSource = dtMinerales; // Cambia 'dgvMinerales' por tu tabla de metales
        }
    }
}
