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
    public partial class uc_CompraScrap : UserControl
    {
        public uc_CompraScrap()
        {
            InitializeComponent();
            CargarHistorialEnTabla();
        }

        private void CargarHistorialEnTabla()
        {
            // Limpiamos el origen de datos e inyectamos directamente la lista global
            dgvHistorialScrap.DataSource = null;
            dgvHistorialScrap.DataSource = FormVenta.HistorialScrap;

            // Ajustamos el diseño automático de las columnas para que llene la pantalla
            dgvHistorialScrap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorialScrap.ReadOnly = true; // Que sea solo lectura para auditoría
        }
    }
}
