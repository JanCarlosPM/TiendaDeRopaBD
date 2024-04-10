using System;
using System.Windows.Forms;
using TiendaDeRopa.formularios;
using TiendaDeRopa.Presentacion;

namespace TiendaDeRopa
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void venaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compraToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Cerrar el formulario anterior si lo hay
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.RemoveAt(0);
            }

            // Mostrar el formulario de compras en el panel principal
            Frm_Compras compras = new Frm_Compras();
            compras.TopLevel = false;
            panel1.Controls.Add(compras);
            compras.Dock = DockStyle.Fill;
            compras.Show();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario anterior si lo hay
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.RemoveAt(0);
            }

            // Mostrar el formulario de proveedor en el panel principal
            Frm_Proveedor proveedor = new Frm_Proveedor();
            proveedor.TopLevel = false;
            panel1.Controls.Add(proveedor);
            proveedor.Dock = DockStyle.Fill;
            proveedor.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.RemoveAt(0);
            }

            Frm_Inventario inventario = new Frm_Inventario();
            inventario.TopLevel = false;
            panel1.Controls.Add(inventario);
            inventario.Dock = DockStyle.Fill;
            inventario.Show();
        }
    }
}