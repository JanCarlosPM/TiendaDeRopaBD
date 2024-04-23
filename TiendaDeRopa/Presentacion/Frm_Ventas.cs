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
        private DataTable dataProductos;

        public Frm_Ventas()
        {
            InitializeComponent();
            GenerarNumeroFacturaVenta();
            dgvDetalleVenta.Columns.Add("Categoria", "Categoria");
            dgvDetalleVenta.Columns.Add("Precio", "Precio");
            dgvDetalleVenta.Columns.Add("Cantidad", "Cantidad");
            dgvDetalleVenta.Columns.Add("Fecha de Ingreso", "Fecha de Ingreso");
            dgvDetalleVenta.CellClick += dgvDetalleVenta_CellClick;
            dgvVenta.CellClick += dgvVenta_CellContentClick;

            ListarProductos();
            ObtenerFechaActual();
            Txt_BuscarVenta.KeyPress += txtBuscarVenta_KeyPress;
            txtCantidaVenta.KeyPress += txtCantidadVenta_KeyPress;

            txtCantidaVenta.Enabled = false;
            Btn_ListaVenta.Enabled = false;
            BtnEliminarProductoVenta.Enabled = false;
            BtnfInsertarVenta.Enabled = false;
            Btn_LimpiarVenta.Enabled = false;
            BtnCancelarVenta.Visible = false;
            txtSubVenta.Text = "0";
            txtIvaVenta.Text = "0";
            txtTotalVenta.Text = "0";
        }
        private void ListarProductos()
        {
            D_Inventario inventario = new D_Inventario();
            dataProductos = inventario.ListarInventario();
            dgvVenta.DataSource = dataProductos;
        }
        private void ObtenerFechaActual()
        {
            txtFechaVenta.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
        private void txtCantidadVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuscarVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
                MessageBox.Show("La tabla no contiene productos y/o seleccione una forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            int cantidadSeleccionada;
            if (!int.TryParse(txtCantidaVenta.Text, out cantidadSeleccionada) || cantidadSeleccionada <= 0)
            {
                MessageBox.Show("La Cantidad debe ser un número entero mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow fila in dgvVenta.Rows)
            {
                if (fila.Cells["Categoria"].Value.ToString() == txtCategoriaVenta.Text)
                {
                    int cantidadEnStock = Convert.ToInt32(fila.Cells["existencia"].Value);
                    if (cantidadSeleccionada > cantidadEnStock)
                    {
                        MessageBox.Show("La cantidad ingresada es mayor que la existencia en stock del producto y/o el producto no cuenta con stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int nuevaExistencia = cantidadEnStock - cantidadSeleccionada;
                    fila.Cells["existencia"].Value = nuevaExistencia;

                    break;
                }
            }

            string descripcion = txtCategoriaVenta.Text;
            double precio;
            int cantidad;
            string fechaIngreso = txtFechaVenta.Text;

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

            dgvDetalleVenta.Rows.Add(descripcion, precio, cantidad, fechaIngreso);

            CalcularSubtotalVenta();
            ActEstadoBtnVenta();
            limpiarcampos();

            BtnEliminarProductoVenta.Enabled = true;
            BtnfInsertarVenta.Enabled = true;
            dgvDetalleVenta.ClearSelection();
            Btn_ListaVenta.Enabled = false;
            txtCantidaVenta.Enabled = false;
            BtnfInsertarVenta.Enabled = true;
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

        private void dgvDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalleVenta.Rows[e.RowIndex].Cells["Categoria"].Value != null &&
                dgvDetalleVenta.Rows[e.RowIndex].Cells["Precio"].Value != null &&
                dgvDetalleVenta.Rows[e.RowIndex].Cells["Cantidad"].Value != null)
            {
                DataGridViewRow filaSeleccionada = dgvDetalleVenta.Rows[e.RowIndex];

                txtCategoriaVenta.Text = filaSeleccionada.Cells["Categoria"].Value.ToString();
                txtPrecioVenta.Text = filaSeleccionada.Cells["Precio"].Value.ToString();
                txtCantidaVenta.Text = filaSeleccionada.Cells["Cantidad"].Value.ToString();

                dgvVenta.Enabled = false;
                txtCantidaVenta.Enabled = false;
                Btn_ListaVenta.Enabled = false;
                BtnEliminarProductoVenta.Enabled = true;
                BtnfInsertarVenta.Enabled = false;
                BtnCancelarVenta.Visible = true;
            }
            else
            {
                MessageBox.Show("Celda sin Datos, seleccione otra", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEliminarProductoVenta_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvDetalleVenta.SelectedRows[0];

                string categoriaEliminada = filaSeleccionada.Cells["Categoria"].Value.ToString();
                int cantidadEliminada = Convert.ToInt32(filaSeleccionada.Cells["Cantidad"].Value);

                // Recuperar la fila correspondiente en dgvVenta
                foreach (DataGridViewRow fila in dgvVenta.Rows)
                {
                    if (fila.Cells["Categoria"].Value.ToString() == categoriaEliminada)
                    {
                        int existenciaActual = Convert.ToInt32(fila.Cells["existencia"].Value);
                        fila.Cells["existencia"].Value = existenciaActual + cantidadEliminada;
                        break;
                    }
                }

                dgvDetalleVenta.Rows.Remove(filaSeleccionada);

                CalcularSubtotalVenta();
                limpiarcampos();

                txtCantidaVenta.Enabled = false;
                BtnfInsertarVenta.Enabled = true;
                Btn_ListaVenta.Enabled = true;
                Btn_LimpiarVenta.Enabled = true;
                BtnCancelarVenta.Visible = false;
                dgvVenta.Enabled = true;
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
                    tipo = 2
                };

                D_Factura dfactura = new D_Factura();
                rpta = dfactura.GuardarFactura(factura);

                if (rpta.Equals("Compra registrada correctamente"))
                {
                    MessageBox.Show("Compra registrada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    List<E_Inventario> listaInventario1 = new List<E_Inventario>();
                    List<string> categoriasStock = new List<string>();
                    List<int> cantidadesStock = new List<int>();
                    List<DateTime> fechasIngresoStock = new List<DateTime>();

                    List<E_DetalleFactura> listaDetalles = new List<E_DetalleFactura>();
                    List<string> categorias = new List<string>();
                    List<int> cantidades = new List<int>();
                    List<float> precios = new List<float>();

                    foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
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

                    string idFactura = txtNumFacVenta.Text;

                    D_DetalleFactura detalleFactura = new D_DetalleFactura();
                    rpta = detalleFactura.GuardarDetalleFactura(listaDetalles, categorias, cantidades, precios, idFactura);

                    D_Inventario inventario = new D_Inventario();
                    rpta = inventario.ActualizarStockVenta(listaInventario1, categoriasStock, cantidadesStock, fechasIngresoStock);

                    if (rpta.Equals("El stock del inventario se actualizó correctamente."))
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
                        ListarProductos();
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

        private void Btn_LimpiarVenta_Click(object sender, EventArgs e)
        {
            limpiarcampos();
            txtCantidaVenta.Enabled = false;
            Btn_ListaVenta.Enabled = false;
        }

        private void dgvVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void CbEfectivoVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (CbEfectivoVenta.Checked)
            {
                CbTarjetaVenta.Checked = false;
            }
        }

        private void CbTarjetaVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (CbTarjetaVenta.Checked)
            {
                CbEfectivoVenta.Checked = false;
            }
        }

        private void BtnCancelarVenta_Click(object sender, EventArgs e)
        {
            txtCategoriaVenta.Text = "";
            txtPrecioVenta.Text = "";
            txtCantidaVenta.Text = "";

            BtnCancelarVenta.Visible = false;
            BtnfInsertarVenta.Enabled = true;

            dgvVenta.Enabled = true;
            dgvDetalleVenta.ClearSelection();
        }
    }   
}