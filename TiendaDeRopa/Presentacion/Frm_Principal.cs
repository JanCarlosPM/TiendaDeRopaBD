using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Frm_Compras compras = new Frm_Compras();

            compras.TopLevel = false;
            panel1.Controls.Add(compras);

            compras.Show();

            compras.Dock = DockStyle.Fill;
            panel1.Dock = DockStyle.Fill;

        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_Proveedor proveedor = new Frm_Proveedor();

            proveedor.TopLevel = false;
            panel1.Controls.Add(proveedor);
            
            proveedor.Show();

            proveedor.Dock = DockStyle.Fill;
            panel1.Dock = DockStyle.Fill;
        }
    }
}
