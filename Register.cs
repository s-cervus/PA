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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        
        

        // Validador de string en Passwd para seguridad previa a post sending en la db de SQLite
        public Dictionary<string, Func<string, bool>> PasswdRules = new Dictionary<string, Func<string, bool>>
        {
            { "debe tener al menos 8 caracteres.", pass => pass.Length >= 8 },
            { "debe contener al menos un número.", pass => pass.Any(char.IsDigit) },
            { "debe contener un carácter especial.", pass => pass.Any(c => !char.IsLetterOrDigit(c)) }
        };

        private void btnReg_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPasswd1.Text) || string.IsNullOrWhiteSpace(txtPasswd2.Text))
            {
                MessageBox.Show("No dejes campos vacíos.", "Error de entrada");
                return;
            }


            if (txtPasswd1.Text != txtPasswd2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de entrada");
                return;
            }

            foreach (var rule in PasswdRules)
            {
                string message_err = rule.Key; // Error code
                var checking = rule.Value; // Es la función matemática/lógica

                bool passProbe = checking(txtPasswd1.Text);

                if (!passProbe)
                {
                    MessageBox.Show($"La contraseña {message_err}" + ", vuelva a intentarlo.", "Contraseña débil");
                    return;
                }
            }

            //ControlUnit.RegUserPW(txtUser.Text, txtPasswd1.Text);
            MessageBox.Show("Usuario registrado con éxito.", "Éxito");


            


        }


        #region Codigo en visual front

        private FontCLo FontCLo;
        private void Register_Load(object sender, EventArgs e)
        {

            //this.optimizer();

            this.Region = System.Drawing.Region.FromHrgn(DreamStyle.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.FormBorderStyle = FormBorderStyle.None;

            pnlUser.Region = Region.FromHrgn(DreamStyle.CreateRoundRectRgn(0, 0, pnlUser.Width, pnlUser.Height, 15, 15));
            pnlPasswd1.Region = Region.FromHrgn(DreamStyle.CreateRoundRectRgn(0, 0, pnlPasswd1.Width, pnlPasswd1.Height, 15, 15));
            pnlPasswd2.Region = Region.FromHrgn(DreamStyle.CreateRoundRectRgn(0, 0, pnlPasswd2.Width, pnlPasswd2.Height, 15, 15));
            btnRegister.Region = Region.FromHrgn(DreamStyle.CreateRoundRectRgn(0, 0, btnRegister.Width, btnRegister.Height, 15, 15));


            this.OpFullUI();
            try
            {
                FontCLo = new FontCLo();


                
                lblR.Font = FontCLo.ObtainFont(40f, FontStyle.Regular);
                lblU.Font = FontCLo.ObtainFont(19f, FontStyle.Regular);
                lblP1.Font = FontCLo.ObtainFont(19f, FontStyle.Regular);
                lblP2.Font = FontCLo.ObtainFont(19F, FontStyle.Regular);
                btnRegister.Font = FontCLo.ObtainFont(20F, FontStyle.Regular);
               

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



        private bool passwdHide = true;
        private void picEye_Click(object sender, EventArgs e)
        {
            if (passwdHide)
            {
                // Mostrar contraseña
                txtPasswd1.UseSystemPasswordChar = false;
                txtPasswd1.PasswordChar = '\0';
                txtPasswd2.UseSystemPasswordChar = false;
                txtPasswd2.PasswordChar = '\0';
                picEye.Image = Properties.Resources.eye; // Cambia el icono
                passwdHide = false;
            }
            else
            {
                // Ocultar contraseña
                txtPasswd1.UseSystemPasswordChar = true;
                txtPasswd2.UseSystemPasswordChar = true;
                picEye.Image = Properties.Resources.eye_closed; // Cambia el icono
                passwdHide = true;
            }
        }


        #endregion
    }
}

