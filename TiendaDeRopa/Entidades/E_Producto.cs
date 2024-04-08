using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeRopa.Entidades
{
    public class E_Producto
    {
        public int id { get; set; }
        public string categoria { get; set; }
        public string tela { get; set; }
        public string talla { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public int id_proveedor { get; set; }
        public int precio { get; set; }
        public int estado { get; set; }
    }
}
