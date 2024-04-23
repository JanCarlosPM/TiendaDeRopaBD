using System;
using System.Data;
using System.Windows.Forms;
using TiendaDeRopa.Datos;

namespace TiendaDeRopa.Presentacion
{
    public partial class Frm_Inventario : Form
    {

        private DataTable dataInventario;
        public Frm_Inventario()
        {
            InitializeComponent();
            ListarInventario();
        }

        private void ListarInventario()
        {
            D_Inventario inventario = new D_Inventario();
            dataInventario = inventario.ListarInventario();
            dgvInventario.DataSource = dataInventario;
        }
    }
}
