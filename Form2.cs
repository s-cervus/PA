using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void btnReg_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPasswd.Text) || string.IsNullOrWhiteSpace(txtPasswd2.Text))
            {
                MessageBox.Show("No dejes campos vacíos.", "Error de entrada");
                return;
            }


            if (txtUser.Text == txtPasswd2.Text)
            {
                DataManagerLR.RegUserPW(txtUser.Text, txtPasswd.Text);
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de entrada");
                return;

            }
        }
    }
}
