using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PA
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        int contadorID = 1;
        double subtotalGeneral = 0;
        double iva = 0;
        double totalFinal = 0;

<<<<<<< Updated upstream
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
=======
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvCompras.Columns.Clear();

            dgvCompras.Columns.Add("ID", "ID");
            dgvCompras.Columns.Add("Material", "Tipo de Material");
            dgvCompras.Columns.Add("Cantidad", "Cantidad");
            dgvCompras.Columns.Add("Peso", "Peso (kg)");
            dgvCompras.Columns.Add("PrecioKg", "Precio por Kg");
            dgvCompras.Columns.Add("Subtotal", "Subtotal");

            cmbMaterial.Items.Add("Celulares");
            cmbMaterial.Items.Add("Laptops");
            cmbMaterial.Items.Add("Tablets");
            cmbMaterial.Items.Add("Monitores");
            cmbMaterial.Items.Add("Tarjetas Electrónicas");
            cmbMaterial.Items.Add("Cables");
            cmbMaterial.Items.Add("Baterías");
            cmbMaterial.Items.Add("Computadoras de Escritorio");
            cmbMaterial.Items.Add("Impresoras");
            cmbMaterial.Items.Add("Escáneres");
            cmbMaterial.Items.Add("Discos Duros");
            cmbMaterial.Items.Add("Teclados");
            cmbMaterial.Items.Add("Tarjetas de Video");
            cmbMaterial.Items.Add("Procesadores (CPU)");
            cmbMaterial.Items.Add("Memorias RAM");
            cmbMaterial.Items.Add("Fuentes de Poder");
            cmbMaterial.Items.Add("Placas Base (Motherboards)");
            cmbMaterial.Items.Add("Unidades de CD/DVD");
            cmbMaterial.Items.Add("Mouse");
            cmbMaterial.Items.Add("Pantallas");
            cmbMaterial.Items.Add("Oro");
            cmbMaterial.Items.Add("Plata");
            cmbMaterial.Items.Add("Cobre");
            cmbMaterial.Items.Add("Aluminio");
            cmbMaterial.Items.Add("Acero");
            cmbMaterial.Items.Add("Hierro");
            cmbMaterial.Items.Add("Bocinas");

            cmbEstado.Items.Add("Funcional");
            cmbEstado.Items.Add("Dañado");
            cmbEstado.Items.Add("Para Refacciones");

            lblTotalArti.Text = "0";
            lblPesoTot.Text = "0.00";
            lblSubtot.Text = "$0.00";
            lblimpuest.Text = "$0.00";
            lblTotalPaga.Text = "$0.00";
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (cmbMaterial.Text == "")
            {
                MessageBox.Show("Seleccione un material");
                return;
            }

            if (txtPeso.Text == "")
            {
                MessageBox.Show("Ingrese el peso");
                return;
            }

            double peso = Convert.ToDouble(txtPeso.Text);
            double precioKg = Convert.ToDouble(txtPrecioKg.Text);

            double subtotal = peso * precioKg;

            dgvCompras.Rows.Add(
                contadorID,
                cmbMaterial.Text,
                nudCantidad.Value,
                peso,
                precioKg,
                subtotal
            );

            contadorID++;

            ActualizarResumen();
        }
        private void ActualizarResumen()
        {
            int totalArticulos = 0;
            double pesoTotal = 0;
            subtotalGeneral = 0;

            foreach (DataGridViewRow fila in dgvCompras.Rows)
            {
                if (fila.Cells[0].Value != null)
                {
                    totalArticulos += Convert.ToInt32(fila.Cells[2].Value);
                    pesoTotal += Convert.ToDouble(fila.Cells[3].Value);
                    subtotalGeneral += Convert.ToDouble(fila.Cells[5].Value);
                }
            }

            iva = subtotalGeneral * 0.16;
            totalFinal = subtotalGeneral + iva;

            lblTotalArti.Text = totalArticulos.ToString();
            lblPesoTot.Text = pesoTotal.ToString("N2") + " kg";
            lblSubtot.Text = "$" + subtotalGeneral.ToString("N2");
            lblimpuest.Text = "$" + iva.ToString("N2");
            lblTotalPaga.Text = "$" + totalFinal.ToString("N2");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (dgvCompras.Rows.Count <= 1)
            {
                MessageBox.Show("No hay materiales registrados");
                return;
            }

            MessageBox.Show(
                "Compra registrada correctamente\n\n" +
                "Vendedor: " + txtNombreCompleto.Text +
                "\nTotal pagado: " + lblTotalPaga.Text,
                "Compra Exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
        !char.IsWhiteSpace(e.KeyChar) &&
        !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void txtTeléfono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
        !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
         !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
       e.KeyChar != '.' &&
       !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' &&
                ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }

        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
       e.KeyChar != '.' &&
       !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' &&
                ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtEdad_Leave(object sender, EventArgs e)
        {
            if (txtEdad.Text != "")
            {
                int edad = Convert.ToInt32(txtEdad.Text);

                if (edad < 18 || edad > 120)
                {
                    MessageBox.Show(
                        "La edad debe estar entre 18 y 120 años");

                    txtEdad.Clear();
                    txtEdad.Focus();
                }
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtPeso.Clear();
            txtPrecioKg.Clear();

            cmbMaterial.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            nudCantidad.Value = 0;
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvCompras.SelectedRows.Count > 0)
            {
                dgvCompras.Rows.RemoveAt(
                    dgvCompras.SelectedRows[0].Index);

                ActualizarResumen();
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();

            guardar.Filter = "Archivo de texto|*.txt";
            guardar.Title = "Guardar Ticket";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                string ticket = "";

                ticket += "=====================================\n";
                ticket += "      RECICLADORA ECO-TECH\n";
                ticket += " COMPRA DE RESIDUOS ELECTRONICOS\n";
                ticket += "=====================================\n\n";

                ticket += "Fecha: " +
                          DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                          "\n\n";

                ticket += "DATOS DEL VENDEDOR\n";
                ticket += "-------------------------------------\n";
                ticket += "Nombre: " + txtNombreCompleto.Text + "\n";
                ticket += "Telefono: " + txtTeléfono.Text + "\n";
                ticket += "Direccion: " + txtDirección.Text + "\n";
                ticket += "Edad: " + txtEdad.Text + "\n\n";

                ticket += "MATERIALES RECIBIDOS\n";
                ticket += "-------------------------------------\n";

                foreach (DataGridViewRow fila in dgvCompras.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        ticket += "Material: " +
                                  fila.Cells[1].Value + "\n";

                        ticket += "Cantidad: " +
                                  fila.Cells[2].Value + "\n";

                        ticket += "Peso: " +
                                  fila.Cells[3].Value + " kg\n";

                        ticket += "Precio por kg: $" +
                                  fila.Cells[4].Value + "\n";

                        ticket += "Subtotal: $" +
                                  fila.Cells[5].Value + "\n";

                        ticket += "-------------------------------------\n";
                    }
                }

                ticket += "\nRESUMEN\n";
                ticket += "=====================================\n";
                ticket += "Total Articulos: " +
                          lblTotalArti.Text + "\n";

                ticket += "Peso Total: " +
                          lblPesoTot.Text + "\n";

                ticket += "Subtotal: " +
                          lblSubtot.Text + "\n";

                ticket += "IVA: " +
                          lblimpuest.Text + "\n";

                ticket += "TOTAL PAGADO: " +
                          lblTotalPaga.Text + "\n";

                ticket += "\nGracias por reciclar con nosotros.";

                File.WriteAllText(
                    guardar.FileName,
                    ticket);

                MessageBox.Show(
                    "Ticket generado correctamente");

                Process.Start("notepad.exe",
                              guardar.FileName);
            }
        }

        private void ActualizarPrecio()
        {
            if (cmbMaterial.Text == "" || cmbEstado.Text == "")
                return;

            double precio = 0;

            switch (cmbMaterial.Text)
            {
                case "Celulares":
                    precio = cmbEstado.Text == "Funcional" ? 120 :
                             cmbEstado.Text == "Dañado" ? 70 : 50;
                    break;

                case "Laptops":
                    precio = cmbEstado.Text == "Funcional" ? 200 :
                             cmbEstado.Text == "Dañado" ? 120 : 80;
                    break;

                case "Tablets":
                    precio = cmbEstado.Text == "Funcional" ? 150 :
                             cmbEstado.Text == "Dañado" ? 90 : 60;
                    break;

                case "Monitores":
                    precio = cmbEstado.Text == "Funcional" ? 80 :
                             cmbEstado.Text == "Dañado" ? 50 : 30;
                    break;

                case "Tarjetas Electrónicas":
                    precio = cmbEstado.Text == "Funcional" ? 300 :
                             cmbEstado.Text == "Dañado" ? 180 : 120;
                    break;

                case "Cables":
                    precio = cmbEstado.Text == "Funcional" ? 60 :
                             cmbEstado.Text == "Dañado" ? 40 : 25;
                    break;

                case "Baterías":
                    precio = cmbEstado.Text == "Funcional" ? 90 :
                             cmbEstado.Text == "Dañado" ? 60 : 40;
                    break;

                case "Computadoras de Escritorio":
                    precio = cmbEstado.Text == "Funcional" ? 250 :
                             cmbEstado.Text == "Dañado" ? 150 : 100;
                    break;

                case "Impresoras":
                    precio = cmbEstado.Text == "Funcional" ? 100 :
                             cmbEstado.Text == "Dañado" ? 60 : 40;
                    break;

                case "Discos Duros":
                    precio = cmbEstado.Text == "Funcional" ? 180 :
                             cmbEstado.Text == "Dañado" ? 100 : 70;
                    break;

                case "Procesadores (CPU)":
                    precio = cmbEstado.Text == "Funcional" ? 400 :
                             cmbEstado.Text == "Dañado" ? 250 : 180;
                    break;

                case "Memorias RAM":
                    precio = cmbEstado.Text == "Funcional" ? 150 :
                             cmbEstado.Text == "Dañado" ? 90 : 60;
                    break;

                case "Escáneres":
                    precio = cmbEstado.Text == "Funcional" ? 90 :
                             cmbEstado.Text == "Dañado" ? 50 : 35;
                    break;

                case "Teclados":
                    precio = cmbEstado.Text == "Funcional" ? 40 :
                             cmbEstado.Text == "Dañado" ? 20 : 10;
                    break;

                case "Tarjetas de Video":
                    precio = cmbEstado.Text == "Funcional" ? 350 :
                             cmbEstado.Text == "Dañado" ? 200 : 130;
                    break;

                case "Fuentes de Poder":
                    precio = cmbEstado.Text == "Funcional" ? 80 :
                             cmbEstado.Text == "Dañado" ? 45 : 30;
                    break;

                case "Placas Base (Motherboards)":
                    precio = cmbEstado.Text == "Funcional" ? 280 :
                             cmbEstado.Text == "Dañado" ? 160 : 100;
                    break;

                case "Unidades de CD/DVD":
                    precio = cmbEstado.Text == "Funcional" ? 50 :
                             cmbEstado.Text == "Dañado" ? 25 : 15;
                    break;

                case "Mouse":
                    precio = cmbEstado.Text == "Funcional" ? 30 :
                             cmbEstado.Text == "Dañado" ? 15 : 8;
                    break;

                case "Pantallas":
                    precio = cmbEstado.Text == "Funcional" ? 120 :
                             cmbEstado.Text == "Dañado" ? 70 : 45;
                    break;

                case "Oro":
                    precio = cmbEstado.Text == "Funcional" ? 1500 :
                             cmbEstado.Text == "Dañado" ? 1500 : 1500;
                    break;

                case "Plata":
                    precio = cmbEstado.Text == "Funcional" ? 800 :
                             cmbEstado.Text == "Dañado" ? 800 : 800;
                    break;

                case "Cobre":
                    precio = cmbEstado.Text == "Funcional" ? 180 :
                             cmbEstado.Text == "Dañado" ? 180 : 180;
                    break;

                case "Aluminio":
                    precio = cmbEstado.Text == "Funcional" ? 90 :
                             cmbEstado.Text == "Dañado" ? 90 : 90;
                    break;

                case "Acero":
                    precio = cmbEstado.Text == "Funcional" ? 60 :
                             cmbEstado.Text == "Dañado" ? 60 : 60;
                    break;

                case "Hierro":
                    precio = cmbEstado.Text == "Funcional" ? 50 :
                             cmbEstado.Text == "Dañado" ? 50 : 50;
                    break;

                case "Bocinas":
                    precio = cmbEstado.Text == "Funcional" ? 70 :
                             cmbEstado.Text == "Dañado" ? 40 : 25;
                    break;
            }

            txtPrecioKg.Text = precio.ToString();
        }
        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
                        ActualizarPrecio();
        }

        private void txtTeléfono_Leave(object sender, EventArgs e)
        {
            if (txtTeléfono.Text.Length != 10)
            {
                MessageBox.Show(
                    "El teléfono debe tener exactamente 10 dígitos",
                    "Dato inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTeléfono.Focus();
            }
        }
    }
}
>>>>>>> Stashed changes

      

 
