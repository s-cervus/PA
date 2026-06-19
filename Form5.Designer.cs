namespace PA
{
    partial class FormCompra
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSistemaReciclaje = new System.Windows.Forms.Label();
            this.grpDatosVendedor = new System.Windows.Forms.GroupBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTeléfono = new System.Windows.Forms.TextBox();
            this.lblTeléfono = new System.Windows.Forms.Label();
            this.txtDirección = new System.Windows.Forms.TextBox();
            this.lblDirección = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDatosVendedor = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grpDetalleMaterial = new System.Windows.Forms.GroupBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstadoEquipo = new System.Windows.Forms.Label();
            this.txtPrecioKg = new System.Windows.Forms.TextBox();
            this.lblPrecioporKg = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidadPiezas = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblTipoMaterial = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblResumenCompra = new System.Windows.Forms.Label();
            this.grpResumenCompra = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalArti = new System.Windows.Forms.Label();
            this.lblTotalPaga = new System.Windows.Forms.Label();
            this.lblimpuest = new System.Windows.Forms.Label();
            this.lblSubtot = new System.Windows.Forms.Label();
            this.lblPesoTot = new System.Windows.Forms.Label();
            this.lblTotalArtículos = new System.Windows.Forms.Label();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTipoMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrecioKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnRegresarMenu = new System.Windows.Forms.Button();
            this.btnTicket = new System.Windows.Forms.Button();
            this.grpDatosVendedor.SuspendLayout();
            this.grpDetalleMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpResumenCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSistemaReciclaje
            // 
            this.lblSistemaReciclaje.AutoSize = true;
            this.lblSistemaReciclaje.BackColor = System.Drawing.Color.Transparent;
            this.lblSistemaReciclaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSistemaReciclaje.Location = new System.Drawing.Point(260, 9);
            this.lblSistemaReciclaje.Name = "lblSistemaReciclaje";
            this.lblSistemaReciclaje.Size = new System.Drawing.Size(251, 29);
            this.lblSistemaReciclaje.TabIndex = 4;
            this.lblSistemaReciclaje.Text = "Sistema de reciclaje";
            // 
            // grpDatosVendedor
            // 
            this.grpDatosVendedor.BackColor = System.Drawing.Color.Transparent;
            this.grpDatosVendedor.Controls.Add(this.txtEdad);
            this.grpDatosVendedor.Controls.Add(this.label2);
            this.grpDatosVendedor.Controls.Add(this.txtTeléfono);
            this.grpDatosVendedor.Controls.Add(this.lblTeléfono);
            this.grpDatosVendedor.Controls.Add(this.txtDirección);
            this.grpDatosVendedor.Controls.Add(this.lblDirección);
            this.grpDatosVendedor.Controls.Add(this.txtNombreCompleto);
            this.grpDatosVendedor.Controls.Add(this.lblNombre);
            this.grpDatosVendedor.Location = new System.Drawing.Point(166, 109);
            this.grpDatosVendedor.Name = "grpDatosVendedor";
            this.grpDatosVendedor.Size = new System.Drawing.Size(284, 231);
            this.grpDatosVendedor.TabIndex = 5;
            this.grpDatosVendedor.TabStop = false;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(10, 173);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(264, 20);
            this.txtEdad.TabIndex = 7;
            this.txtEdad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEdad_KeyPress);
            this.txtEdad.Leave += new System.EventHandler(this.txtEdad_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Edad:";
            // 
            // txtTeléfono
            // 
            this.txtTeléfono.Location = new System.Drawing.Point(10, 134);
            this.txtTeléfono.MaxLength = 10;
            this.txtTeléfono.Name = "txtTeléfono";
            this.txtTeléfono.Size = new System.Drawing.Size(264, 20);
            this.txtTeléfono.TabIndex = 5;
            this.txtTeléfono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTeléfono_KeyPress);
            this.txtTeléfono.Leave += new System.EventHandler(this.txtTeléfono_Leave);
            // 
            // lblTeléfono
            // 
            this.lblTeléfono.AutoSize = true;
            this.lblTeléfono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeléfono.Location = new System.Drawing.Point(10, 118);
            this.lblTeléfono.Name = "lblTeléfono";
            this.lblTeléfono.Size = new System.Drawing.Size(61, 13);
            this.lblTeléfono.TabIndex = 4;
            this.lblTeléfono.Text = "Teléfono:";
            // 
            // txtDirección
            // 
            this.txtDirección.Location = new System.Drawing.Point(10, 86);
            this.txtDirección.Name = "txtDirección";
            this.txtDirección.Size = new System.Drawing.Size(264, 20);
            this.txtDirección.TabIndex = 3;
            // 
            // lblDirección
            // 
            this.lblDirección.AutoSize = true;
            this.lblDirección.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirección.Location = new System.Drawing.Point(10, 70);
            this.lblDirección.Name = "lblDirección";
            this.lblDirección.Size = new System.Drawing.Size(65, 13);
            this.lblDirección.TabIndex = 2;
            this.lblDirección.Text = "Dirección:";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(10, 47);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(264, 20);
            this.txtNombreCompleto.TabIndex = 1;
            this.txtNombreCompleto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreCompleto_KeyPress);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(7, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(109, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre completo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(167, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "🛒 Compra de residuos electrónicos a partículares";
            // 
            // lblDatosVendedor
            // 
            this.lblDatosVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDatosVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosVendedor.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblDatosVendedor.Location = new System.Drawing.Point(172, 109);
            this.lblDatosVendedor.Name = "lblDatosVendedor";
            this.lblDatosVendedor.Size = new System.Drawing.Size(285, 23);
            this.lblDatosVendedor.TabIndex = 7;
            this.lblDatosVendedor.Text = "   👤 Datos del vendedor";
            this.lblDatosVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(182, 357);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(99, 30);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "+ Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(297, 357);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(99, 30);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "🗑 Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Gold;
            this.btnLimpiar.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(411, 357);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(99, 30);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "🖌 Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // grpDetalleMaterial
            // 
            this.grpDetalleMaterial.Controls.Add(this.cmbEstado);
            this.grpDetalleMaterial.Controls.Add(this.lblEstadoEquipo);
            this.grpDetalleMaterial.Controls.Add(this.txtPrecioKg);
            this.grpDetalleMaterial.Controls.Add(this.lblPrecioporKg);
            this.grpDetalleMaterial.Controls.Add(this.txtPeso);
            this.grpDetalleMaterial.Controls.Add(this.label3);
            this.grpDetalleMaterial.Controls.Add(this.nudCantidad);
            this.grpDetalleMaterial.Controls.Add(this.lblCantidadPiezas);
            this.grpDetalleMaterial.Controls.Add(this.cmbMaterial);
            this.grpDetalleMaterial.Controls.Add(this.lblTipoMaterial);
            this.grpDetalleMaterial.Location = new System.Drawing.Point(480, 135);
            this.grpDetalleMaterial.Name = "grpDetalleMaterial";
            this.grpDetalleMaterial.Size = new System.Drawing.Size(282, 216);
            this.grpDetalleMaterial.TabIndex = 12;
            this.grpDetalleMaterial.TabStop = false;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(122, 173);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(145, 21);
            this.cmbEstado.TabIndex = 9;
            this.cmbEstado.Text = "Seleccione Estado";
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // lblEstadoEquipo
            // 
            this.lblEstadoEquipo.AutoSize = true;
            this.lblEstadoEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoEquipo.Location = new System.Drawing.Point(6, 176);
            this.lblEstadoEquipo.Name = "lblEstadoEquipo";
            this.lblEstadoEquipo.Size = new System.Drawing.Size(113, 13);
            this.lblEstadoEquipo.TabIndex = 8;
            this.lblEstadoEquipo.Text = "Estado del equipo:";
            // 
            // txtPrecioKg
            // 
            this.txtPrecioKg.Location = new System.Drawing.Point(122, 142);
            this.txtPrecioKg.Name = "txtPrecioKg";
            this.txtPrecioKg.Size = new System.Drawing.Size(145, 20);
            this.txtPrecioKg.TabIndex = 7;
            this.txtPrecioKg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioKg_KeyPress);
            // 
            // lblPrecioporKg
            // 
            this.lblPrecioporKg.AutoSize = true;
            this.lblPrecioporKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioporKg.Location = new System.Drawing.Point(9, 142);
            this.lblPrecioporKg.Name = "lblPrecioporKg";
            this.lblPrecioporKg.Size = new System.Drawing.Size(107, 13);
            this.lblPrecioporKg.TabIndex = 6;
            this.lblPrecioporKg.Text = "Precio por Kg ($):";
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(122, 96);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(145, 20);
            this.txtPeso.TabIndex = 5;
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Peso (kg):";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(122, 53);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(145, 20);
            this.nudCantidad.TabIndex = 3;
            // 
            // lblCantidadPiezas
            // 
            this.lblCantidadPiezas.AutoSize = true;
            this.lblCantidadPiezas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadPiezas.Location = new System.Drawing.Point(9, 55);
            this.lblCantidadPiezas.Name = "lblCantidadPiezas";
            this.lblCantidadPiezas.Size = new System.Drawing.Size(99, 13);
            this.lblCantidadPiezas.TabIndex = 2;
            this.lblCantidadPiezas.Text = "Cantidad (pzas):";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(122, 19);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(145, 21);
            this.cmbMaterial.TabIndex = 1;
            this.cmbMaterial.Text = "Seleccione un material";
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            // 
            // lblTipoMaterial
            // 
            this.lblTipoMaterial.AutoSize = true;
            this.lblTipoMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoMaterial.Location = new System.Drawing.Point(6, 21);
            this.lblTipoMaterial.Name = "lblTipoMaterial";
            this.lblTipoMaterial.Size = new System.Drawing.Size(102, 13);
            this.lblTipoMaterial.TabIndex = 0;
            this.lblTipoMaterial.Text = "Tipo de material:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(477, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "♻ Detalle del material";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(599, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Fecha:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaption;
            this.dateTimePicker1.Location = new System.Drawing.Point(651, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(211, 20);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::PA.Properties.Resources.pibble;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(663, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 241);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // lblResumenCompra
            // 
            this.lblResumenCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblResumenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumenCompra.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblResumenCompra.Location = new System.Drawing.Point(-3, 0);
            this.lblResumenCompra.Name = "lblResumenCompra";
            this.lblResumenCompra.Size = new System.Drawing.Size(244, 23);
            this.lblResumenCompra.TabIndex = 17;
            this.lblResumenCompra.Text = "   📃 Resumen de compra";
            this.lblResumenCompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpResumenCompra
            // 
            this.grpResumenCompra.Controls.Add(this.label9);
            this.grpResumenCompra.Controls.Add(this.label8);
            this.grpResumenCompra.Controls.Add(this.label7);
            this.grpResumenCompra.Controls.Add(this.label6);
            this.grpResumenCompra.Controls.Add(this.lblTotalArti);
            this.grpResumenCompra.Controls.Add(this.lblTotalPaga);
            this.grpResumenCompra.Controls.Add(this.lblimpuest);
            this.grpResumenCompra.Controls.Add(this.lblSubtot);
            this.grpResumenCompra.Controls.Add(this.lblPesoTot);
            this.grpResumenCompra.Controls.Add(this.lblTotalArtículos);
            this.grpResumenCompra.Controls.Add(this.lblResumenCompra);
            this.grpResumenCompra.Location = new System.Drawing.Point(811, 356);
            this.grpResumenCompra.Name = "grpResumenCompra";
            this.grpResumenCompra.Size = new System.Drawing.Size(241, 225);
            this.grpResumenCompra.TabIndex = 18;
            this.grpResumenCompra.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(59, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 14);
            this.label9.TabIndex = 35;
            this.label9.Text = "TOTAL A PAGAR:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "IVA (16%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Subtotal:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Peso Total:";
            // 
            // lblTotalArti
            // 
            this.lblTotalArti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTotalArti.Location = new System.Drawing.Point(139, 30);
            this.lblTotalArti.Name = "lblTotalArti";
            this.lblTotalArti.Size = new System.Drawing.Size(96, 18);
            this.lblTotalArti.TabIndex = 31;
            // 
            // lblTotalPaga
            // 
            this.lblTotalPaga.AutoSize = true;
            this.lblTotalPaga.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPaga.ForeColor = System.Drawing.Color.Green;
            this.lblTotalPaga.Location = new System.Drawing.Point(59, 185);
            this.lblTotalPaga.Name = "lblTotalPaga";
            this.lblTotalPaga.Size = new System.Drawing.Size(0, 27);
            this.lblTotalPaga.TabIndex = 26;
            // 
            // lblimpuest
            // 
            this.lblimpuest.AutoSize = true;
            this.lblimpuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblimpuest.Location = new System.Drawing.Point(147, 113);
            this.lblimpuest.Name = "lblimpuest";
            this.lblimpuest.Size = new System.Drawing.Size(0, 13);
            this.lblimpuest.TabIndex = 24;
            // 
            // lblSubtot
            // 
            this.lblSubtot.AutoSize = true;
            this.lblSubtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtot.Location = new System.Drawing.Point(147, 86);
            this.lblSubtot.Name = "lblSubtot";
            this.lblSubtot.Size = new System.Drawing.Size(0, 13);
            this.lblSubtot.TabIndex = 22;
            // 
            // lblPesoTot
            // 
            this.lblPesoTot.AutoSize = true;
            this.lblPesoTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesoTot.Location = new System.Drawing.Point(137, 61);
            this.lblPesoTot.Name = "lblPesoTot";
            this.lblPesoTot.Size = new System.Drawing.Size(0, 13);
            this.lblPesoTot.TabIndex = 20;
            // 
            // lblTotalArtículos
            // 
            this.lblTotalArtículos.AutoSize = true;
            this.lblTotalArtículos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArtículos.Location = new System.Drawing.Point(7, 30);
            this.lblTotalArtículos.Name = "lblTotalArtículos";
            this.lblTotalArtículos.Size = new System.Drawing.Size(113, 13);
            this.lblTotalArtículos.TabIndex = 18;
            this.lblTotalArtículos.Text = "Total de Artículos:";
            // 
            // dgvCompras
            // 
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID,
            this.ClmTipoMaterial,
            this.clmCantidad,
            this.clmPeso,
            this.clmPrecioKg,
            this.clmSubtotal});
            this.dgvCompras.Location = new System.Drawing.Point(166, 406);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.Size = new System.Drawing.Size(624, 192);
            this.dgvCompras.TabIndex = 19;
            // 
            // clmID
            // 
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            // 
            // ClmTipoMaterial
            // 
            this.ClmTipoMaterial.HeaderText = "Tipo de Material";
            this.ClmTipoMaterial.Name = "ClmTipoMaterial";
            // 
            // clmCantidad
            // 
            this.clmCantidad.HeaderText = "Cantidad (pzas)";
            this.clmCantidad.Name = "clmCantidad";
            // 
            // clmPeso
            // 
            this.clmPeso.HeaderText = "Peso (kg)";
            this.clmPeso.Name = "clmPeso";
            // 
            // clmPrecioKg
            // 
            this.clmPrecioKg.HeaderText = "Precio por Kg";
            this.clmPrecioKg.Name = "clmPrecioKg";
            // 
            // clmSubtotal
            // 
            this.clmSubtotal.HeaderText = "Subtotal";
            this.clmSubtotal.Name = "clmSubtotal";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRegistrar.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(791, 604);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(125, 37);
            this.btnRegistrar.TabIndex = 20;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnRegresarMenu
            // 
            this.btnRegresarMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRegresarMenu.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresarMenu.Location = new System.Drawing.Point(936, 604);
            this.btnRegresarMenu.Name = "btnRegresarMenu";
            this.btnRegresarMenu.Size = new System.Drawing.Size(125, 37);
            this.btnRegresarMenu.TabIndex = 21;
            this.btnRegresarMenu.Text = "Regresar al Menú";
            this.btnRegresarMenu.UseVisualStyleBackColor = false;
            this.btnRegresarMenu.Click += new System.EventHandler(this.btnRegresarMenu_Click);
            // 
            // btnTicket
            // 
            this.btnTicket.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTicket.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicket.Location = new System.Drawing.Point(651, 604);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(125, 37);
            this.btnTicket.TabIndex = 22;
            this.btnTicket.Text = "Generar Ticket";
            this.btnTicket.UseVisualStyleBackColor = false;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // FormCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::PA.Properties.Resources._4Display2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1102, 653);
            this.Controls.Add(this.btnTicket);
            this.Controls.Add(this.btnRegresarMenu);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.dgvCompras);
            this.Controls.Add(this.grpResumenCompra);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpDetalleMaterial);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblDatosVendedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpDatosVendedor);
            this.Controls.Add(this.lblSistemaReciclaje);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCompra";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpDatosVendedor.ResumeLayout(false);
            this.grpDatosVendedor.PerformLayout();
            this.grpDetalleMaterial.ResumeLayout(false);
            this.grpDetalleMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpResumenCompra.ResumeLayout(false);
            this.grpResumenCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSistemaReciclaje;
        private System.Windows.Forms.GroupBox grpDatosVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDatosVendedor;
        private System.Windows.Forms.Label lblDirección;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDirección;
        private System.Windows.Forms.TextBox txtTeléfono;
        private System.Windows.Forms.Label lblTeléfono;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpDetalleMaterial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCantidadPiezas;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label lblTipoMaterial;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblEstadoEquipo;
        private System.Windows.Forms.TextBox txtPrecioKg;
        private System.Windows.Forms.Label lblPrecioporKg;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblResumenCompra;
        private System.Windows.Forms.GroupBox grpResumenCompra;
        private System.Windows.Forms.Label lblPesoTot;
        private System.Windows.Forms.Label lblTotalArtículos;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Label lblimpuest;
        private System.Windows.Forms.Label lblSubtot;
        private System.Windows.Forms.Label lblTotalPaga;
        private System.Windows.Forms.Label lblTotalArti;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTipoMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPeso;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrecioKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubtotal;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRegresarMenu;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Label label9;
    }
}

