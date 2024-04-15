using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TiendaDeRopa.Datos;
using TiendaDeRopa.Entidades;

namespace TiendaDeRopa.formularios
{
    public partial class Frm_Compras : Form
    {

        private DataTable datosOriginales;

        public Frm_Compras()
        {
            InitializeComponent();
            GenerarNumeroFactura();
            dgvDetallesCompras.Columns.Add("Categoria", "Categoria");
            dgvDetallesCompras.Columns.Add("Precio", "Precio");
            dgvDetallesCompras.Columns.Add("Cantidad", "Cantidad");
            dgvDetallesCompras.CellClick += dgvDetallesCompras_CellClick;
            dgvProductos.CellClick += dgvProductos_CellClick;

            ListarProductos();
            ObtenerFechaActual();

            txtCantidad.Enabled = false;
            btnListarProducto.Enabled = false;
            btnEliminar.Enabled = false;
            btnInsertar.Enabled = false;
            btnLimpiar.Enabled = false;
            btnCancelar.Visible = false;
            txtSubTotal.Text = "0";
            txtIVA.Text = "0";
            txtTotal.Text = "0";
        }

        private void ListarProductos()
        {
            D_Producto productos = new D_Producto();
            datosOriginales = productos.ListarProductos();
            dgvProductos.DataSource = datosOriginales;
        }
        private void ObtenerFechaActual()
        {
            txtFechaCompra.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaCompra.Enabled = false;
            txtSubTotal.Enabled = false;
            txtIVA.Enabled = false;
            txtTotal.Enabled = false;
        }
        private void GenerarNumeroFactura()
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

