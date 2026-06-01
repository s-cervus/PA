namespace PA
{
    partial class uc_MapaExpress
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
            this.webViewMapa = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // webViewMapa
            // 
            this.webViewMapa.AllowExternalDrop = true;
            this.webViewMapa.CreationProperties = null;
            this.webViewMapa.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewMapa.Location = new System.Drawing.Point(0, 0);
            this.webViewMapa.Name = "webViewMapa";
            this.webViewMapa.Size = new System.Drawing.Size(1006, 566);
            this.webViewMapa.TabIndex = 0;
            this.webViewMapa.ZoomFactor = 1D;
            // 
            // uc_MapaExpress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webViewMapa);
            this.Name = "uc_MapaExpress";
            this.Size = new System.Drawing.Size(1006, 566);
            ((System.ComponentModel.ISupportInitialize)(this.webViewMapa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewMapa;
    }
}
