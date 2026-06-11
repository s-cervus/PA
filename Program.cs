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
            Application.Run(new Form3());
            


            // ==================================
            // Periodo de insert
            // ==================================

            //MyPreLoaderLib.MyPre_0();


            // Secuestro el MainForm y lo proceso
            Application.Run(new GlobalFormSupervisor(new Login()));
            

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


    /*
    public class MyPreLoaderLib
    {
        public static void MyPre_0()
        {
            // ========================================================
            // <<<< FILE DEPEND EXTRACTOR.... >>>>
            // ========================================================
            try
            {
                string execRoute = AppDomain.CurrentDomain.BaseDirectory;
                string routeDLLphysic = Path.Combine(execRoute, "SQLite.Interop.dll");

                if (!File.Exists(routeDLLphysic))
                {
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
    */


    public class GlobalFormSupervisor : ApplicationContext
    {
        public GlobalFormSupervisor(Form mainForm)
        {
            // Reg Main Form
            RegisterForm(mainForm);
            mainForm.Show();
        }

        private void RegisterForm(Form form)
        {
            // Synth detected<<<<<<<
            form.FormClosed += new FormClosedEventHandler(GraphicExt.ClosesAll);

            // IF another form opens apply rule>>>>
            form.Activated += (sender, e) =>
            {
                // Searching...
                foreach (Form openForm in Application.OpenForms)
                {
                    // IF a Window hadn't this event we try to apply this...
                    openForm.FormClosed -= GraphicExt.ClosesAll;
                    openForm.FormClosed += GraphicExt.ClosesAll;
                }
            };
        }
    }



}


