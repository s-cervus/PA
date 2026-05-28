namespace PA
{
    partial class FormSalida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxSecciónProveedor = new System.Windows.Forms.GroupBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtDirección = new System.Windows.Forms.TextBox();
            this.lblDirección = new System.Windows.Forms.Label();
            this.lblTeléfono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.gbxSecciónDetalles = new System.Windows.Forms.GroupBox();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.CArtículos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecioporKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brnAñadirCompra = new System.Windows.Forms.Button();
            this.txtCantidadPeso = new System.Windows.Forms.TextBox();
            this.lblCantidadPeso = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblArtículo = new System.Windows.Forms.Label();
            this.cmbArtículo = new System.Windows.Forms.ComboBox();
            this.gpbTotales = new System.Windows.Forms.GroupBox();
            this.txtTotalCobrar = new System.Windows.Forms.TextBox();
            this.txtTotalPeso = new System.Windows.Forms.TextBox();
            this.txtTotalArtículos = new System.Windows.Forms.TextBox();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoCobro = new System.Windows.Forms.Label();
            this.lblTotalCobrar = new System.Windows.Forms.Label();
            this.lblTotalPeso = new System.Windows.Forms.Label();
            this.lblTotalArtículos = new System.Windows.Forms.Label();
            this.BtnConfirmarVenta = new System.Windows.Forms.Button();
            this.btnLimpiarFormulario = new System.Windows.Forms.Button();
            this.gbxSecciónProveedor.SuspendLayout();
            this.gbxSecciónDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.gpbTotales.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSecciónProveedor
            // 
            this.gbxSecciónProveedor.Controls.Add(this.btnBuscarCliente);
            this.gbxSecciónProveedor.Controls.Add(this.txtDirección);
            this.gbxSecciónProveedor.Controls.Add(this.lblDirección);
            this.gbxSecciónProveedor.Controls.Add(this.lblTeléfono);
            this.gbxSecciónProveedor.Controls.Add(this.txtTelefono);
            this.gbxSecciónProveedor.Controls.Add(this.txtNombreEmpresa);
            this.gbxSecciónProveedor.Controls.Add(this.label1);
            this.gbxSecciónProveedor.Location = new System.Drawing.Point(37, 55);
            this.gbxSecciónProveedor.Name = "gbxSecciónProveedor";
            this.gbxSecciónProveedor.Size = new System.Drawing.Size(529, 107);
            this.gbxSecciónProveedor.TabIndex = 0;
            this.gbxSecciónProveedor.TabStop = false;
            this.gbxSecciónProveedor.Text = "Sección de proveedor";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(323, 50);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(167, 23);
            this.btnBuscarCliente.TabIndex = 6;
            this.btnBuscarCliente.Text = "Buscar cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // txtDirección
            // 
            this.txtDirección.Location = new System.Drawing.Point(360, 17);
            this.txtDirección.Name = "txtDirección";
            this.txtDirección.Size = new System.Drawing.Size(130, 20);
            this.txtDirección.TabIndex = 5;
            // 
            // lblDirección
            // 
            this.lblDirección.AutoSize = true;
            this.lblDirección.Location = new System.Drawing.Point(302, 20);
            this.lblDirección.Name = "lblDirección";
            this.lblDirección.Size = new System.Drawing.Size(55, 13);
            this.lblDirección.TabIndex = 4;
            this.lblDirección.Text = "Dirección:";
            // 
            // lblTeléfono
            // 
            this.lblTeléfono.AutoSize = true;
            this.lblTeléfono.Location = new System.Drawing.Point(9, 55);
            this.lblTeléfono.Name = "lblTeléfono";
            this.lblTeléfono.Size = new System.Drawing.Size(52, 13);
            this.lblTeléfono.TabIndex = 3;
            this.lblTeléfono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(149, 52);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(116, 20);
            this.txtTelefono.TabIndex = 2;
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Location = new System.Drawing.Point(149, 16);
            this.txtNombreEmpresa.Multiline = true;
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(116, 21);
            this.txtNombreEmpresa.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre completo/Empresa:";
            // 
            // dtpFechaCompra
            // 
            this.dtpFechaCompra.Location = new System.Drawing.Point(597, 12);
            this.dtpFechaCompra.Name = "dtpFechaCompra";
            this.dtpFechaCompra.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaCompra.TabIndex = 1;
            // 
            // gbxSecciónDetalles
            // 
            this.gbxSecciónDetalles.Controls.Add(this.dgvDetalles);
            this.gbxSecciónDetalles.Controls.Add(this.brnAñadirCompra);
            this.gbxSecciónDetalles.Controls.Add(this.txtCantidadPeso);
            this.gbxSecciónDetalles.Controls.Add(this.lblCantidadPeso);
            this.gbxSecciónDetalles.Controls.Add(this.cmbEstado);
            this.gbxSecciónDetalles.Controls.Add(this.lblEstado);
            this.gbxSecciónDetalles.Controls.Add(this.lblArtículo);
            this.gbxSecciónDetalles.Controls.Add(this.cmbArtículo);
            this.gbxSecciónDetalles.Location = new System.Drawing.Point(37, 183);
            this.gbxSecciónDetalles.Name = "gbxSecciónDetalles";
            this.gbxSecciónDetalles.Size = new System.Drawing.Size(863, 184);
            this.gbxSecciónDetalles.TabIndex = 2;
            this.gbxSecciónDetalles.TabStop = false;
            this.gbxSecciónDetalles.Text = "Sección de detalles de artículos ";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CArtículos,
            this.CCantidad,
            this.CEstado,
            this.CPeso,
            this.CPrecioporKg,
            this.CSubtotal,
            this.CIva,
            this.CTotal});
            this.dgvDetalles.Location = new System.Drawing.Point(21, 66);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.Size = new System.Drawing.Size(842, 86);
            this.dgvDetalles.TabIndex = 7;
            // 
            // CArtículos
            // 
            this.CArtículos.HeaderText = "Artículos:";
            this.CArtículos.Name = "CArtículos";
            // 
            // CCantidad
            // 
            this.CCantidad.HeaderText = "Cantidad:";
            this.CCantidad.Name = "CCantidad";
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado (Dañado o No):";
            this.CEstado.Name = "CEstado";
            // 
            // CPeso
            // 
            this.CPeso.HeaderText = "Peso (Kg)";
            this.CPeso.Name = "CPeso";
            // 
            // CPrecioporKg
            // 
            this.CPrecioporKg.HeaderText = "Precio por Kg";
            this.CPrecioporKg.Name = "CPrecioporKg";
            // 
            // CSubtotal
            // 
            this.CSubtotal.HeaderText = "Subtotal";
            this.CSubtotal.Name = "CSubtotal";
            // 
            // CIva
            // 
            this.CIva.HeaderText = "IVA 16%";
            this.CIva.Name = "CIva";
            // 
            // CTotal
            // 
            this.CTotal.HeaderText = "Total";
            this.CTotal.Name = "CTotal";
            // 
            // brnAñadirCompra
            // 
            this.brnAñadirCompra.Location = new System.Drawing.Point(629, 16);
            this.brnAñadirCompra.Name = "brnAñadirCompra";
            this.brnAñadirCompra.Size = new System.Drawing.Size(122, 23);
            this.brnAñadirCompra.TabIndex = 6;
            this.brnAñadirCompra.Text = "Añadir a la compra";
            this.brnAñadirCompra.UseVisualStyleBackColor = true;
            // 
            // txtCantidadPeso
            // 
            this.txtCantidadPeso.Location = new System.Drawing.Point(506, 19);
            this.txtCantidadPeso.Name = "txtCantidadPeso";
            this.txtCantidadPeso.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadPeso.TabIndex = 5;
            // 
            // lblCantidadPeso
            // 
            this.lblCantidadPeso.AutoSize = true;
            this.lblCantidadPeso.Location = new System.Drawing.Point(418, 20);
            this.lblCantidadPeso.Name = "lblCantidadPeso";
            this.lblCantidadPeso.Size = new System.Drawing.Size(81, 13);
            this.lblCantidadPeso.TabIndex = 4;
            this.lblCantidadPeso.Text = "Cantidad/Peso:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(271, 16);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbEstado.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(222, 19);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado:";
            // 
            // lblArtículo
            // 
            this.lblArtículo.AutoSize = true;
            this.lblArtículo.Location = new System.Drawing.Point(12, 19);
            this.lblArtículo.Name = "lblArtículo";
            this.lblArtículo.Size = new System.Drawing.Size(47, 13);
            this.lblArtículo.TabIndex = 1;
            this.lblArtículo.Text = "Artículo:";
            // 
            // cmbArtículo
            // 
            this.cmbArtículo.FormattingEnabled = true;
            this.cmbArtículo.Items.AddRange(new object[] {
            "Teléfonos"});
            this.cmbArtículo.Location = new System.Drawing.Point(75, 16);
            this.cmbArtículo.Name = "cmbArtículo";
            this.cmbArtículo.Size = new System.Drawing.Size(121, 21);
            this.cmbArtículo.TabIndex = 0;
            // 
            // gpbTotales
            // 
            this.gpbTotales.Controls.Add(this.txtTotalCobrar);
            this.gpbTotales.Controls.Add(this.txtTotalPeso);
            this.gpbTotales.Controls.Add(this.txtTotalArtículos);
            this.gpbTotales.Controls.Add(this.cmbMetodoPago);
            this.gpbTotales.Controls.Add(this.lblMetodoCobro);
            this.gpbTotales.Controls.Add(this.lblTotalCobrar);
            this.gpbTotales.Controls.Add(this.lblTotalPeso);
            this.gpbTotales.Controls.Add(this.lblTotalArtículos);
            this.gpbTotales.Location = new System.Drawing.Point(37, 394);
            this.gpbTotales.Name = "gpbTotales";
            this.gpbTotales.Size = new System.Drawing.Size(644, 100);
            this.gpbTotales.TabIndex = 3;
            this.gpbTotales.TabStop = false;
            this.gpbTotales.Text = "Totales";
            // 
            // txtTotalCobrar
            // 
            this.txtTotalCobrar.Location = new System.Drawing.Point(341, 49);
            this.txtTotalCobrar.Name = "txtTotalCobrar";
            this.txtTotalCobrar.Size = new System.Drawing.Size(90, 20);
            this.txtTotalCobrar.TabIndex = 7;
            // 
            // txtTotalPeso
            // 
            this.txtTotalPeso.Location = new System.Drawing.Point(225, 47);
            this.txtTotalPeso.Name = "txtTotalPeso";
            this.txtTotalPeso.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPeso.TabIndex = 6;
            // 
            // txtTotalArtículos
            // 
            this.txtTotalArtículos.Location = new System.Drawing.Point(15, 48);
            this.txtTotalArtículos.Name = "txtTotalArtículos";
            this.txtTotalArtículos.Size = new System.Drawing.Size(100, 20);
            this.txtTotalArtículos.TabIndex = 5;
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(450, 48);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(121, 21);
            this.cmbMetodoPago.TabIndex = 4;
            // 
            // lblMetodoCobro
            // 
            this.lblMetodoCobro.AutoSize = true;
            this.lblMetodoCobro.Location = new System.Drawing.Point(464, 32);
            this.lblMetodoCobro.Name = "lblMetodoCobro";
            this.lblMetodoCobro.Size = new System.Drawing.Size(88, 13);
            this.lblMetodoCobro.TabIndex = 3;
            this.lblMetodoCobro.Text = "Método a cobrar:";
            // 
            // lblTotalCobrar
            // 
            this.lblTotalCobrar.AutoSize = true;
            this.lblTotalCobrar.Location = new System.Drawing.Point(354, 30);
            this.lblTotalCobrar.Name = "lblTotalCobrar";
            this.lblTotalCobrar.Size = new System.Drawing.Size(77, 13);
            this.lblTotalCobrar.TabIndex = 2;
            this.lblTotalCobrar.Text = "Total a Cobrar:";
            // 
            // lblTotalPeso
            // 
            this.lblTotalPeso.AutoSize = true;
            this.lblTotalPeso.Location = new System.Drawing.Point(221, 30);
            this.lblTotalPeso.Name = "lblTotalPeso";
            this.lblTotalPeso.Size = new System.Drawing.Size(94, 13);
            this.lblTotalPeso.TabIndex = 1;
            this.lblTotalPeso.Text = "Total de peso (Kg)";
            // 
            // lblTotalArtículos
            // 
            this.lblTotalArtículos.AutoSize = true;
            this.lblTotalArtículos.Location = new System.Drawing.Point(12, 31);
            this.lblTotalArtículos.Name = "lblTotalArtículos";
            this.lblTotalArtículos.Size = new System.Drawing.Size(202, 13);
            this.lblTotalArtículos.TabIndex = 0;
            this.lblTotalArtículos.Text = "Total de artículos vendidos a la empresa:";
            // 
            // BtnConfirmarVenta
            // 
            this.BtnConfirmarVenta.Location = new System.Drawing.Point(298, 522);
            this.BtnConfirmarVenta.Name = "BtnConfirmarVenta";
            this.BtnConfirmarVenta.Size = new System.Drawing.Size(170, 40);
            this.BtnConfirmarVenta.TabIndex = 4;
            this.BtnConfirmarVenta.Text = "Confirmar venta";
            this.BtnConfirmarVenta.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarFormulario
            // 
            this.btnLimpiarFormulario.Location = new System.Drawing.Point(487, 522);
            this.btnLimpiarFormulario.Name = "btnLimpiarFormulario";
            this.btnLimpiarFormulario.Size = new System.Drawing.Size(170, 40);
            this.btnLimpiarFormulario.TabIndex = 5;
            this.btnLimpiarFormulario.Text = "Limpiar formulario";
            this.btnLimpiarFormulario.UseVisualStyleBackColor = true;
            // 
            // FormSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 626);
            this.Controls.Add(this.btnLimpiarFormulario);
            this.Controls.Add(this.BtnConfirmarVenta);
            this.Controls.Add(this.gpbTotales);
            this.Controls.Add(this.gbxSecciónDetalles);
            this.Controls.Add(this.dtpFechaCompra);
            this.Controls.Add(this.gbxSecciónProveedor);
            this.Name = "FormSalida";
            this.Text = "Compra";
            this.gbxSecciónProveedor.ResumeLayout(false);
            this.gbxSecciónProveedor.PerformLayout();
            this.gbxSecciónDetalles.ResumeLayout(false);
            this.gbxSecciónDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.gpbTotales.ResumeLayout(false);
            this.gpbTotales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSecciónProveedor;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombreEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTeléfono;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtDirección;
        private System.Windows.Forms.Label lblDirección;
        private System.Windows.Forms.GroupBox gbxSecciónDetalles;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblArtículo;
        private System.Windows.Forms.ComboBox cmbArtículo;
        private System.Windows.Forms.Button brnAñadirCompra;
        private System.Windows.Forms.TextBox txtCantidadPeso;
        private System.Windows.Forms.Label lblCantidadPeso;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn CArtículos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPeso;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecioporKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTotal;
        private System.Windows.Forms.GroupBox gpbTotales;
        private System.Windows.Forms.Label lblTotalArtículos;
        private System.Windows.Forms.Label lblMetodoCobro;
        private System.Windows.Forms.Label lblTotalCobrar;
        private System.Windows.Forms.Label lblTotalPeso;
        private System.Windows.Forms.TextBox txtTotalPeso;
        private System.Windows.Forms.TextBox txtTotalArtículos;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Button BtnConfirmarVenta;
        private System.Windows.Forms.TextBox txtTotalCobrar;
        private System.Windows.Forms.Button btnLimpiarFormulario;
    }
}