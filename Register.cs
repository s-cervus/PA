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
        
        

        // Validador de string en Passwd para seguridad previa a post sending en la db de SQLite
        public Dictionary<string, Func<string, bool>> PasswdRules = new Dictionary<string, Func<string, bool>>
        {
            { "debe tener al menos 8 caracteres.", pass => pass.Length >= 8 },
            { "debe contener al menos un número.", pass => pass.Any(char.IsDigit) },
            { "debe contener un carácter especial.", pass => pass.Any(c => !char.IsLetterOrDigit(c)) }
        };

        private void btnReg_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPasswd.Text) || string.IsNullOrWhiteSpace(txtPasswd2.Text))
            {
                MessageBox.Show("No dejes campos vacíos.", "Error de entrada");
                return;
            }


            if (txtUser.Text != txtPasswd2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de entrada");
                return;
            }

            foreach (var rule in PasswdRules)
            {
                string message_err = rule.Key; // Error code
                var checking = rule.Value; // Es la función matemática/lógica

                bool passProbe = checking(txtPasswd.Text);

                if (!passProbe)
                {
                    MessageBox.Show($"La contraseña {message_err}"+ ", vuelva a intentarlo.", "Contraseña débil");
                    return;
                }
            }

            ControlUnit.RegUserPW(txtUser.Text, txtPasswd.Text);
            MessageBox.Show("Usuario registrado con éxito.", "Éxito");

        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
