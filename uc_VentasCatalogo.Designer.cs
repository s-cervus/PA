namespace PA
{
    partial class uc_VentasCatalogo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcCategorias = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAgregarVentaC = new System.Windows.Forms.Button();
            this.dgvCelular = new System.Windows.Forms.DataGridView();
            this.txtBuscarCelular = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAgregarVentaL = new System.Windows.Forms.Button();
            this.dgvLaptop = new System.Windows.Forms.DataGridView();
            this.txtBuscarLaptop = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtBuscarComponentes = new System.Windows.Forms.TextBox();
            this.dgvComponentes = new System.Windows.Forms.DataGridView();
            this.btnAgregarVentaCR = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtBuscarMinerales = new System.Windows.Forms.TextBox();
            this.dgvMinerales = new System.Windows.Forms.DataGridView();
            this.btnAgregarVentaM = new System.Windows.Forms.Button();
            this.tcCategorias.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCelular)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptop)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentes)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinerales)).BeginInit();
            this.SuspendLayout();
            // 
            // tcCategorias
            // 
            this.tcCategorias.Controls.Add(this.tabPage2);
            this.tcCategorias.Controls.Add(this.tabPage1);
            this.tcCategorias.Controls.Add(this.tabPage3);
            this.tcCategorias.Controls.Add(this.tabPage4);
            this.tcCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCategorias.Location = new System.Drawing.Point(0, 0);
            this.tcCategorias.Name = "tcCategorias";
            this.tcCategorias.SelectedIndex = 0;
            this.tcCategorias.Size = new System.Drawing.Size(700, 450);
            this.tcCategorias.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAgregarVentaC);
            this.tabPage2.Controls.Add(this.dgvCelular);
            this.tabPage2.Controls.Add(this.txtBuscarCelular);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "📞 Celulares";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAgregarVentaC
            // 
            this.btnAgregarVentaC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarVentaC.Location = new System.Drawing.Point(3, 359);
            this.btnAgregarVentaC.Name = "btnAgregarVentaC";
            this.btnAgregarVentaC.Size = new System.Drawing.Size(686, 23);
            this.btnAgregarVentaC.TabIndex = 2;
            this.btnAgregarVentaC.Text = "Agregar a la venta";
            this.btnAgregarVentaC.UseVisualStyleBackColor = true;
            this.btnAgregarVentaC.Click += new System.EventHandler(this.btnAgregarVentaC_Click);
            // 
            // dgvCelular
            // 
            this.dgvCelular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCelular.Location = new System.Drawing.Point(3, 67);
            this.dgvCelular.Name = "dgvCelular";
            this.dgvCelular.Size = new System.Drawing.Size(686, 286);
            this.dgvCelular.TabIndex = 1;
            // 
            // txtBuscarCelular
            // 
            this.txtBuscarCelular.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarCelular.Location = new System.Drawing.Point(3, 3);
            this.txtBuscarCelular.Name = "txtBuscarCelular";
            this.txtBuscarCelular.Size = new System.Drawing.Size(686, 20);
            this.txtBuscarCelular.TabIndex = 0;
            this.txtBuscarCelular.Text = "[ Buscar Material... ]";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAgregarVentaL);
            this.tabPage1.Controls.Add(this.dgvLaptop);
            this.tabPage1.Controls.Add(this.txtBuscarLaptop);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "🖥️ Laptops/PC";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAgregarVentaL
            // 
            this.btnAgregarVentaL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarVentaL.Location = new System.Drawing.Point(3, 361);
            this.btnAgregarVentaL.Name = "btnAgregarVentaL";
            this.btnAgregarVentaL.Size = new System.Drawing.Size(686, 23);
            this.btnAgregarVentaL.TabIndex = 3;
            this.btnAgregarVentaL.Text = "Agregar a la venta";
            this.btnAgregarVentaL.UseVisualStyleBackColor = true;
            this.btnAgregarVentaL.Click += new System.EventHandler(this.btnAgregarVentaL_Click);
            // 
            // dgvLaptop
            // 
            this.dgvLaptop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaptop.Location = new System.Drawing.Point(3, 69);
            this.dgvLaptop.Name = "dgvLaptop";
            this.dgvLaptop.Size = new System.Drawing.Size(687, 286);
            this.dgvLaptop.TabIndex = 2;
            // 
            // txtBuscarLaptop
            // 
            this.txtBuscarLaptop.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarLaptop.Location = new System.Drawing.Point(3, 3);
            this.txtBuscarLaptop.Name = "txtBuscarLaptop";
            this.txtBuscarLaptop.Size = new System.Drawing.Size(686, 20);
            this.txtBuscarLaptop.TabIndex = 1;
            this.txtBuscarLaptop.Text = "[ Buscar Material... ]";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtBuscarComponentes);
            this.tabPage3.Controls.Add(this.dgvComponentes);
            this.tabPage3.Controls.Add(this.btnAgregarVentaCR);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(692, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "🔧 Componentes/Refacciones";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtBuscarComponentes
            // 
            this.txtBuscarComponentes.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarComponentes.Location = new System.Drawing.Point(0, 0);
            this.txtBuscarComponentes.Name = "txtBuscarComponentes";
            this.txtBuscarComponentes.Size = new System.Drawing.Size(692, 20);
            this.txtBuscarComponentes.TabIndex = 5;
            this.txtBuscarComponentes.Text = "[ Buscar Material... ]";
            // 
            // dgvComponentes
            // 
            this.dgvComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponentes.Location = new System.Drawing.Point(3, 69);
            this.dgvComponentes.Name = "dgvComponentes";
            this.dgvComponentes.Size = new System.Drawing.Size(687, 286);
            this.dgvComponentes.TabIndex = 4;
            // 
            // btnAgregarVentaCR
            // 
            this.btnAgregarVentaCR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarVentaCR.Location = new System.Drawing.Point(-1, 361);
            this.btnAgregarVentaCR.Name = "btnAgregarVentaCR";
            this.btnAgregarVentaCR.Size = new System.Drawing.Size(692, 23);
            this.btnAgregarVentaCR.TabIndex = 3;
            this.btnAgregarVentaCR.Text = "Agregar a la venta";
            this.btnAgregarVentaCR.UseVisualStyleBackColor = true;
            this.btnAgregarVentaCR.Click += new System.EventHandler(this.btnAgregarVentaCR_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtBuscarMinerales);
            this.tabPage4.Controls.Add(this.dgvMinerales);
            this.tabPage4.Controls.Add(this.btnAgregarVentaM);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(692, 424);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "💎 Minerales/Materiales";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtBuscarMinerales
            // 
            this.txtBuscarMinerales.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarMinerales.Location = new System.Drawing.Point(0, 0);
            this.txtBuscarMinerales.Name = "txtBuscarMinerales";
            this.txtBuscarMinerales.Size = new System.Drawing.Size(692, 20);
            this.txtBuscarMinerales.TabIndex = 5;
            this.txtBuscarMinerales.Text = "[ Buscar Material... ]";
            // 
            // dgvMinerales
            // 
            this.dgvMinerales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMinerales.Location = new System.Drawing.Point(3, 69);
            this.dgvMinerales.Name = "dgvMinerales";
            this.dgvMinerales.Size = new System.Drawing.Size(687, 286);
            this.dgvMinerales.TabIndex = 4;
            // 
            // btnAgregarVentaM
            // 
            this.btnAgregarVentaM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarVentaM.Location = new System.Drawing.Point(4, 361);
            this.btnAgregarVentaM.Name = "btnAgregarVentaM";
            this.btnAgregarVentaM.Size = new System.Drawing.Size(692, 23);
            this.btnAgregarVentaM.TabIndex = 3;
            this.btnAgregarVentaM.Text = "Agregar a la venta";
            this.btnAgregarVentaM.UseVisualStyleBackColor = true;
            this.btnAgregarVentaM.Click += new System.EventHandler(this.btnAgregarVentaM_Click);
            // 
            // uc_VentasCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcCategorias);
            this.Name = "uc_VentasCatalogo";
            this.Size = new System.Drawing.Size(700, 450);
            this.Load += new System.EventHandler(this.uc_VentasCatalogo_Load);
            this.tcCategorias.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCelular)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptop)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentes)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinerales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcCategorias;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvCelular;
        private System.Windows.Forms.TextBox txtBuscarCelular;
        private System.Windows.Forms.Button btnAgregarVentaC;
        private System.Windows.Forms.DataGridView dgvLaptop;
        private System.Windows.Forms.TextBox txtBuscarLaptop;
        private System.Windows.Forms.Button btnAgregarVentaL;
        private System.Windows.Forms.TextBox txtBuscarComponentes;
        private System.Windows.Forms.DataGridView dgvComponentes;
        private System.Windows.Forms.Button btnAgregarVentaCR;
        private System.Windows.Forms.TextBox txtBuscarMinerales;
        private System.Windows.Forms.DataGridView dgvMinerales;
        private System.Windows.Forms.Button btnAgregarVentaM;
    }
}
