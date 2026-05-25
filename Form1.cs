using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace PA
{
    public partial class Login : Form
    {
        private FontsProjectOWN FontCLo;
        public Login()
        {
            InitializeComponent();
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
                lblW.Font = FontCLo.ObtainFont(50f, FontStyle.Regular);

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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
