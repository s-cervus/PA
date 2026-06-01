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

            // ¡CORREGIDO!: Enlazamos directamente la tabla global real de Minerales
            dgvMinerales.DataSource = PA.FormEntrada.TablaMinerales;
        }

        // =========================================================================
        // --- BOTÓN PARA AGREGAR CELULARES ---
        // =========================================================================
        private void btnAgregarVentaC_Click(object sender, EventArgs e)
        {
            if (dgvCelular.CurrentRow != null)
            {
                string id = dgvCelular.CurrentRow.Cells["ID"].Value.ToString();
                string nombre = dgvCelular.CurrentRow.Cells["Componente/Equipo"].Value.ToString();

                int stockActual = Convert.ToInt32(dgvCelular.CurrentRow.Cells["Stock"].Value);

                int cantidadEnCarrito = 0;
                foreach (var item in PA.FormEntrada.Carrito)
                {
                    if (item.ID == id) { cantidadEnCarrito += item.Cantidad; }
                }

                if (stockActual <= 0 || (cantidadEnCarrito >= stockActual))
                {
                    MessageBox.Show("¡Alerta de Almacén! Ya no queda stock disponible de: " + nombre, "Producto Agotado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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

        // =========================================================================
        // --- BOTÓN PARA AGREGAR LAPTOPS ---
        // =========================================================================
        private void btnAgregarVentaL_Click(object sender, EventArgs e)
        {
            if (dgvLaptop.CurrentRow != null)
            {
                string id = dgvLaptop.CurrentRow.Cells["ID"].Value.ToString();
                string nombre = dgvLaptop.CurrentRow.Cells["Componente/Equipo"].Value.ToString();

                int stockActual = Convert.ToInt32(dgvLaptop.CurrentRow.Cells["Stock"].Value);

                int cantidadEnCarrito = 0;
                foreach (var item in PA.FormEntrada.Carrito)
                {
                    if (item.ID == id) { cantidadEnCarrito += item.Cantidad; }
                }

                if (stockActual <= 0 || (cantidadEnCarrito >= stockActual))
                {
                    MessageBox.Show("¡Alerta de Almacén! Ya no queda stock disponible de: " + nombre, "Producto Agotado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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

        // =========================================================================
        // ¡NUEVO! --- BOTÓN PARA AGREGAR COMPONENTES / REFACCIONES ---
        // =========================================================================
        private void btnAgregarVentaCR_Click(object sender, EventArgs e)
        {
            if (dgvComponentes.CurrentRow != null)
            {
                string id = dgvComponentes.CurrentRow.Cells["ID"].Value.ToString();
                string nombre = dgvComponentes.CurrentRow.Cells["Componente/Equipo"].Value.ToString();

                // Validamos el stock real en la tabla de refacciones
                int stockActual = Convert.ToInt32(dgvComponentes.CurrentRow.Cells["Stock"].Value);

                int cantidadEnCarrito = 0;
                foreach (var item in PA.FormEntrada.Carrito)
                {
                    if (item.ID == id) { cantidadEnCarrito += item.Cantidad; }
                }

                if (stockActual <= 0 || (cantidadEnCarrito >= stockActual))
                {
                    MessageBox.Show("¡Alerta de Almacén! Ya no quedan refacciones disponibles de: " + nombre, "Producto Agotado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string precioStr = dgvComponentes.CurrentRow.Cells["Precio Pub"].Value.ToString();
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
                MessageBox.Show("Por favor, selecciona una refacción de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // =========================================================================
        // ¡NUEVO! --- BOTÓN PARA AGREGAR MINERALES ---
        // =========================================================================
        private void btnAgregarVentaM_Click(object sender, EventArgs e)
        {
            if (dgvMinerales.CurrentRow != null)
            {
                string id = dgvMinerales.CurrentRow.Cells["ID"].Value.ToString();
                string nombre = dgvMinerales.CurrentRow.Cells["Componente/Equipo"].Value.ToString();

                // Validamos el stock/peso disponible en la tabla de minerales
                int stockActual = Convert.ToInt32(dgvMinerales.CurrentRow.Cells["Stock"].Value);

                int cantidadEnCarrito = 0;
                foreach (var item in PA.FormEntrada.Carrito)
                {
                    if (item.ID == id) { cantidadEnCarrito += item.Cantidad; }
                }

                if (stockActual <= 0 || (cantidadEnCarrito >= stockActual))
                {
                    MessageBox.Show("¡Alerta de Almacén! Ya no queda peso/material disponible de: " + nombre, "Material Agotado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string precioStr = dgvMinerales.CurrentRow.Cells["Precio Pub"].Value.ToString();
                decimal precio = decimal.Parse(precioStr.Replace("$", "").Trim());

                ProductoCarrito nuevoItem = new ProductoCarrito()
                {
                    ID = id,
                    Descripcion = nombre,
                    Cantidad = 1,
                    Precio = precio
                };

                PA.FormEntrada.Carrito.Add(nuevoItem);
                MessageBox.Show(nombre + " agregado a la venta correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un material de la tabla de minerales primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}