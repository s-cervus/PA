using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA
{
    public partial class Login : Form
    {
        private FontsProjectOWN FontCLo;
        public Login()
        {
            InitializeComponent();

            
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.FormBorderStyle = FormBorderStyle.None;
            
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlU.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlU.Width, pnlU.Height, 15, 15));
            pnlP.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlP.Width, pnlP.Height, 15, 15));
            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 15, 15));
            btnRegister.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRegister.Width, btnRegister.Height, 15, 15));
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form2 register = new Form2();
            register.ShowDialog();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                FontCLo = new FontsProjectOWN();


                //FontCLo.Apply4All(this, 9f, FontStyle.Regular);
                lblW.Font = FontCLo.ObtainFont(35f, FontStyle.Regular);
                lblP.Font = FontCLo.ObtainFont(19f, FontStyle.Regular);
                lblU.Font = FontCLo.ObtainFont(19f, FontStyle.Regular);
                btnLogin.Font = FontCLo.ObtainFont(19F, FontStyle.Regular);
                btnRegister.Font = FontCLo.ObtainFont(19F, FontStyle.Regular);
                //lblMark.Font=FontCLo.ObtainFont(19F, FontStyle.Regular);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando la interfaz: " + ex.Message);
            }
        }



        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Liberamos la memoria de la PrivateFontCollection
            if (FontCLo != null)
            {
                FontCLo.Dispose();
            }
        }

        // P/Invoke para el efecto de sombra (opcional pero muy recomendado para el look)
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);


        
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        // Variable global en tu formulario para guardar el estado
        private bool passwordOculta = true;

        private void picEye_Click(object sender, EventArgs e)
        {
            if (passwordOculta)
            {
                // Mostrar contraseña
                txtPasswd.UseSystemPasswordChar = false;
                txtPasswd.PasswordChar = '\0';
                picEye.Image = Properties.Resources.eye; // Cambia el icono
                passwordOculta = false;
            }
            else
            {
                // Ocultar contraseña
                txtPasswd.UseSystemPasswordChar = true;
                picEye.Image = Properties.Resources.eye_closed; // Cambia el icono
                passwordOculta = true;
            }
        }

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



        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // Este evento se encargará del arrastre
        private void MoverVentana_MouseDown(object sender, MouseEventArgs e)
        {
            // Validamos que sea el click izquierdo el que arrastra
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                // Envía el mensaje al sistema operativo para indicarle que se está moviendo el formulario completo
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }
        // ----------------------------------------------------

        // --- LÓGICA DEL BOTÓN CERRAR ---
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}


//Pixeles y Curiosidades



/*
// --- CÓDIGO PARA REDONDEAR LOS PANELES DE TEXTO (HITBOXES) ---
// (Requiere GDI+ para recortar los paneles)

[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

private void FormPrincipal_Load(object sender, EventArgs e)
{
    // Redondear el Panel que contiene el TextBox de 'Usuario'
    // El '15' es el radio de la curvatura
    pnlUsuario.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlUsuario.Width, pnlUsuario.Height, 15, 15));

    // Redondear el Panel de 'Contraseña'
    pnlContrasena.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlContrasena.Width, pnlContrasena.Height, 15, 15));

    // Redondear los botones de acción si no usas imágenes (opcional)
    btnRegistrar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRegistrar.Width, btnRegistrar.Height, 15, 15));
    btnAcceder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAcceder.Width, btnAcceder.Height, 15, 15));
}
*/

/*
        public Form()
        {
            InitializeComponent();

            // 1. Quitar bordes estándar
            this.FormBorderStyle = FormBorderStyle.None;

            // 2. Activar la sombra de la ventana (DWM) para un look pro
            int attrValue = 2; // DWMWA_WINDOW_CORNER_PREFERENCE
            DwmSetWindowAttribute(this.Handle, 33, ref attrValue, 4); // 33 es la opción de esquina redonda

            // (Si usas un .NET muy antiguo, el DWM de arriba puede no funcionar.
            //  En ese caso, usarías el método de 'Clipping Region' de abajo).
            // this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // Método alternativo
        }
        */

// --- Método Alternativo Clásico de Recorte de Región (Hit Testing) ---
// Descomenta esto y la línea de arriba si el efecto DWM no funciona.