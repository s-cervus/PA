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
    public partial class uc_InventarioGeneral : UserControl
    {
        public uc_InventarioGeneral()
        {
            InitializeComponent();

            // Deja seleccionada la primera categoría por defecto para que no inicie vacío
            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;
        }

        private void LimpiarFormulario()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtStock.Clear();
            txtPrecio.Clear();
            cmbCategoria.SelectedIndex = 0;
            txtID.Focus(); // Deja el cursor listo en el ID para el siguiente registro
        }

        private void btnGuardarAlmacen_Click_1(object sender, EventArgs e)
        {
            // 1. VALIDACIÓN: Que el usuario no deje campos vacíos
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtStock.Text) || string.IsNullOrEmpty(txtPrecio.Text) ||
                cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Por favor, llena todos los campos para registrar la mercancía.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. VALIDACIÓN: Asegurar que el Stock sea un número entero real
            int stockNuevo;
            if (!int.TryParse(txtStock.Text.Trim(), out stockNuevo))
            {
                MessageBox.Show("El Stock debe ser un número entero válido (ej: 5, 10, 20).", "Error de Tipo de Dato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. FORMATO: Asegurar que el precio lleve su signo de pesos limpio
            string precioTexto = txtPrecio.Text.Trim();
            if (!precioTexto.StartsWith("$"))
            {
                precioTexto = "$ " + precioTexto;
            }

            // 4. INSERCIÓN VIVA: Ver qué categoría se eligió y mandarlo a la tabla global del FormEntrada
            string categoriaSeleccionada = cmbCategoria.SelectedItem.ToString();

            if (categoriaSeleccionada == "Laptops / PCs")
            {
                FormEntrada.TablaLaptops.Rows.Add(txtID.Text.Trim(), txtNombre.Text.Trim(), stockNuevo, precioTexto);
            }
            else if (categoriaSeleccionada == "Celulares")
            {
                FormEntrada.TablaCelulares.Rows.Add(txtID.Text.Trim(), txtNombre.Text.Trim(), stockNuevo, precioTexto);
            }
            else if (categoriaSeleccionada == "Componentes / Refacciones")
            {
                FormEntrada.TablaComponentes.Rows.Add(txtID.Text.Trim(), txtNombre.Text.Trim(), stockNuevo, precioTexto);
            }

            // === GUARDADO AUTOMÁTICO EN DISCO DURO ===
            // Guarda los nuevos productos físicamente en los archivos XML del sistema
            FormEntrada.GuardarInventarioEnDisco();

            // 5. ÉXITO: Avisar al usuario y limpiar los cuadros de texto
            MessageBox.Show("¡" + txtNombre.Text.Trim() + " dado de alta exitosamente en la sección de " + categoriaSeleccionada + "!", "Almacén Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }
    }
}