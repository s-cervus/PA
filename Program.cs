using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
    public class OVERLOAD
    {
        public void OverChargeScreen(TableLayoutPanel panel)
        {
            // Usamos reflexión para acceder a los secretos ocultos de Win32 en .NET
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Le inyectamos el buffer doble para que dibuje en memoria RAM antes de mandar al monitor
            pi.SetValue(panel, true, null);
        }
    }

}


