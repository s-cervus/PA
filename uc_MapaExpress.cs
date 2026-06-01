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
    public partial class uc_MapaExpress : UserControl
    {
        public uc_MapaExpress()
        {
            InitializeComponent();

            // Registramos el evento Load para inicializar el mapa en cuanto cargue la pantalla
            this.Load += uc_MapaExpress_Load;
        }

        private async void uc_MapaExpress_Load(object sender, EventArgs e)
        {
            try
            {
                // Esperamos a que el motor del navegador esté listo
                await webViewMapa.EnsureCoreWebView2Async(null);

                // URL Maestra: Busca centros de reciclaje de electrónica, computadoras y celulares en CDMX
                // El parámetro &q= indica la búsqueda y @19.4326,-99.1332,12z centra el mapa en el corazón de la CDMX con buen zoom
                string urlMapa = "https://www.google.com/maps/search/reciclaje+tecnologico+electronica+computadoras+cdmx/@19.4326,-99.1332,12z";

                // Le ordenamos al navegador que cargue esta búsqueda específica
                webViewMapa.CoreWebView2.Navigate(urlMapa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el mapa en tiempo real: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}