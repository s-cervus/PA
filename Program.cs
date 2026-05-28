using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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

            // ==================================
            // Periodo de insert
            // ==================================

            MyPreLoaderLib.MyPre_0();

            Application.Run(new Login());
        }
    }
    public class OVERLOAD
    {
        public static void OverChargeScreen(TableLayoutPanel panel)
        {
            // Usamos reflexión para acceder a los secretos ocultos de Win32 en .NET
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Le inyectamos el buffer doble para que dibuje en memoria RAM antes de mandar al monitor
            pi.SetValue(panel, true, null);
        }
    }

    public class MyPreLoaderLib
    {
        public static void MyPre_0()
        {
            // ========================================================
            // EL EXTRACTOR FANTASMA DE DEPENDENCIAS
            // ========================================================
            try
            {
                // Obtenemos la ruta donde se está ejecutando tu .exe
                string execRoute = AppDomain.CurrentDomain.BaseDirectory;
                string routeDLLphysic = Path.Combine(execRoute, "SQLite.Interop.dll");

                // Si la DLL no está físicamente en la USB/Carpeta...
                if (!File.Exists(routeDLLphysic))
                {
                    // La extraemos de los recursos y la materializamos en el disco duro
                    byte[] dllBytes = Properties.Resources.LibSQL_DLLe;
                    File.WriteAllBytes(routeDLLphysic, dllBytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico de inicialización : " + ex.Message, "Error :(");
                return; // Abortamos antes de que explote por falta de DLL
            }
        }
    }

}


