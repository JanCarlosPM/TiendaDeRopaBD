using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeRopa.Entidades
{
    public class E_DetalleFactura
    {
        public int id { get; set; }

        public int id_producto_inventario { get; set; }

        public int cantidad { get; set; }

        public int precio_venta { get; set; }

        public int id_factura { get; set; }
    }
}
