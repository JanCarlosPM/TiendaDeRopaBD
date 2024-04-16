using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TiendaDeRopa.Datos;
using TiendaDeRopa.Entidades;

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
        private void CalcularSubtotalVenta()
        {
            double subtotal = 0;
            double iva = 0;
            double total = 0;

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                double precio = Convert.ToDouble(fila.Cells["Precio"].Value);
                int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                subtotal += precio * cantidad;
            }

            iva = subtotal * 0.15;
            total = subtotal + iva;

            txtIvaVenta.Text = iva.ToString();
            txtSubVenta.Text = subtotal.ToString();
            txtTotalVenta.Text = total.ToString();
        }
        private void ActEstadoBtnVenta()
        {
            if (dgvDetalleVenta.RowCount > 0)
            {
                Btn_LimpiarVenta.Enabled = false;
                BtnEliminarProductoVenta.Enabled = false;
            }
            else
            {
                Btn_LimpiarVenta.Enabled = true;
                BtnEliminarProductoVenta.Enabled = true;
            }
            
        }
        private void limpiarcampos()
        {
            txtCategoriaVenta.Text = "";
            txtPrecioVenta.Text = "";
            txtCantidaVenta.Text = "";
            CbEfectivoVenta.Checked = false;
            CbTarjetaVenta.Checked = false;
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

            if (!CbEfectivoVenta.Checked && !CbTarjetaVenta.Checked)
            {
                MessageBox.Show("Debe seleccionar la forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool ValidateGrid()
        {
            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        return false;
                    }
                }
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
            if (string.IsNullOrWhiteSpace(txtCategoriaVenta.Text) || string.IsNullOrWhiteSpace(txtPrecioVenta.Text) || string.IsNullOrWhiteSpace(txtCantidaVenta.Text))
            {
                MessageBox.Show("Debe seleccionar un producto y/o llenar el campo cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string descripcion = txtCategoriaVenta.Text;
            double precio;
            int cantidad;

            if (!int.TryParse(txtCantidaVenta.Text, out cantidad))
            {
                MessageBox.Show("La Cantidad debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtPrecioVenta.Text, out precio))
            {
                MessageBox.Show("El campo 'Precio' debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvDetalleVenta.Rows.Add(descripcion, precio, cantidad);

            CalcularSubtotalVenta();
            ActEstadoBtnVenta();
            limpiarcampos();

            BtnEliminarProductoVenta.Enabled = true;
            BtnfInsertarVenta.Enabled = true;
            dgvDetalleVenta.ClearSelection();
            Btn_ListaVenta.Enabled = false;
            txtCantidaVenta.Enabled = false;
        }

        private void Btn_BuscarVenta_Click(object sender, EventArgs e)
        {
            string categoria = Txt_BuscarVenta.Text.Trim();

            D_Producto producto = new D_Producto();
            dgvVenta.DataSource = producto.ListarProductosFiltro(categoria);
        }

        private void Txt_BuscarVenta_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_BuscarVenta.Text))
            {
                ListarProductos();
            }
        }

        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoriaVenta.Text) || string.IsNullOrWhiteSpace(txtPrecioVenta.Text) || string.IsNullOrWhiteSpace(txtCantidaVenta.Text))
            {
                MessageBox.Show("Debe seleccionar un producto y/o llenar el campo cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string descripcion = txtCategoriaVenta.Text;
            double precio;
            int cantidad;

            if (!int.TryParse(txtCantidaVenta.Text, out cantidad))
            {
                MessageBox.Show("La Cantidad debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtPrecioVenta.Text, out precio))
            {
                MessageBox.Show("El campo 'Precio' debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvDetalleVenta.Rows.Add(descripcion, precio, cantidad);
            
             CalcularSubtotalVenta();
            ActEstadoBtnVenta();
            limpiarcampos();

             BtnEliminarProductoVenta.Enabled = true;
             BtnfInsertarVenta.Enabled = true;
             dgvDetalleVenta.ClearSelection();
             Btn_ListaVenta.Enabled = false;
             txtCantidaVenta.Enabled = false;
             
        }

        private void BtnEliminarProductoVenta_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvDetalleVenta.SelectedRows[0];

                dgvDetalleVenta.Rows.Remove(filaSeleccionada);

                CalcularSubtotalVenta();

                limpiarcampos();

                txtCantidaVenta.Enabled = false;
                BtnfInsertarVenta.Enabled = true;
                Btn_ListaVenta.Enabled = true;
                Btn_LimpiarVenta.Enabled = true;
                BtnCancelarVenta.Visible = false;
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnfInsertarVenta_Click(object sender, EventArgs e)
        {
            if (ValidarCamposVenta())
            {
                if (ValidateGrid())
                {
                    MessageBox.Show("Tabla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GenerarNumeroFacturaVenta();

                string rpta = "";
                E_Factura factura = new E_Factura()
                {
                    cod_factura = txtNumFacVenta.Text,
                    fecha = DateTime.Parse(txtFechaVenta.Text),
                    subtotal = float.Parse(txtSubVenta.Text),
                    iva = float.Parse(txtIvaVenta.Text),
                    total = float.Parse(txtTotalVenta.Text),
                    forma_pago = CbEfectivoVenta.Checked ? "Efectivo" : "Tarjeta",
                    tipo = 1
                };

                D_Factura dfactura = new D_Factura();
                rpta = dfactura.GuardarCompra(factura);

                if (rpta.Equals("Compra registrada correctamente"))
                {
                    MessageBox.Show("Compra registrada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    List<E_DetalleFactura> listaDetalles = new List<E_DetalleFactura>();
                    List<string> categorias = new List<string>();
                    List<int> cantidades = new List<int>();
                    List<float> precios = new List<float>();

                    foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
                    {
                        string categoria = fila.Cells["Categoria"].Value.ToString();
                        int cantidad = int.Parse(fila.Cells["Cantidad"].Value.ToString());
                        float precio = float.Parse(fila.Cells["Precio"].Value.ToString());

                        categorias.Add(categoria);
                        cantidades.Add(cantidad);
                        precios.Add(precio);
                    }

                    string idFactura = txtNumFacVenta.Text;

                    D_DetalleFactura detalleFactura = new D_DetalleFactura();
                    rpta = detalleFactura.GuardarCompra(listaDetalles, categorias, cantidades, precios, idFactura);

                    if (rpta.Equals("Todos los detalles de la factura se registraron correctamente."))
                    {
                        limpiarcampos();
                        GenerarNumeroFacturaVenta();
                        Btn_LimpiarVenta.Enabled = true;
                        BtnEliminarProductoVenta.Enabled = true;
                        dgvDetalleVenta.Rows.Clear();
                        txtSubVenta.Text = "0";
                        txtIvaVenta.Text = "0";
                        txtTotalVenta.Text = "0";
                        CbEfectivoVenta.Checked = false;
                        CbTarjetaVenta.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show(rpta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(rpta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCantidaVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_LimpiarVenta_Click(object sender, EventArgs e)
        {
            limpiarcampos();
            txtCantidaVenta.Enabled = false;
            Btn_ListaVenta.Enabled = false;
        }
    }


   
}


