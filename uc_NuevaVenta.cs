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

        // Esta función va a revisar el carrito del FormEntrada y lo pinta en la tabla
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

        // Evento del botón para cobrar, actualizar inventario y simular la contabilidad
        private void btnTerminarVenta_Click_1(object sender, EventArgs e)
        {
            if (FormEntrada.Carrito.Count > 0)
            {
                // =========================================================================
                // FASE 1: VALIDACIÓN DE SEGURIDAD (Revisar que haya suficiente stock de TODO)
                // =========================================================================
                foreach (var item in FormEntrada.Carrito)
                {
                    // 1. Validar en Laptops
                    foreach (DataRow fila in FormEntrada.TablaLaptops.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            if (stockActual < item.Cantidad)
                            {
                                MessageBox.Show("¡Gis de alerta! No hay suficiente stock de '" + item.Descripcion + "'.\nDisponibles: " + stockActual + " pzas.\nSolicitadas en carrito: " + item.Cantidad + " pzas.", "Falta de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return; // Frena toda la venta de golpe. No descuenta nada.
                            }
                        }
                    }

                    // 2. Validar en Celulares
                    foreach (DataRow fila in FormEntrada.TablaCelulares.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            if (stockActual < item.Cantidad)
                            {
                                MessageBox.Show("¡Gis de alerta! No hay suficiente stock de '" + item.Descripcion + "'.\nDisponibles: " + stockActual + " pzas.\nSolicitadas en carrito: " + item.Cantidad + " pzas.", "Falta de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return; // Frena toda la venta de golpe.
                            }
                        }
                    }

                    // 3. Validar en Componentes
                    foreach (DataRow fila in FormEntrada.TablaComponentes.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            if (stockActual < item.Cantidad)
                            {
                                MessageBox.Show("¡Gis de alerta! No hay suficiente stock de '" + item.Descripcion + "'.\nDisponibles: " + stockActual + " pzas.\nSolicitadas en carrito: " + item.Cantidad + " pzas.", "Falta de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return; // Frena toda la venta de golpe.
                            }
                        }
                    }
                }

                // =========================================================================
                // FASE 2: PROCESAR DESCUENTOS (Solo entra si la Fase 1 fue totalmente exitosa)
                // =========================================================================
                foreach (var item in FormEntrada.Carrito)
                {
                    // Descontar en Laptops
                    foreach (DataRow fila in FormEntrada.TablaLaptops.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            fila["Stock"] = stockActual - item.Cantidad;
                        }
                    }

                    // Descontar en Celulares
                    foreach (DataRow fila in FormEntrada.TablaCelulares.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            fila["Stock"] = stockActual - item.Cantidad;
                        }
                    }

                    // Descontar en Componentes / Refacciones
                    foreach (DataRow fila in FormEntrada.TablaComponentes.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            fila["Stock"] = stockActual - item.Cantidad;
                        }
                    }
                }

                // === GUARDADO MAESTRO EN DISCO DURO ===
                // Guarda las reducciones de stock físicas en los archivos XML del sistema
                FormEntrada.GuardarInventarioEnDisco();

                // Mensaje contable pro para el Proyecto Aula
                string asiento = "--- POLIZA DE DIARIO / INGRESO ---\n\n" +
                                 "CARGO:\n" +
                                 "  [+] Caja y Bancos -------------- " + lblTotal.Text + "\n\n" +
                                 "ABONO:\n" +
                                 "  [-] Ventas de Mercancía / Scrap -- " + lblTotal.Text + "\n\n" +
                                 "¡Venta registrada e inventario actualizado con éxito!";

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