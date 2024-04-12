using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeRopa.Entidades
{
    public class E_Inventario
    {
        public int id { get; set; }

        public int id_producto { get; set; }

        public int existencia { get; set; }

        public DateTime fecha_ingreso { get; set; }

        public int estado { get; set; }
    }
}
