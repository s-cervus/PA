using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;



namespace PA
{
    public partial class FormCompra : Form
    {
        public FormCompra()
        {
            InitializeComponent();
        }

        int contadorID = 1;
        double subtotalGeneral = 0;
        double iva = 0;
        double totalFinal = 0;

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

        // ==========================================
        // EDICIÓN 1: CANDADOS DE ROLES AL AGREGAR
        // ==========================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Candado de Seguridad de Roles
            if (PA.ControlUnit.CurrentRole != "SUPER_ADMIN" && PA.ControlUnit.CurrentRole != "ADMIN_RW")
            {
                MessageBox.Show("Tu cuenta no tiene privilegios para registrar entradas o compras de Scrap.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

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

        // ================================================================
        // EDICIÓN 2: ENVIAR TODO EL HISTORIAL DE SCRAP POR KILO AL FORM 4
        // ================================================================
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (dgvCompras.Rows.Count <= 1)
            {
                if (dgvCompras.Rows.Count <= 1)
                {
                    MessageBox.Show("No hay materiales registrados en la lista.");
                    return;
                }

                string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
                string folioTicket = "TK-" + DateTime.Now.ToString("yyyyMMddHHmm");
                string rutaDiario = Path.Combine(Application.StartupPath, "Libro_Diario_General.html");

                try
                {
                    // Si el archivo no existe, creamos la estructura HTML inicial
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

                    // Abrimos el archivo en modo APPEND (true) para añadir filas al final
                    using (StreamWriter sw = new StreamWriter(rutaDiario, true))
                    {
                        foreach (DataGridViewRow fila in dgvCompras.Rows)
                        {
                            if (fila.Cells[0].Value != null)
                            {
                                string material = fila.Cells[1].Value.ToString();
                                double subtotal = Convert.ToDouble(fila.Cells[5].Value);
                                double iva = subtotal * 0.16;
                                double totalBancos = subtotal + iva;
                                string glosa = $"Compra de materia prima ({material}) por kilogramo, según {folioTicket}.";

                                // --- CARGO A ALMACÉN ---
                                sw.WriteLine($"<tr><td>{fechaActual}</td><td><strong>Almacén</strong></td><td></td><td>$ {subtotal:N2}</td><td></td></tr>");
                                sw.WriteLine($"<tr><td></td><td class='subcuenta'>Materia Prima - {material}</td><td>$ {subtotal:N2}</td><td></td><td></td></tr>");

                                // --- CARGO A IVA ACREDITABLE ---
                                sw.WriteLine($"<tr><td></td><td><strong>I.V.A. Acreditable</strong></td><td></td><td>$ {iva:N2}</td><td></td></tr>");

                                // --- ABONO A BANCOS ---
                                sw.WriteLine($"<tr><td></td><td>&nbsp;&nbsp;&nbsp;&nbsp;<strong>Bancos</strong></td><td></td><td></td><td>$ {totalBancos:N2}</td></tr>");
                                sw.WriteLine($"<tr><td></td><td class='subcuenta'>&nbsp;&nbsp;&nbsp;&nbsp;BBVA Bancomer</td><td>$ {totalBancos:N2}</td><td></td><td></td></tr>");

                                // --- GLOSA ---
                                sw.WriteLine($"<tr><td></td><td colspan='4' class='redaccion'>Redacción: {glosa}</td></tr>");
                                sw.WriteLine("<tr><td colspan='5' style='border:none; height:10px; background-color:#f9f9f9;'></td></tr>");
                            }
                        }
                    }

                    MessageBox.Show("Compra asentada en el Libro de Diario General.", "Éxito Contable");
                    dgvCompras.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al escribir en el diario: " + ex.Message);
                }
            }

            // Pasamos cada fila del DataGridView directo a la lista estática del FormVenta (Form4)
            foreach (DataGridViewRow fila in dgvCompras.Rows)
            {
                if (fila.Cells[0].Value != null)
                {
                    FormVenta.HistorialScrap.Add(new FormVenta.ScrapComprado
                    {
                        ID = Convert.ToInt32(fila.Cells[0].Value),
                        Material = fila.Cells[1].Value.ToString(),
                        Cantidad = Convert.ToInt32(fila.Cells[2].Value),
                        Peso = Convert.ToDouble(fila.Cells[3].Value),
                        PrecioKg = Convert.ToDouble(fila.Cells[4].Value),
                        Subtotal = Convert.ToDouble(fila.Cells[5].Value),
                        Estado = cmbEstado.Text, // Captura el estado (Funcional/Dañado) de la compra
                        Fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                    });
                }
            }

            MessageBox.Show(
                "Compra registrada correctamente\nLos materiales se enviaron al Almacén General de Scrap.\n\n" +
                "Vendedor: " + txtNombreCompleto.Text +
                "\nTotal pagado: " + lblTotalPaga.Text,
                "Compra Exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Opcional: Limpiar el DataGridView local después de asentar la compra
            dgvCompras.Rows.Clear();
            contadorID = 1;
            ActualizarResumen();
        }

        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTeléfono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtPeso.Clear();
            txtPrecioKg.Clear();
            cmbMaterial.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvCompras.SelectedRows.Count > 0)
            {
                dgvCompras.Rows.RemoveAt(dgvCompras.SelectedRows[0].Index);
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
                ticket += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "\n\n";
                ticket += "DATOS DEL VENDEDOR\n";
                ticket += "-------------------------------------\n";
                ticket += "Nombre: " + txtNombreCompleto.Text + "\n";
                ticket += "Telefono: " + txtTeléfono.Text + "\n";
                ticket += "Direccion: " + txtDirección.Text + "\n";
                ticket += "MATERIALES RECIBIDOS\n";
                ticket += "-------------------------------------\n";

                foreach (DataGridViewRow fila in dgvCompras.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        ticket += "Material: " + fila.Cells[1].Value + "\n";
                        ticket += "Cantidad: " + fila.Cells[2].Value + "\n";
                        ticket += "Peso: " + fila.Cells[3].Value + " kg\n";
                        ticket += "Precio por kg: $" + fila.Cells[4].Value + "\n";
                        ticket += "Subtotal: $" + fila.Cells[5].Value + "\n";
                        ticket += "-------------------------------------\n";
                    }
                }

                ticket += "\nRESUMEN\n";
                ticket += "=====================================\n";
                ticket += "Total Articulos: " + lblTotalArti.Text + "\n";
                ticket += "Peso Total: " + lblPesoTot.Text + "\n";
                ticket += "Subtotal: " + lblSubtot.Text + "\n";
                ticket += "IVA: " + lblimpuest.Text + "\n";
                ticket += "TOTAL PAGADO: " + lblTotalPaga.Text + "\n";
                ticket += "\nGracias por reciclar con nosotros.";

                File.WriteAllText(guardar.FileName, ticket);
                MessageBox.Show("Ticket generado correctamente");
                Process.Start("notepad.exe", guardar.FileName);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"ReciboVenta_{nombre}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PdfWriter writer = new PdfWriter(saveFileDialog.FileName);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                document.Add(new Paragraph("===== COMPROBANTE DE VENTA ====="));
                document.Add(new Paragraph("\n"));
                document.Add(new Paragraph($"Nombre: {nombre}"));
                document.Add(new Paragraph($"Correo: {correo}"));
                document.Add(new Paragraph($"Teléfono: {telefono}"));
                document.Add(new Paragraph($"Alcaldia Seleccionada: {alcaldia}"));
                document.Add(new Paragraph($"Empresa Seleccionada: {seleccion}\n\n"));
                document.Add(new Paragraph("Productos vendidos (kilos):"));
                foreach (var item in productos)
                {
                    document.Add(new Paragraph($"- {item.Key}: {item.Value:F2} kg"));
                }
                document.Add(new Paragraph($"\nGanancia total: ${ganancia}"));
                document.Add(new Paragraph("\nGracias por su venta."));
                document.Close();

                MessageBox.Show("PDF del recibo generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    precio = cmbEstado.Text == "Funcional" ? 120 : cmbEstado.Text == "Dañado" ? 70 : 50;
                    break;
                case "Laptops":
                    precio = cmbEstado.Text == "Funcional" ? 200 : cmbEstado.Text == "Dañado" ? 120 : 80;
                    break;
                case "Tablets":
                    precio = cmbEstado.Text == "Funcional" ? 150 : cmbEstado.Text == "Dañado" ? 90 : 60;
                    break;
                case "Monitores":
                    precio = cmbEstado.Text == "Funcional" ? 80 : cmbEstado.Text == "Dañado" ? 50 : 30;
                    break;
                case "Tarjetas Electrónicas":
                    precio = cmbEstado.Text == "Funcional" ? 300 : cmbEstado.Text == "Dañado" ? 180 : 120;
                    break;
                case "Cables":
                    precio = cmbEstado.Text == "Funcional" ? 60 : cmbEstado.Text == "Dañado" ? 40 : 25;
                    break;
                case "Baterías":
                    precio = cmbEstado.Text == "Funcional" ? 90 : cmbEstado.Text == "Dañado" ? 60 : 40;
                    break;
                case "Computadoras de Escritorio":
                    precio = cmbEstado.Text == "Funcional" ? 250 : cmbEstado.Text == "Dañado" ? 150 : 100;
                    break;
                case "Impresoras":
                    precio = cmbEstado.Text == "Funcional" ? 100 : cmbEstado.Text == "Dañado" ? 60 : 40;
                    break;
                case "Discos Duros":
                    precio = cmbEstado.Text == "Funcional" ? 180 : cmbEstado.Text == "Dañado" ? 100 : 70;
                    break;
                case "Procesadores (CPU)":
                    precio = cmbEstado.Text == "Funcional" ? 400 : cmbEstado.Text == "Dañado" ? 250 : 180;
                    break;
                case "Memorias RAM":
                    precio = cmbEstado.Text == "Funcional" ? 150 : cmbEstado.Text == "Dañado" ? 90 : 60;
                    break;
                case "Escáneres":
                    precio = cmbEstado.Text == "Funcional" ? 90 : cmbEstado.Text == "Dañado" ? 50 : 35;
                    break;
                case "Teclados":
                    precio = cmbEstado.Text == "Funcional" ? 40 : cmbEstado.Text == "Dañado" ? 20 : 10;
                    break;
                case "Tarjetas de Video":
                    precio = cmbEstado.Text == "Funcional" ? 350 : cmbEstado.Text == "Dañado" ? 200 : 130;
                    break;
                case "Fuentes de Poder":
                    precio = cmbEstado.Text == "Funcional" ? 80 : cmbEstado.Text == "Dañado" ? 45 : 30;
                    break;
                case "Placas Base (Motherboards)":
                    precio = cmbEstado.Text == "Funcional" ? 280 : cmbEstado.Text == "Dañado" ? 160 : 100;
                    break;
                case "Unidades de CD/DVD":
                    precio = cmbEstado.Text == "Funcional" ? 50 : cmbEstado.Text == "Dañado" ? 25 : 15;
                    break;
                case "Mouse":
                    precio = cmbEstado.Text == "Funcional" ? 30 : cmbEstado.Text == "Dañado" ? 15 : 8;
                    break;
                case "Pantallas":
                    precio = cmbEstado.Text == "Funcional" ? 120 : cmbEstado.Text == "Dañado" ? 70 : 45;
                    break;
                case "Oro":
                    precio = cmbEstado.Text == "Funcional" ? 1500 : cmbEstado.Text == "Dañado" ? 1500 : 1500;
                    break;
                case "Plata":
                    precio = cmbEstado.Text == "Funcional" ? 800 : cmbEstado.Text == "Dañado" ? 800 : 800;
                    break;
                case "Cobre":
                    precio = cmbEstado.Text == "Funcional" ? 180 : cmbEstado.Text == "Dañado" ? 180 : 180;
                    break;
                case "Aluminio":
                    precio = cmbEstado.Text == "Funcional" ? 90 : cmbEstado.Text == "Dañado" ? 90 : 90;
                    break;
                case "Acero":
                    precio = cmbEstado.Text == "Funcional" ? 60 : cmbEstado.Text == "Dañado" ? 60 : 60;
                    break;
                case "Hierro":
                    precio = cmbEstado.Text == "Funcional" ? 50 : cmbEstado.Text == "Dañado" ? 50 : 50;
                    break;
                case "Bocinas":
                    precio = cmbEstado.Text == "Funcional" ? 70 : cmbEstado.Text == "Dañado" ? 40 : 25;
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
                MessageBox.Show("El teléfono debe tener exactamente 10 dígitos", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeléfono.Focus();
            }
        }

        private void btnRegresarMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

    }
}





