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
            if (formularioAbierto != null)
            {
                formularioAbierto.Close();
            }

            Frm_Ventas ventas = new Frm_Ventas();

            configurarFormulario(ventas);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private Form formularioAbierto = null;

        private void compraToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (formularioAbierto != null)
            {
                formularioAbierto.Close();
            }

            Frm_Compras compras = new Frm_Compras();

            configurarFormulario(compras);
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formularioAbierto != null)
            {
                formularioAbierto.Close();
            }

            Frm_Proveedor proveedor = new Frm_Proveedor();

            configurarFormulario(proveedor);
        }

        private void configurarFormulario(Form formulario)
        {
            formulario.TopLevel = false;
            panel1.Controls.Add(formulario);
            formulario.Show();
            formulario.Dock = DockStyle.Fill;
            panel1.Dock = DockStyle.Fill;

            formularioAbierto = formulario;
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formularioAbierto != null)
            {
                formularioAbierto.Close();
            }

            Frm_Inventario inventario = new Frm_Inventario();

            configurarFormulario(inventario);
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formularioAbierto != null)
            {
                formularioAbierto.Close();
            }

            Frm_Productos productos = new Frm_Productos();

            configurarFormulario(productos);
        }
    }
}
