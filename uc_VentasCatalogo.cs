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
            // En cuanto carga la pantalla, enlazamos las tablas a las del Almacén Global
            CargarTablasDesdeAlmacen();
        }

        private void CargarTablasDesdeAlmacen()
        {
            // Jalamos las tablas vivas que viven en FormEntrada
            dgvLaptop.DataSource = PA.FormEntrada.TablaLaptops;
            dgvCelular.DataSource = PA.FormEntrada.TablaCelulares;
            dgvComponentes.DataSource = PA.FormEntrada.TablaComponentes;

            // 4. DATOS PARA MINERALES (Se queda igual por separado por ahora)
            if (dgvMinerales.DataSource == null)
            {
                DataTable dtMinerales = new DataTable();
                dtMinerales.Columns.Add("ID");
                dtMinerales.Columns.Add("Material/Metal");
                dtMinerales.Columns.Add("Peso Disponible");
                dtMinerales.Columns.Add("Precio x Kg");
                dgvMinerales.DataSource = dtMinerales;
            }
        }

        // --- BOTÓN PARA AGREGAR CELULARES ---
        private void btnAgregarVentaC_Click(object sender, EventArgs e)
        {
            if (dgvCelular.CurrentRow != null)
            {
                string id = dgvCelular.CurrentRow.Cells["ID"].Value.ToString();
                string nombre = dgvCelular.CurrentRow.Cells["Componente/Equipo"].Value.ToString();

                // 1. Obtener el stock físico real disponible en la tabla global
                int stockActual = Convert.ToInt32(dgvCelular.CurrentRow.Cells["Stock"].Value);

                // 2. Contar cuántas piezas de ESTE mismo ID ya se metieron al carrito provisionalmente
                int cantidadEnCarrito = 0;
                foreach (var item in PA.FormEntrada.Carrito)
                {
                    if (item.ID == id)
                    {
                        cantidadEnCarrito += item.Cantidad;
                    }
                }

                // 3. CANDADO: Si ya no hay stock o si lo que quieren agregar supera lo disponible
                if (stockActual <= 0 || (cantidadEnCarrito >= stockActual))
                {
                    MessageBox.Show("¡Alerta de Almacén! Ya no queda stock disponible de: " + nombre, "Producto Agotado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Frena el código en seco y no lo mete al carrito
                }

                string precioStr = dgvCelular.CurrentRow.Cells["Precio Pub"].Value.ToString();
                decimal precio = decimal.Parse(precioStr.Replace("$", "").Trim());

                ProductoCarrito nuevoItem = new ProductoCarrito()
                {
                    ID = id,
                    Descripcion = nombre,
                    Cantidad = 1,
                    Precio = precio
                };

                PA.FormEntrada.Carrito.Add(nuevoItem);
                MessageBox.Show(nombre + " agregado a la venta, carnal.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un celular de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- BOTÓN PARA AGREGAR LAPTOPS ---
        private void btnAgregarVentaL_Click(object sender, EventArgs e)
        {
            if (dgvLaptop.CurrentRow != null)
            {
                string id = dgvLaptop.CurrentRow.Cells["ID"].Value.ToString();
                string nombre = dgvLaptop.CurrentRow.Cells["Componente/Equipo"].Value.ToString();

                // 1. Obtener el stock físico real disponible en la tabla global
                int stockActual = Convert.ToInt32(dgvLaptop.CurrentRow.Cells["Stock"].Value);

                // 2. Contar cuántas piezas de ESTE mismo ID ya se metieron al carrito provisionalmente
                int cantidadEnCarrito = 0;
                foreach (var item in PA.FormEntrada.Carrito)
                {
                    if (item.ID == id)
                    {
                        cantidadEnCarrito += item.Cantidad;
                    }
                }

                // 3. CANDADO: Si ya no hay stock o si lo que quieren agregar supera lo disponible
                if (stockActual <= 0 || (cantidadEnCarrito >= stockActual))
                {
                    MessageBox.Show("¡Alerta de Almacén! Ya no queda stock disponible de: " + nombre, "Producto Agotado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Frena el código en seco y no lo mete al carrito
                }

                string precioStr = dgvLaptop.CurrentRow.Cells["Precio Pub"].Value.ToString();
                decimal precio = decimal.Parse(precioStr.Replace("$", "").Trim());

                ProductoCarrito nuevoItem = new ProductoCarrito()
                {
                    ID = id,
                    Descripcion = nombre,
                    Cantidad = 1,
                    Precio = precio
                };

                PA.FormEntrada.Carrito.Add(nuevoItem);
                MessageBox.Show(nombre + " agregado a la venta, carnal.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una laptop de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}