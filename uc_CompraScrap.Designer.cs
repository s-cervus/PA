namespace PA
{
    partial class uc_CompraScrap
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvHistorialScrap = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialScrap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorialScrap
            // 
            this.dgvHistorialScrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorialScrap.Location = new System.Drawing.Point(0, 0);
            this.dgvHistorialScrap.Name = "dgvHistorialScrap";
            this.dgvHistorialScrap.Size = new System.Drawing.Size(623, 440);
            this.dgvHistorialScrap.TabIndex = 0;
            // 
            // uc_CompraScrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvHistorialScrap);
            this.Name = "uc_CompraScrap";
            this.Size = new System.Drawing.Size(623, 440);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialScrap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialScrap;
    }
}
