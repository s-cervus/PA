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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el Form3 actual
            FormEntrada formEntrada = new FormEntrada();
            formEntrada.Show(); 

            
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSalida formSalida = new FormSalida();
            formSalida.Show(); 
        }

        private void btnSucursales_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            FormSucusales formSucursales = new FormSucusales();
            formSucursales.Show();
            {
                Application.Exit();
            }
        }
    }
}
