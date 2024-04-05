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

namespace TiendaDeRopa
{
    public partial class wfPrincipal : Form
    {
        public wfPrincipal()
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
            // Crear una instancia del formulario wfCompras
            wfCompras compras = new wfCompras();

            // Establecer el formulario como un control secundario del panel1
            compras.TopLevel = false;
            panel1.Controls.Add(compras);

            // Mostrar el formulario dentro del panel
            compras.Show();

            //Necesito que ocupe todo el panel y no solo una parte
            compras.Dock = DockStyle.Fill;
            panel1.Dock = DockStyle.Fill;


        }
    }
}
