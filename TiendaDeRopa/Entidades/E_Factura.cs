using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeRopa.Entidades

{  

    public class E_Factura
    {
        public int id { get; set; }

        public string cod_factura { get; set; }

        public DateTime fecha { get; set; }

        public float subtotal { get; set; }

        public float iva { get; set; }

        public float total { get; set; }

        public string forma_pago { get; set; }

        public int tipo { get; set; }
    }
}
