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

        private DataTable dataProductos;

        public Frm_Compras()
        {
            InitializeComponent();
            GenerarNumeroFactura();
            dgvDetallesCompras.Columns.Add("Categoria", "Categoria");
            dgvDetallesCompras.Columns.Add("Precio", "Precio");
            dgvDetallesCompras.Columns.Add("Cantidad", "Cantidad");
            dgvDetallesCompras.Columns.Add("Fecha de Ingreso", "Fecha de Ingreso");
            dgvDetallesCompras.CellClick += dgvDetallesCompras_CellClick;
            dgvProductos.CellClick += dgvProductos_CellClick;

            ListarProductos();
            ObtenerFechaActual();
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            txtCantidad.KeyPress += txtCantidad_KeyPress;

            cbEfectivo.Enabled = false;
            cbTarjeta.Enabled = false;
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
            dataProductos = productos.ListarProductos();
            dgvProductos.DataSource = dataProductos;
        }
        private void ObtenerFechaActual()
        {
            txtFechaCompra.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            btnEliminar.Enabled = false;
            btnInsertar.Enabled = false;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
                rpta = dfactura.GuardarFactura(factura);

                if (rpta.Equals("Compra registrada correctamente"))
                {
                    MessageBox.Show("Compra registrada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    List<E_Inventario> listaInventario = new List<E_Inventario>();
                    List<string> categoriasStock = new List<string>();
                    List<int> cantidadesStock = new List<int>();
                    List<DateTime> fechasIngresoStock = new List<DateTime>();

                    List<E_DetalleFactura> listaDetalles = new List<E_DetalleFactura>();
                    List<string> categorias = new List<string>();
                    List<int> cantidades = new List<int>();
                    List<float> precios = new List<float>();

                    foreach (DataGridViewRow fila in dgvDetallesCompras.Rows)
                    {
                        string categoria = fila.Cells["Categoria"].Value.ToString();
                        int cantidad = int.Parse(fila.Cells["Cantidad"].Value.ToString());
                        float precio = float.Parse(fila.Cells["Precio"].Value.ToString());
                        DateTime fechaIngresoStock = DateTime.Parse(fila.Cells["Fecha de Ingreso"].Value.ToString());

                        categorias.Add(categoria);
                        cantidades.Add(cantidad);
                        precios.Add(precio);
                        categoriasStock.Add(categoria);
                        cantidadesStock.Add(cantidad);
                        fechasIngresoStock.Add(fechaIngresoStock);
                    }

                    string idFactura = txtNumeroFactura.Text;

                    D_Inventario inventario = new D_Inventario();
                    rpta = inventario.ActualizarStock(listaInventario, categoriasStock, cantidadesStock, fechasIngresoStock);

                    D_DetalleFactura detalleFactura = new D_DetalleFactura();
                    rpta = detalleFactura.GuardarDetalleFactura(listaDetalles, categorias, cantidades, precios, idFactura);

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
                    LimpiarCampos();

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
                dgvProductos.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

                dgvProductos.Enabled = false;
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
            string fechaIngreso = txtFechaCompra.Text;

            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("La Cantidad debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cantidad < 0)
            {
                MessageBox.Show("La Cantidad no puede ser un número negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El campo 'Precio' debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvDetallesCompras.Rows.Add(descripcion, precio, cantidad, fechaIngreso);

            CalcularSubTotal();
            ActualizarEstadoBotones();
            LimpiarCampos();

            btnEliminar.Enabled = true;
            btnInsertar.Enabled = true;
            dgvDetallesCompras.ClearSelection();
            btnListarProducto.Enabled = false;
            txtCantidad.Enabled = false;
            cbTarjeta.Enabled = true;
            cbEfectivo.Enabled = true;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";

            btnCancelar.Visible = false;
            btnInsertar.Enabled = true;
            btnListarProducto.Enabled = false;

            dgvProductos.Enabled = true;
            dgvDetallesCompras.ClearSelection();
        }

        private void cbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEfectivo.Checked)
            {
                cbTarjeta.Checked = false;
            }
        }

        private void cbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTarjeta.Checked)
            {
                cbEfectivo.Checked = false;
            }
        }
    }
}
