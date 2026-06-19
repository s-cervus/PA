using System.Windows.Forms;

namespace PA
{
    partial class FormVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVenta));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMenuLateral = new System.Windows.Forms.Panel();
            this.btnVerMapa = new System.Windows.Forms.Button();
            this.btnContabilidad = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnl = new System.Windows.Forms.Panel();
            this.pnlTopBar.SuspendLayout();
            this.pnlMenuLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlContenedor.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlTopBar.Controls.Add(this.label2);
            this.pnlTopBar.Controls.Add(this.label1);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopBar.Location = new System.Drawing.Point(225, 3);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(872, 56);
            this.pnlTopBar.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(591, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario:";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "SISTEMA DE RECICLAJE";
            // 
            // pnlMenuLateral
            // 
            this.pnlMenuLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMenuLateral.Controls.Add(this.btnVerMapa);
            this.pnlMenuLateral.Controls.Add(this.btnContabilidad);
            this.pnlMenuLateral.Controls.Add(this.btnInventario);
            this.pnlMenuLateral.Controls.Add(this.btnCompras);
            this.pnlMenuLateral.Controls.Add(this.btnNuevaVenta);
            this.pnlMenuLateral.Controls.Add(this.btnVentas);
            this.pnlMenuLateral.Controls.Add(this.btnInicio);
            this.pnlMenuLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuLateral.Location = new System.Drawing.Point(3, 65);
            this.pnlMenuLateral.Name = "pnlMenuLateral";
            this.pnlMenuLateral.Size = new System.Drawing.Size(216, 552);
            this.pnlMenuLateral.TabIndex = 17;
            // 
            // btnVerMapa
            // 
            this.btnVerMapa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVerMapa.FlatAppearance.BorderSize = 0;
            this.btnVerMapa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnVerMapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerMapa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVerMapa.Location = new System.Drawing.Point(0, 308);
            this.btnVerMapa.Name = "btnVerMapa";
            this.btnVerMapa.Size = new System.Drawing.Size(216, 50);
            this.btnVerMapa.TabIndex = 6;
            this.btnVerMapa.Text = "🏪 Sucursales";
            this.btnVerMapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerMapa.UseVisualStyleBackColor = true;
            this.btnVerMapa.Click += new System.EventHandler(this.btnVerMapa_Click);
            // 
            // btnContabilidad
            // 
            this.btnContabilidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContabilidad.FlatAppearance.BorderSize = 0;
            this.btnContabilidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnContabilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContabilidad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnContabilidad.Location = new System.Drawing.Point(0, 258);
            this.btnContabilidad.Name = "btnContabilidad";
            this.btnContabilidad.Size = new System.Drawing.Size(216, 50);
            this.btnContabilidad.TabIndex = 5;
            this.btnContabilidad.Text = "📊 DIARIO CONTABLE";
            this.btnContabilidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContabilidad.UseVisualStyleBackColor = true;
            this.btnContabilidad.Click += new System.EventHandler(this.btnContabilidad_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInventario.Location = new System.Drawing.Point(0, 208);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(216, 50);
            this.btnInventario.TabIndex = 4;
            this.btnInventario.Text = "📦 INVENTARIO GENERAL";
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompras.FlatAppearance.BorderSize = 0;
            this.btnCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCompras.Location = new System.Drawing.Point(0, 158);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(216, 50);
            this.btnCompras.TabIndex = 3;
            this.btnCompras.Text = "📤 COMPRA DE SCRAP";
            this.btnCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.UseVisualStyleBackColor = true;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevaVenta.FlatAppearance.BorderSize = 0;
            this.btnNuevaVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnNuevaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaVenta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNuevaVenta.Location = new System.Drawing.Point(0, 108);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(216, 50);
            this.btnNuevaVenta.TabIndex = 2;
            this.btnNuevaVenta.Text = "🛒 NUEVA VENTA (CAJA)";
            this.btnNuevaVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaVenta.UseVisualStyleBackColor = true;
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVentas.Location = new System.Drawing.Point(0, 50);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(216, 58);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.Text = "💰 CATÁLOGO DE VENTAS";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInicio.Location = new System.Drawing.Point(0, 0);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(216, 50);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "🏠 INICIO";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(872, 552);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContenedor.Controls.Add(this.pictureBox1);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(225, 65);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(872, 552);
            this.pnlContenedor.TabIndex = 18;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.20873F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.79128F));
            this.tlpMain.Controls.Add(this.pnlTopBar, 1, 0);
            this.tlpMain.Controls.Add(this.pnlContenedor, 1, 1);
            this.tlpMain.Controls.Add(this.pnlMenuLateral, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.08902F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.91098F));
            this.tlpMain.Size = new System.Drawing.Size(1100, 620);
            this.tlpMain.TabIndex = 19;
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.Transparent;
            this.pnl.Controls.Add(this.tlpMain);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(1100, 620);
            this.pnl.TabIndex = 20;
            // 
            // FormVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::PA.Properties.Resources._4Display2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 620);
            this.Controls.Add(this.pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1100, 620);
            this.Name = "FormVenta";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.FormVenta_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlMenuLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlContenedor.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlMenuLateral;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnContabilidad;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnVerMapa;
        private Panel pnlContenedor;
        private TableLayoutPanel tlpMain;
        private Panel pnl;
    }
}