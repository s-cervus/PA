namespace PA
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.lblMenu = new System.Windows.Forms.Label();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDragBKaiMsg = new System.Windows.Forms.Panel();
            this.pnlDragZone = new System.Windows.Forms.Panel();
            this.btnClosePic = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUSER = new System.Windows.Forms.Label();
            this.pnlBase.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnlDragBKaiMsg.SuspendLayout();
            this.pnlDragZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosePic)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEntrada
            // 
            this.btnEntrada.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEntrada.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEntrada.FlatAppearance.BorderSize = 0;
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrada.ForeColor = System.Drawing.Color.White;
            this.btnEntrada.Location = new System.Drawing.Point(142, 45);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(191, 50);
            this.btnEntrada.TabIndex = 0;
            this.btnEntrada.Text = "Entrada";
            this.btnEntrada.UseVisualStyleBackColor = false;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalida.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSalida.FlatAppearance.BorderSize = 0;
            this.btnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalida.ForeColor = System.Drawing.Color.White;
            this.btnSalida.Location = new System.Drawing.Point(142, 143);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(191, 50);
            this.btnSalida.TabIndex = 1;
            this.btnSalida.Text = "Salida";
            this.btnSalida.UseVisualStyleBackColor = false;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMenu.AutoSize = true;
            this.lblMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.Black;
            this.lblMenu.Location = new System.Drawing.Point(108, 38);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(258, 13);
            this.lblMenu.TabIndex = 3;
            this.lblMenu.Text = "Menú";
            this.lblMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBase
            // 
            this.pnlBase.BackColor = System.Drawing.Color.Transparent;
            this.pnlBase.Controls.Add(this.tlpMain);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(482, 496);
            this.pnlBase.TabIndex = 4;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.pnlDragBKaiMsg, 0, 0);
            this.tlpMain.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.82844F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.17155F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpMain.Size = new System.Drawing.Size(482, 496);
            this.tlpMain.TabIndex = 5;
            // 
            // pnlDragBKaiMsg
            // 
            this.pnlDragBKaiMsg.Controls.Add(this.pnlDragZone);
            this.pnlDragBKaiMsg.Controls.Add(this.tableLayoutPanel1);
            this.pnlDragBKaiMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDragBKaiMsg.Location = new System.Drawing.Point(3, 3);
            this.pnlDragBKaiMsg.Name = "pnlDragBKaiMsg";
            this.pnlDragBKaiMsg.Size = new System.Drawing.Size(476, 135);
            this.pnlDragBKaiMsg.TabIndex = 4;
            // 
            // pnlDragZone
            // 
            this.pnlDragZone.Controls.Add(this.btnClosePic);
            this.pnlDragZone.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDragZone.Location = new System.Drawing.Point(0, 0);
            this.pnlDragZone.Name = "pnlDragZone";
            this.pnlDragZone.Size = new System.Drawing.Size(476, 37);
            this.pnlDragZone.TabIndex = 25;
            this.pnlDragZone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDragZone_MouseDown);
            // 
            // btnClosePic
            // 
            this.btnClosePic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClosePic.Image = ((System.Drawing.Image)(resources.GetObject("btnClosePic.Image")));
            this.btnClosePic.Location = new System.Drawing.Point(451, 9);
            this.btnClosePic.Name = "btnClosePic";
            this.btnClosePic.Size = new System.Drawing.Size(16, 16);
            this.btnClosePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClosePic.TabIndex = 22;
            this.btnClosePic.TabStop = false;
            this.btnClosePic.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.Controls.Add(this.lblMenu, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 89);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.btnEntrada, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSalida, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblUSER, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 144);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(476, 296);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // lblUSER
            // 
            this.lblUSER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUSER.AutoSize = true;
            this.lblUSER.BackColor = System.Drawing.Color.Transparent;
            this.lblUSER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSER.ForeColor = System.Drawing.Color.Black;
            this.lblUSER.Location = new System.Drawing.Point(82, 239);
            this.lblUSER.Name = "lblUSER";
            this.lblUSER.Size = new System.Drawing.Size(311, 13);
            this.lblUSER.TabIndex = 4;
            this.lblUSER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PA.Properties.Resources._4Display2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(482, 496);
            this.Controls.Add(this.pnlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.pnlBase.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.pnlDragBKaiMsg.ResumeLayout(false);
            this.pnlDragZone.ResumeLayout(false);
            this.pnlDragZone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosePic)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlDragBKaiMsg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnlDragZone;
        private System.Windows.Forms.PictureBox btnClosePic;
        private System.Windows.Forms.Label lblUSER;
    }
}