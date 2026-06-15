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
            // 1. VALIDACIÓN BÁSICA: El ID y el Stock son obligatorios siempre
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("Para surtir o registrar, necesitas mínimo el ID del producto y el Stock Nuevo.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. VALIDACIÓN: Asegurar que el Stock sea un número entero real
            int stockIngresado;
            if (!int.TryParse(txtStock.Text.Trim(), out stockIngresado))
            {
                MessageBox.Show("El Stock debe ser un número entero válido (ej: 5, 10, 20).", "Error de Tipo de Dato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idBuscar = txtID.Text.Trim();
            bool productoEncontrado = false;
            string nombreProductoModificado = "";

            // =========================================================================
            // MODO SURTIDO AUTOMÁTICO: Buscar si el ID ya existe en alguna tabla
            // =========================================================================

            // Buscar en Laptops
            foreach (DataRow fila in FormEntrada.TablaLaptops.Rows)
            {
                if (fila["ID"].ToString() == idBuscar)
                {
                    int stockActual = Convert.ToInt32(fila["Stock"]);
                    fila["Stock"] = stockActual + stockIngresado;
                    nombreProductoModificado = fila["Componente/Equipo"].ToString();
                    productoEncontrado = true;
                    break;
                }
            }

            // Buscar en Celulares
            if (!productoEncontrado)
            {
                foreach (DataRow fila in FormEntrada.TablaCelulares.Rows)
                {
                    if (fila["ID"].ToString() == idBuscar)
                    {
                        int stockActual = Convert.ToInt32(fila["Stock"]);
                        fila["Stock"] = stockActual + stockIngresado;
                        nombreProductoModificado = fila["Componente/Equipo"].ToString();
                        productoEncontrado = true;
                        break;
                    }
                }
            }

            // Buscar en Componentes / Refacciones
            if (!productoEncontrado)
            {
                foreach (DataRow fila in FormEntrada.TablaComponentes.Rows)
                {
                    if (fila["ID"].ToString() == idBuscar)
                    {
                        int stockActual = Convert.ToInt32(fila["Stock"]);
                        fila["Stock"] = stockActual + stockIngresado;
                        nombreProductoModificado = fila["Componente/Equipo"].ToString();
                        productoEncontrado = true;
                        break;
                    }
                }
            }

            // ¡NUEVO! Buscar en Minerales
            if (!productoEncontrado)
            {
                foreach (DataRow fila in FormEntrada.TablaMinerales.Rows)
                {
                    if (fila["ID"].ToString() == idBuscar)
                    {
                        int stockActual = Convert.ToInt32(fila["Stock"]);
                        fila["Stock"] = stockActual + stockIngresado;
                        nombreProductoModificado = fila["Componente/Equipo"].ToString();
                        productoEncontrado = true;
                        break;
                    }
                }
            }

            // =========================================================================
            // MODO REGISTRO NUEVO
            // =========================================================================
            if (!productoEncontrado)
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtPrecio.Text) || cmbCategoria.SelectedItem == null)
                {
                    MessageBox.Show("Ese ID es nuevo. Por favor llena el Nombre, Precio y Categoría para darlo de alta por primera vez.", "Faltan datos de producto nuevo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string precioTexto = txtPrecio.Text.Trim();
                if (!precioTexto.StartsWith("$"))
                {
                    precioTexto = "$ " + precioTexto;
                }

                string categoriaSeleccionada = cmbCategoria.SelectedItem.ToString();
                nombreProductoModificado = txtNombre.Text.Trim();

                if (categoriaSeleccionada == "Laptops / PCs")
                {
                    FormEntrada.TablaLaptops.Rows.Add(idBuscar, nombreProductoModificado, stockIngresado, precioTexto);
                }
                else if (categoriaSeleccionada == "Celulares")
                {
                    FormEntrada.TablaCelulares.Rows.Add(idBuscar, nombreProductoModificado, stockIngresado, precioTexto);
                }
                else if (categoriaSeleccionada == "Componentes / Refacciones")
                {
                    FormEntrada.TablaComponentes.Rows.Add(idBuscar, nombreProductoModificado, stockIngresado, precioTexto);
                }
                else if (categoriaSeleccionada == "Minerales") // <-- ¡NUEVO!
                {
                    FormEntrada.TablaMinerales.Rows.Add(idBuscar, nombreProductoModificado, stockIngresado, precioTexto);
                }

                MessageBox.Show("¡" + nombreProductoModificado + " registrado como NUEVO producto con éxito!", "Alta de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("¡Stock actualizado! Se agregaron " + stockIngresado + " piezas a '" + nombreProductoModificado + "'.", "Surtido de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            FormEntrada.GuardarInventarioEnDisco();
            LimpiarFormulario();
        }

        // =========================================================================
        // EVENTO: ELIMINACIÓN FÍSICA DE PRODUCTOS DESDE EL XML (CON SOPORTE DE MINERALES)
        // =========================================================================
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Por favor, escribe el ID del producto que deseas eliminar definitivamente.", "Falta ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idEliminar = txtID.Text.Trim();
            bool borradoExitoso = false;
            string nombreBorrado = "";

            DialogResult respuesta = MessageBox.Show("¿Estás seguro de que quieres dar de baja el producto con ID: " + idEliminar + " del catálogo general?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No) return;

            // 1. Buscar y borrar en TablaLaptops
            for (int i = 0; i < FormEntrada.TablaLaptops.Rows.Count; i++)
            {
                if (FormEntrada.TablaLaptops.Rows[i]["ID"].ToString() == idEliminar)
                {
                    nombreBorrado = FormEntrada.TablaLaptops.Rows[i]["Componente/Equipo"].ToString();
                    FormEntrada.TablaLaptops.Rows[i].Delete();
                    borradoExitoso = true;
                    break;
                }
            }

            // 2. Buscar y borrar en TablaCelulares
            if (!borradoExitoso)
            {
                for (int i = 0; i < FormEntrada.TablaCelulares.Rows.Count; i++)
                {
                    if (FormEntrada.TablaCelulares.Rows[i]["ID"].ToString() == idEliminar)
                    {
                        nombreBorrado = FormEntrada.TablaCelulares.Rows[i]["Componente/Equipo"].ToString();
                        FormEntrada.TablaCelulares.Rows[i].Delete();
                        borradoExitoso = true;
                        break;
                    }
                }
            }

            // 3. Buscar y borrar en TablaComponentes
            if (!borradoExitoso)
            {
                for (int i = 0; i < FormEntrada.TablaComponentes.Rows.Count; i++)
                {
                    if (FormEntrada.TablaComponentes.Rows[i]["ID"].ToString() == idEliminar)
                    {
                        nombreBorrado = FormEntrada.TablaComponentes.Rows[i]["Componente/Equipo"].ToString();
                        FormEntrada.TablaComponentes.Rows[i].Delete();
                        borradoExitoso = true;
                        break;
                    }
                }
            }

            // 4. ¡NUEVO! Buscar y borrar en TablaMinerales
            if (!borradoExitoso)
            {
                for (int i = 0; i < FormEntrada.TablaMinerales.Rows.Count; i++)
                {
                    if (FormEntrada.TablaMinerales.Rows[i]["ID"].ToString() == idEliminar)
                    {
                        nombreBorrado = FormEntrada.TablaMinerales.Rows[i]["Componente/Equipo"].ToString();
                        FormEntrada.TablaMinerales.Rows[i].Delete();
                        borradoExitoso = true;
                        break;
                    }
                }
            }

            // 5. RESPUESTA Y ACTUALIZACIÓN EN DISCO
            if (borradoExitoso)
            {
                FormEntrada.TablaLaptops.AcceptChanges();
                FormEntrada.TablaCelulares.AcceptChanges();
                FormEntrada.TablaComponentes.AcceptChanges();
                FormEntrada.TablaMinerales.AcceptChanges(); // <-- ¡NUEVO!

                FormEntrada.GuardarInventarioEnDisco();

                MessageBox.Show("¡El producto '" + nombreBorrado + "' (ID: " + idEliminar + ") fue eliminado exitosamente del sistema!", "Catálogo Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("No se encontró ningún producto registrado con el ID: " + idEliminar + ".", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}