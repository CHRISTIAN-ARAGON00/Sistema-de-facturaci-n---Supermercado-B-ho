using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_facturación___Supermercado_Búho
{
    internal class clsProducto
    {
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public double PrecioSinIva { get; set; }
        public double PrecioFinal { get; set; }
    }
}
