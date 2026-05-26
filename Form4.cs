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
    public partial class Form4 : Form
    {
        public static List<ProductoCarrito> Carrito = new List<ProductoCarrito>();
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

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
    }
}

