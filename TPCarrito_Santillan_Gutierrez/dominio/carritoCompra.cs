using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class carritoCompra
    {
        public List<itemCarrito> listado { get; set; }
        public decimal total { get; set; }

    }
    public class itemCarrito
    {
        public int id { get; set; }
        public Articulo item { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
    }
}
