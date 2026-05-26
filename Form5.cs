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
    public partial class FormSalida : Form
    {
        public FormSalida()

        {
            InitializeComponent();
        }

            // Evento Load: Se ejecuta al abrir la ventana. Ideal para cargar listas.
            private void FormCompra_Load(object sender, EventArgs e)
            {
                // Llenamos los ComboBox con datos de prueba (Puedes cambiarlos)
                cmbArtículo.Items.AddRange(new string[] { "Aluminio", "Cobre", "Hierro", "Cartón" });
                cmbEstado.Items.AddRange(new string[] { "Buen estado", "Dañado" });
                cmbMetodoPago.Items.AddRange(new string[] { "Efectivo", "Transferencia", "Tarjeta" });

                // Configuramos los TextBox de totales como solo lectura
                txtTotalArtículos.ReadOnly = true;
                txtTotalPeso.ReadOnly = true;
                txtTotalCobrar.ReadOnly = true;
            }

            // Evento del botón "Añadir a la compra"
            private void btnAnadir_Click(object sender, EventArgs e)
            {
                // 1. Validaciones básicas
                if (cmbArtículo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor seleccione un artículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtCantidadPeso.Text, out decimal pesoOCantidad))
                {
                    MessageBox.Show("Por favor ingrese una cantidad o peso numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Obtener datos de la interfaz
                string articulo = cmbArtículo.SelectedItem.ToString();
                string estado = cmbEstado.SelectedItem?.ToString() ?? "N/A"; // Si no elige estado, pone N/A

                // 3. Simular precio (En un caso real, esto viene de una Base de Datos)
                decimal precioPorKg = ObtenerPrecioFicticio(articulo);

                // 4. Cálculos matemáticos
                decimal subtotal = pesoOCantidad * precioPorKg;
                decimal iva = subtotal * 0.16m; // IVA del 16%
                decimal totalFila = subtotal + iva;

                // 5. Agregar la fila al DataGridView (El orden depende de tus columnas)
                // Asumimos: Artículos | Cantidad | Estado | Peso(Kg) | PrecioKg | Subtotal | IVA | Total
                dgvDetalles.Rows.Add(
                    articulo,
                    1, // Suponemos 1 unidad física por defecto
                    estado,
                    pesoOCantidad, // Lo tratamos como peso según la imagen
                    precioPorKg,
                    subtotal,
                    iva,
                    totalFila
                );

                // 6. Limpiar campos de entrada y actualizar tabla inferior
                cmbArtículo.SelectedIndex = -1;
                cmbEstado.SelectedIndex = -1;
                txtCantidadPeso.Clear();

                ActualizarTotales();
            }

            // Evento del botón "Limpiar formulario"
            private void btnLimpiar_Click(object sender, EventArgs e)
            {
                // Limpiar TextBoxes del proveedor
                // txtNombreProveedor.Clear(); 
                // txtDireccion.Clear();
                // txtTelefono.Clear();

                // Limpiar Grid y Totales
                dgvDetalles.Rows.Clear();
                ActualizarTotales();

                cmbMetodoPago.SelectedIndex = -1;
            }

            // Evento del botón "Confirmar venta"
            private void btnConfirmarVenta_Click(object sender, EventArgs e)
            {
                if (dgvDetalles.Rows.Count == 0 || (dgvDetalles.Rows.Count == 1 && dgvDetalles.Rows[0].IsNewRow))
                {
                    MessageBox.Show("No hay artículos en la compra.", "Aviso");
                    return;
                }

                // Aquí iría el código para guardar en tu Base de Datos (SQL Server, MySQL, etc.)
                MessageBox.Show("¡Venta confirmada y registrada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLimpiar_Click(sender, e); // Limpiar después de guardar
            }

            // --- MÉTODOS AUXILIARES ---

            // Método para recalcular los totales iterando sobre el DataGridView
            private void ActualizarTotales()
            {
                int totalArticulos = 0;
                decimal totalPeso = 0;
                decimal totalCobrar = 0;

                foreach (DataGridViewRow fila in dgvDetalles.Rows)
                {
                    // Ignorar la fila vacía que permite agregar nuevos datos manualmente
                    if (fila.IsNewRow) continue;

                    // Sumar Cantidad (Columna 1)
                    totalArticulos += Convert.ToInt32(fila.Cells[1].Value);
                    // Sumar Peso (Columna 3)
                    totalPeso += Convert.ToDecimal(fila.Cells[3].Value);
                    // Sumar Total (Columna 7)
                    totalCobrar += Convert.ToDecimal(fila.Cells[7].Value);
                }

                // Mostrar resultados en los TextBoxes formateados
                txtTotalArtículos.Text = totalArticulos.ToString();
                txtTotalPeso.Text = totalPeso.ToString("0.00"); // 2 decimales
                txtTotalCobrar.Text = totalCobrar.ToString("C2"); // Formato de moneda local (ej. $1,000.00)
            }

            // Método ficticio para dar precio según el material
            private decimal ObtenerPrecioFicticio(string articulo)
            {
                switch (articulo)
                {
                    case "Cobre": return 150.50m;
                    case "Aluminio": return 45.00m;
                    case "Hierro": return 12.00m;
                    case "Cartón": return 3.50m;
                    default: return 10.00m;
                }
            }
        }
    }


