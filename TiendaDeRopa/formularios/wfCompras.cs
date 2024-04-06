using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TiendaDeRopa.formularios
{
    public partial class wfCompras : Form
    {

        private int numeroFactura = 1;
        public wfCompras()
        {
            InitializeComponent();
            GenerarNumeroFactura();
            ObtenerFechaActual();
        }

        private void ObtenerFechaActual()
        {
            txtFechaCompra.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaCompra.Enabled = false;
        }
        private void GenerarNumeroFactura()
        {
            string numeroFacturaStr = numeroFactura.ToString("00000");
            txtNumeroFactura.Text = numeroFacturaStr;
            numeroFactura++;
        }

        private bool ValidarCampos()
        {
            if(txtFechaCompra.Text == "" || txtSubTotal.Text == "" || txtIVA.Text == "" || txtTotal.Text == "" || (!cbEfectivo.Checked && !cbTarjeta.Checked))
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtFechaCompra.Text == "")
            {
                MessageBox.Show("Debe ingresar la fecha de la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFechaCompra.Focus();
                return false;
            }

            if (txtSubTotal.Text == "")
            {
                MessageBox.Show("Debe ingresar el subtotal de la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubTotal.Focus();
                return false;
            }

            if (!double.TryParse(txtSubTotal.Text, out _))
            {
                MessageBox.Show("El subtotal debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubTotal.Focus();
                return false;
            }

            if (txtIVA.Text == "")
            {
                MessageBox.Show("Debe ingresar el IVA de la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIVA.Focus();
                return false;
            }

            if (!double.TryParse(txtIVA.Text, out _))
            {
                MessageBox.Show("El IVA debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIVA.Focus();
                return false;
            }

            if (txtTotal.Text == "")
            {
                MessageBox.Show("Debe ingresar el total de la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotal.Focus();
                return false;
            }

            if (!double.TryParse(txtTotal.Text, out _))
            {
                MessageBox.Show("El total debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotal.Focus();
                return false;
            }

            if (!cbEfectivo.Checked && !cbTarjeta.Checked)
            {
                MessageBox.Show("Debe seleccionar la forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {             
            txtSubTotal.Text = "";
            txtIVA.Text = "";
            txtTotal.Text = "";
            cbEfectivo.Checked = false;
            cbTarjeta.Checked = false;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                MessageBox.Show("Debe ingresar el número de factura a buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBuscar.Focus();
                return;
            }
            else if (!int.TryParse(txtBuscar.Text, out int numeroFactura))
            {
                MessageBox.Show("El número de factura debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBuscar.Focus();
                return;
            }
            else if (numeroFactura < 1)
            {
                MessageBox.Show("El número de factura debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBuscar.Focus();
                return;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                MessageBox.Show("Compra registrada correctamente", "Compra registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GenerarNumeroFactura();
                LimpiarCampos();
                return;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
