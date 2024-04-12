using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiendaDeRopa.Datos;

namespace TiendaDeRopa.Presentacion
{
    public partial class Frm_Productos : Form
    {

        private DataTable datosOriginales;
        public Frm_Productos()
        {
            InitializeComponent();
            ListarProductos();
        }

        private void ListarProductos()
        {
            D_Producto productos = new D_Producto();
            datosOriginales = productos.ListarProductos();
            dgvProductos.DataSource = datosOriginales;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Productos_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = "";
            txtTela.Text = "";
            txtTalla.Text = "";
            txtEstilo.Text = "";
            txtDescripcion.Text = "";
            txtMarca.Text = "";
            cbProveedor.SelectedIndex = -1;
            txtPrecio.Text = "";
        }
    }
}