                        txtNumeroFactura.Text = proximoNumeroFactura;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar número de factura: " + ex.Message);
            }
        }


        private bool ValidarCampos()
        {
            if (txtFechaCompra.Text == "" || txtSubTotal.Text == "" || txtIVA.Text == "" || txtTotal.Text == "" || (!cbEfectivo.Checked && !cbTarjeta.Checked))
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

            if (txtSubTotal.Text == "0" || txtIVA.Text == "0" || txtTotal.Text == "0")
            {
                MessageBox.Show("Debe ingresar productos en la tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubTotal.Focus();
                return false;
            }

            if (!double.TryParse(txtSubTotal.Text, out _))
            {
                MessageBox.Show("El subtotal debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubTotal.Focus();
                return false;
            }

            if (!double.TryParse(txtIVA.Text, out _))
            {
                MessageBox.Show("El IVA debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIVA.Focus();
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
            txtCategoria.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            cbEfectivo.Checked = false;
            cbTarjeta.Checked = false;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtCantidad.Enabled = false;
            btnListarProducto.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string categoria = txtBuscar.Text.Trim();

            D_Producto producto = new D_Producto();
            dgvProductos.DataSource = producto.ListarProductosFiltro(categoria);
        }

        private bool ValidateGrid()
        {
            foreach (DataGridViewRow row in dgvDetallesCompras.Rows)
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
           if (ValidarCampos())
            {
                if (ValidateGrid())
                {
                    MessageBox.Show("Tabla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GenerarNumeroFactura();

                string rpta = "";
                E_Factura factura = new E_Factura()
                {
                    cod_factura = txtNumeroFactura.Text,
                    fecha = DateTime.Parse(txtFechaCompra.Text),
                    subtotal = float.Parse(txtSubTotal.Text),
                    iva = float.Parse(txtIVA.Text),
                    total = float.Parse(txtTotal.Text),
                    forma_pago = cbEfectivo.Checked ? "Efectivo" : "Tarjeta",
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

                    foreach (DataGridViewRow fila in dgvDetallesCompras.Rows)
                    {
                        string categoria = fila.Cells["Categoria"].Value.ToString();
                        int cantidad = int.Parse(fila.Cells["Cantidad"].Value.ToString());
                        float precio = float.Parse(fila.Cells["Precio"].Value.ToString());

                        categorias.Add(categoria);
                        cantidades.Add(cantidad);
                        precios.Add(precio);
                    }

                    string idFactura = txtNumeroFactura.Text;

                    D_DetalleFactura detalleFactura = new D_DetalleFactura();
                    rpta = detalleFactura.GuardarCompra(listaDetalles, categorias, cantidades, precios, idFactura);

                    if (rpta.Equals("Todos los detalles de la factura se registraron correctamente."))
                    {
                        LimpiarCampos();
                        GenerarNumeroFactura();
                        btnLimpiar.Enabled = true;
                        btnEliminar.Enabled = true;
                        dgvDetallesCompras.Rows.Clear();
                        txtSubTotal.Text = "0";
                        txtIVA.Text = "0";
                        txtTotal.Text = "0";
                        cbEfectivo.Checked = false;
                        cbTarjeta.Checked = false;
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
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvDetallesCompras.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvDetallesCompras.SelectedRows[0];

                dgvDetallesCompras.Rows.Remove(filaSeleccionada);

                CalcularSubTotal();

                LimpiarCampos();

                txtCantidad.Enabled = false;
                btnInsertar.Enabled = true;
                btnListarProducto.Enabled = true;
                btnLimpiar.Enabled = true;
                btnCancelar.Visible = false;
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void wfCompras_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvProductos.Rows[e.RowIndex];

                txtCategoria.Text = filaSeleccionada.Cells["Categoria"].Value.ToString();
                txtPrecio.Text = filaSeleccionada.Cells["Precio"].Value.ToString();

                txtCantidad.Enabled = true;
                btnListarProducto.Enabled = true;
            }
        }
        private void dgvDetallesCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetallesCompras.Rows[e.RowIndex].Cells["Categoria"].Value != null &&
                dgvDetallesCompras.Rows[e.RowIndex].Cells["Precio"].Value != null &&
                dgvDetallesCompras.Rows[e.RowIndex].Cells["Cantidad"].Value != null)
            {
                DataGridViewRow filaSeleccionada = dgvDetallesCompras.Rows[e.RowIndex];

                txtCategoria.Text = filaSeleccionada.Cells["Categoria"].Value.ToString();
                txtPrecio.Text = filaSeleccionada.Cells["Precio"].Value.ToString();
                txtCantidad.Text = filaSeleccionada.Cells["Cantidad"].Value.ToString();

                txtCantidad.Enabled = false;
                btnListarProducto.Enabled = false;
                btnEliminar.Enabled = true;
                btnInsertar.Enabled = false;
                btnCancelar.Visible = true;
            }
            else
            {
                MessageBox.Show("Celda sin Datos, seleccione otra", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnListarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoria.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Debe seleccionar un producto y/o llenar el campo cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string descripcion = txtCategoria.Text;
            double precio;
            int cantidad;

            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("La Cantidad debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El campo 'Precio' debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvDetallesCompras.Rows.Add(descripcion, precio, cantidad);

            CalcularSubTotal();
            ActualizarEstadoBotones();
            LimpiarCampos();

            btnEliminar.Enabled = true;
            btnInsertar.Enabled = true;
            dgvDetallesCompras.ClearSelection();
            btnListarProducto.Enabled = false;
            txtCantidad.Enabled = false;
        }

        private void CalcularSubTotal()
        {
            double subtotal = 0;
            double iva = 0;
            double total = 0;

            foreach (DataGridViewRow fila in dgvDetallesCompras.Rows)
            {
                double precio = Convert.ToDouble(fila.Cells["Precio"].Value);
                int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                subtotal += precio * cantidad;
            }

            iva = subtotal * 0.15;
            total = subtotal + iva;

            txtIVA.Text = iva.ToString();
            txtSubTotal.Text = subtotal.ToString();
            txtTotal.Text = total.ToString();
        }
        private void ActualizarEstadoBotones()
        {

            if (dgvDetallesCompras.RowCount > 0)
            {
                btnLimpiar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                btnLimpiar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                ListarProductos();
            }
        }
        private void dgvDetallesCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";

            btnCancelar.Visible = false;
            btnInsertar.Enabled = true;
            btnListarProducto.Enabled = false;
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIVA_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFechaCompra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}