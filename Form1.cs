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
    public partial class Form1 : Form
    {
        PrivateFontCollection pfc = new PrivateFontCollection();
        public Form1()
        {
            InitializeComponent();
            CargarFuentePersonalizada();
        }
        private void CargarFuentePersonalizada()
        {
            // 1. Cargamos el archivo de la fuente
            // Asegúrate de que el nombre del archivo sea exacto
            pfc.AddFontFile(@"Resources\NotoSans-Regular.ttf");

            // 2. Creamos la fuente (pfc.Families[0] es Noto Sans)
            Font fuenteCustom = new Font(pfc.Families[0], 12, FontStyle.Regular);


        }
    }
}
