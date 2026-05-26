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
    public partial class uc_NuevaVenta : UserControl
    {
        public uc_NuevaVenta()
        {
            InitializeComponent();

            // MANDAMOS LLAMAR A LA FUNCIÓN QUE CARGA EL CARRITO EN LA TABLA
            ActualizarPantallaCaja();
        }

        // Esta función va a revisar el carrito del Form4 y lo pinta en la tabla
        public void ActualizarPantallaCaja()
        {
            dgvCarrito.DataSource = null; // Limpiamos la tabla
            dgvCarrito.DataSource = FormEntrada.Carrito; // Le pasamos la lista global

            // Calculamos la suma total de lo que lleva
            decimal totalGeneral = 0;
            foreach (var item in FormEntrada.Carrito)
            {
                totalGeneral += item.Total;
            }

            lblTotal.Text = "Total: " + totalGeneral.ToString("C"); // El "C" le da formato de dinero ($)
        }

        // Evento del botón para cobrar y simular la contabilidad

        private void btnTerminarVenta_Click_1(object sender, EventArgs e)
        {
            if (FormEntrada.Carrito.Count > 0)
            {
                // Mensaje contable pro para el Proyecto Aula
                string asiento = "--- POLIZA DE DIARIO / INGRESO ---\n\n" +
                                 "CARGO:\n" +
                                 "  [+] Caja y Bancos -------------- " + lblTotal.Text + "\n\n" +
                                 "ABONO:\n" +
                                 "  [-] Ventas de Mercancía / Scrap -- " + lblTotal.Text + "\n\n" +
                                 "¡Venta registrada en el diario contable con éxito!";

                MessageBox.Show(asiento, "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiamos todo para la siguiente venta
                FormEntrada.Carrito.Clear();
                ActualizarPantallaCaja();
            }
            else
            {
                MessageBox.Show("El carrito está vacío, carnal. Agrega algo desde el catálogo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}