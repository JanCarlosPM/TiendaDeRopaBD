using System;
using System.Data;
using System.Windows.Forms;
using TiendaDeRopa.Datos;

namespace TiendaDeRopa.Presentacion
{
    public partial class Frm_Inventario : Form
    {

        private DataTable datosOriginales;
        public Frm_Inventario()
        {
            InitializeComponent();
            ListarInventario();
        }

        private void ListarInventario()
        {
            D_Inventario inventario = new D_Inventario();
            datosOriginales = inventario.ListarInventario();
            dgvInventario.DataSource = datosOriginales;
        }
    }
}