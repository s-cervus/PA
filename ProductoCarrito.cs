using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA
{
    public class ProductoCarrito
    {
        public string ID { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        // Estructura clásica que no se confunde con versiones antiguas de C#
        public decimal Total
        {
            get { return Cantidad * Precio; }
        }
    }
}
