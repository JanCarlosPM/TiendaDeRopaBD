﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TiendaDeRopa.Datos;

namespace TiendaDeRopa.Presentacion
{
    public partial class Frm_Productos : Form
    {

        private DataTable datosOriginales;
        public Frm_Productos()
        {
            InitializeComponent();
            ListarProductos();
            AsignarEventosTextBox();
            dgvProductos.CellClick += dgvProductos_CellClick;
        }


        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                string categoria = fila.Cells["Categoria"].Value.ToString();
                string tela = fila.Cells["Tela"].Value.ToString();
                string talla = fila.Cells["Talla"].Value.ToString();
                string estilo = fila.Cells["Estilo"].Value.ToString();
                string descripcion = fila.Cells["Descripcion"].Value.ToString();
                string marca = fila.Cells["Marca"].Value.ToString();
                string Proveedor = fila.Cells["Proveedor"].Value.ToString();
                string precio = fila.Cells["Precio"].Value.ToString();

                txtCategoria.Text = categoria;
                txtTela.Text = tela;
                txtTalla.Text = talla;
                txtEstilo.Text = estilo;
                txtDescripcion.Text = descripcion;
                txtMarca.Text = marca;
                cbProveedor.Text = Proveedor;
                txtPrecio.Text = precio;

                txtCategoria.Enabled = false;
            }
        }


        private void TextBoxLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBoxNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void AsignarEventosTextBox()
        {
            txtCategoria.KeyPress += TextBoxLetras_KeyPress;
            txtTela.KeyPress += TextBoxLetras_KeyPress;
            txtTalla.KeyPress += TextBoxLetras_KeyPress;
            txtEstilo.KeyPress += TextBoxLetras_KeyPress;
            txtDescripcion.KeyPress += TextBoxLetras_KeyPress;
            txtMarca.KeyPress += TextBoxLetras_KeyPress;
            txtPrecio.KeyPress += TextBoxNumeros_KeyPress;
            txtCategoria.KeyPress += TextBoxLetras_KeyPress;
        }


        private void ListarProductos()
        {
            D_Producto productos = new D_Producto();
            datosOriginales = productos.ListarProductos();
            dgvProductos.DataSource = datosOriginales;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == "" || txtTela.Text == "" || txtTalla.Text == "" || txtEstilo.Text == "" || txtDescripcion.Text == "" || txtMarca.Text == "" || txtPrecio.Text == "" || cbProveedor.Text == "Seleccionar")
            {
                MessageBox.Show("Debe completar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreProveedor = cbProveedor.Text;
            string categoria = txtCategoria.Text;
            string tela = txtTela.Text;
            string talla = txtTalla.Text;
            string estilo = txtEstilo.Text;
            string descripcion = txtDescripcion.Text;
            string marca = txtMarca.Text;
            float precio = float.Parse(txtPrecio.Text);

            D_Producto producto = new D_Producto();
            string mensaje = producto.EditarProducto(categoria, tela, talla, estilo, descripcion, marca, nombreProveedor, precio);

            MessageBox.Show(mensaje, "Producto Editado con Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ListarProductos();
        }



        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            LlenarComboProveedores();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void LlenarComboProveedores()
        {
            D_Proveedor proveedor = new D_Proveedor();
            DataTable nombres = proveedor.ObtenerNombresProveedores();

            DataRow filaPredeterminada = nombres.NewRow();
            filaPredeterminada["nombre"] = "Seleccionar";
            nombres.Rows.InsertAt(filaPredeterminada, 0);

            cbProveedor.DisplayMember = "nombre";
            cbProveedor.DataSource = nombres;

            cbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = "";
            txtTela.Text = "";
            txtTalla.Text = "";
            txtEstilo.Text = "";
            txtDescripcion.Text = "";
            txtMarca.Text = "";
            txtPrecio.Text = "";
            cbProveedor.Text = "Seleccionar";

            txtCategoria.Enabled = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (txtCategoria.Text == "" || txtTela.Text == "" || txtTalla.Text == "" || txtEstilo.Text == "" || txtDescripcion.Text == "" || txtMarca.Text == "" || txtPrecio.Text == "" || cbProveedor.Text == "Seleccionar")
            {
                MessageBox.Show("Debe completar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string categoria = txtCategoria.Text;
            string tela = txtTela.Text;
            string talla = txtTalla.Text;
            string estilo = txtEstilo.Text;
            string descripcion = txtDescripcion.Text;
            string marca = txtMarca.Text;
            string nombre_proveedor = cbProveedor.Text;
            float precio = float.Parse(txtPrecio.Text);

            D_Producto producto = new D_Producto();
            D_Proveedor proveedor = new D_Proveedor();

            string mensaje = producto.InsertarProducto(categoria, tela, talla, estilo, descripcion, marca, nombre_proveedor, precio);

            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ListarProductos();
        }
    }
}