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
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBTN = new System.Windows.Forms.TableLayoutPanel();
            this.lblUSER = new System.Windows.Forms.Label();
            this.lblCID = new System.Windows.Forms.Label();
            this.tlpDATA = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBase.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnlDragBKaiMsg.SuspendLayout();
            this.pnlDragZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosePic)).BeginInit();
            this.tlpMenu.SuspendLayout();
            this.tlpBTN.SuspendLayout();
            this.tlpDATA.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEntrada
            // 
            this.btnEntrada.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEntrada.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEntrada.FlatAppearance.BorderSize = 0;
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrada.ForeColor = System.Drawing.Color.White;
            this.btnEntrada.Location = new System.Drawing.Point(142, 47);
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
            this.btnSalida.Location = new System.Drawing.Point(142, 147);
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
            this.lblMenu.Location = new System.Drawing.Point(108, 28);
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
            this.tlpMain.Controls.Add(this.tlpBTN, 0, 1);
            this.tlpMain.Controls.Add(this.tlpDATA, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.82844F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.17155F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tlpMain.Size = new System.Drawing.Size(482, 496);
            this.tlpMain.TabIndex = 5;
            // 
            // pnlDragBKaiMsg
            // 
            this.pnlDragBKaiMsg.Controls.Add(this.pnlDragZone);
            this.pnlDragBKaiMsg.Controls.Add(this.tlpMenu);
            this.pnlDragBKaiMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDragBKaiMsg.Location = new System.Drawing.Point(3, 3);
            this.pnlDragBKaiMsg.Name = "pnlDragBKaiMsg";
            this.pnlDragBKaiMsg.Size = new System.Drawing.Size(476, 114);
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
            // tlpMenu
            // 
            this.tlpMenu.ColumnCount = 3;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tlpMenu.Controls.Add(this.lblMenu, 1, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpMenu.Location = new System.Drawing.Point(0, 44);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(476, 70);
            this.tlpMenu.TabIndex = 0;
            // 
            // tlpBTN
            // 
            this.tlpBTN.ColumnCount = 3;
            this.tlpBTN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpBTN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpBTN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpBTN.Controls.Add(this.btnEntrada, 1, 0);
            this.tlpBTN.Controls.Add(this.btnSalida, 1, 1);
            this.tlpBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBTN.Location = new System.Drawing.Point(3, 123);
            this.tlpBTN.Name = "tlpBTN";
            this.tlpBTN.RowCount = 3;
            this.tlpBTN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpBTN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpBTN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.89189F));
            this.tlpBTN.Size = new System.Drawing.Size(476, 251);
            this.tlpBTN.TabIndex = 5;
            // 
            // lblUSER
            // 
            this.lblUSER.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUSER.AutoSize = true;
            this.lblUSER.BackColor = System.Drawing.Color.Transparent;
            this.lblUSER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSER.ForeColor = System.Drawing.Color.Black;
            this.lblUSER.Location = new System.Drawing.Point(3, 43);
            this.lblUSER.Name = "lblUSER";
            this.lblUSER.Size = new System.Drawing.Size(232, 13);
            this.lblUSER.TabIndex = 4;
            this.lblUSER.Text = "MaskedUser";
            this.lblUSER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCID
            // 
            this.lblCID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCID.AutoSize = true;
            this.lblCID.BackColor = System.Drawing.Color.Transparent;
            this.lblCID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCID.ForeColor = System.Drawing.Color.Black;
            this.lblCID.Location = new System.Drawing.Point(3, 100);
            this.lblCID.Name = "lblCID";
            this.lblCID.Size = new System.Drawing.Size(232, 13);
            this.lblCID.TabIndex = 5;
            this.lblCID.Text = "MaskedCID";
            this.lblCID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpDATA
            // 
            this.tlpDATA.ColumnCount = 2;
            this.tlpDATA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDATA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDATA.Controls.Add(this.lblUSER, 0, 0);
            this.tlpDATA.Controls.Add(this.lblCID, 0, 1);
            this.tlpDATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDATA.Location = new System.Drawing.Point(3, 380);
            this.tlpDATA.Name = "tlpDATA";
            this.tlpDATA.RowCount = 2;
            this.tlpDATA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDATA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDATA.Size = new System.Drawing.Size(476, 113);
            this.tlpDATA.TabIndex = 6;
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
            this.tlpMenu.ResumeLayout(false);
            this.tlpMenu.PerformLayout();
            this.tlpBTN.ResumeLayout(false);
            this.tlpDATA.ResumeLayout(false);
            this.tlpDATA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlDragBKaiMsg;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.TableLayoutPanel tlpBTN;
        private System.Windows.Forms.Panel pnlDragZone;
        private System.Windows.Forms.PictureBox btnClosePic;
        private System.Windows.Forms.Label lblUSER;
        private System.Windows.Forms.Label lblCID;
        private System.Windows.Forms.TableLayoutPanel tlpDATA;
    }
}