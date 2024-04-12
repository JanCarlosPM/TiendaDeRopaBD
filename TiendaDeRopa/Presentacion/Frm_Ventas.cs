using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiendaDeRopa.Datos;

namespace TiendaDeRopa.Presentacion
{
    public partial class Frm_Ventas : Form
    {
        private DataTable datosVenta;
        public Frm_Ventas()
        {
            InitializeComponent();
        }
        private void ListarProductos()
        {
            D_Producto productos = new D_Producto();
            datosVenta = productos.ListarProductos();
            dgvVenta.DataSource = datosVenta;
        }
        private void ObtenerFechaActual()
        {
            txtFechaVenta.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaVenta.Enabled = false;
            txtSubVenta.Enabled = false;
            txtIvaVenta.Enabled = false;
            txtTotalVenta.Enabled = false;
        }
        private void GenerarNumeroFacturaVenta()
        {
            try
            {
                using (SqlConnection sqlCon = Conexion.getInstancia().CrearConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_NumeroFactura", sqlCon))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        sqlCon.Open();

                        string proximoNumeroFactura = (string)comando.ExecuteScalar();

                        txtNumFacVenta.Text = proximoNumeroFactura;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar número de factura: " + ex.Message);
            }
        }
        private bool ValidarCamposVenta()
        {
            if (txtFechaVenta.Text == "" || txtSubVenta.Text == "" || txtIvaVenta.Text == "" || txtTotalVenta.Text == "" || (!CbEfectivoVenta.Checked && !CbTarjetaVenta.Checked))
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtFechaVenta.Text == "")
            {
                MessageBox.Show("Debe ingresar la fecha de la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFechaVenta.Focus();
                return false;
            }

            if (txtSubVenta.Text == "0" || txtIvaVenta.Text == "0" || txtTotalVenta.Text == "0")
            {
                MessageBox.Show("Debe ingresar productos en la tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubVenta.Focus();
                return false;
            }

            if (!double.TryParse(txtSubVenta.Text, out _))
            {
                MessageBox.Show("El subtotal debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubVenta.Focus();
                return false;
            }

            if (!double.TryParse(txtIvaVenta.Text, out _))
            {
                MessageBox.Show("El IVA debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIvaVenta.Focus();
                return false;
            }

            if (!double.TryParse(txtTotalVenta.Text, out _))
            {
                MessageBox.Show("El total debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalVenta.Focus();
                return false;
            }

            if (!CbEfectivoVenta.Checked && !CbTarjetaVenta.Checked)
            {
                MessageBox.Show("Debe seleccionar la forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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

        private void Btn_BuscarVenta_Click(object sender, EventArgs e)
        {
            string categoria = Txt_BuscarVenta.Text.Trim();

            D_Producto producto = new D_Producto();
            dgvVenta.DataSource = producto.ListarProductosFiltro(categoria);
        }

        private void Txt_BuscarVenta_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Txt_BuscarVenta.Text))
            {
                ListarProductos();
            }
        }
    }
}
