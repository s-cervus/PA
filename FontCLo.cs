using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace PA
{
    // Implementamos IDisposable para liberar la memoria de forma limpia después
    public class FontsProjectOWN : IDisposable
    {
        // API de Windows para el renderizado correcto
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private PrivateFontCollection pfc;

        public FontsProjectOWN()
        {
            pfc = new PrivateFontCollection();
            LoadFontFrom();
        }

        private void LoadFontFrom()
        {
            // Extraemos los bytes desde los recursos del proyecto
            // Asegúrate de que "MiFuente" sea el nombre exacto en tu Resources.resx
            byte[] fontData = Properties.Resources.FontSugo;

            // Alocamos memoria no administrada
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

            // Guardamos en la colección privada
            pfc.AddMemoryFont(fontPtr, fontData.Length);

            // Registramos en Windows
            uint dummy = 0;
            AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);

            // Liberamos la memoria temporal
            Marshal.FreeCoTaskMem(fontPtr);
        }

        /// <summary>
        /// Método público para inyectar la fuente a cualquier control con el tamaño y estilo deseado.
        /// </summary>
        public Font ObtainFont(float tamano, FontStyle estilo = FontStyle.Regular)
        {
            if (pfc.Families.Length == 0)
                throw new Exception("Collection Void");

            // Retorna un objeto Font basado en nuestra tipografía cargada
            return new Font(pfc.Families[0], tamano, estilo);
        }

        // Destructor por si se olvida llamar a Dispose
        public void Dispose()
        {
            if (pfc != null)
            {
                pfc.Dispose();
                pfc = null;
            }
        }


        //--------------------------------------
        public void Apply4All(System.Windows.Forms.Control mainCointainer, float tamano, System.Drawing.FontStyle estilo = System.Drawing.FontStyle.Regular)
        {
            // 1. Creamos la fuente una sola vez para ahorrar memoria
            System.Drawing.Font newFont = ObtainFont(tamano, estilo);

            // 2. Se la asignamos al contenedor base (por ejemplo, el Formulario)
            mainCointainer.Font = newFont;

            // 3. Función local interna recursiva para recorrer todo el árbol de controles
            void takeSubFunc(System.Windows.Forms.Control father)
            {
                foreach (System.Windows.Forms.Control sub in father.Controls)
                {
                    sub.Font = newFont;

                    // Si este control tiene más controles dentro (ej. un Panel o GroupBox), se auto-invoca
                    if (sub.HasChildren)
                    {
                        takeSubFunc(sub);
                    }
                }
            }

            // 4. Arrancamos el barrido
            takeSubFunc(mainCointainer);
        }
    }
}