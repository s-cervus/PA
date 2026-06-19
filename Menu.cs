using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCompra formCompra = new FormCompra();
            formCompra.Show();
            

            
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el Form3 actual
            FormVenta formVenta = new FormVenta();
            formVenta.Show();
        }

        private void btnSucursales_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            FormSucusales formSucursales = new FormSucusales();
            formSucursales.Show();
            {
            }
        }

        #region Codigo en visual front

        private FontCLo FontCLo;

        private void Menu_Load(object sender, EventArgs e)
        {
            //this.optimizer();

            this.Region = System.Drawing.Region.FromHrgn(DreamStyle.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.FormBorderStyle = FormBorderStyle.None;

            
            btnEntrada.Region = Region.FromHrgn(DreamStyle.CreateRoundRectRgn(0, 0, btnEntrada.Width, btnEntrada.Height, 15, 15));
            btnSalida.Region = Region.FromHrgn(DreamStyle.CreateRoundRectRgn(0, 0, btnSalida.Width, btnSalida.Height, 15, 15));
            //btnSucursales.Region = Region.FromHrgn(DreamStyle.CreateRoundRectRgn(0, 0, btnSucursales.Width, btnSucursales.Height, 15, 15));


            this.OpFullUI();
            try
            {
                FontCLo = new FontCLo();

                lblMenu.Font = FontCLo.ObtainFont(40f, FontStyle.Regular);
                btnEntrada.Font = FontCLo.ObtainFont(20F, FontStyle.Regular);
                btnSalida.Font = FontCLo.ObtainFont(20F, FontStyle.Regular);
                //btnSucursales.Font = FontCLo.ObtainFont(20F, FontStyle.Regular);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando la interfaz: " + ex.Message);
            }
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pnlDragZone_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                // Le mandamos el handle del formulario completo (this.Handle), 
                // aunque el clic haya entrado por el panel invisible
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #endregion


    }
}
