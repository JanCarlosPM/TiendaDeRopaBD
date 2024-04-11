using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaDeRopa.Presentacion
{
    public partial class Frm_Ventas : Form
    {
        public Frm_Ventas()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_Ventas_Load(object sender, EventArgs e)
        {

        }

        private void txtTotalVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvVenta.Rows[e.RowIndex];

                txtCategoriaVenta.Text = filaSeleccionada.Cells["Categoria"].Value.ToString();
                txtPrecioVenta.Text = filaSeleccionada.Cells["Precio"].Value.ToString();

                txtCantidaVenta.Enabled = true;
                Btn_ListaVenta.Enabled = true;
            }
        }

        private void Btn_ListaVenta_Click(object sender, EventArgs e)
        {

        }
    }
}
