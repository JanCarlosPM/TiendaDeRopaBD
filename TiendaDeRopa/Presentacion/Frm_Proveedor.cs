using System;
using System.Windows.Forms;
using TiendaDeRopa.Datos;
using TiendaDeRopa.Entidades;
using System.Text.RegularExpressions;

namespace TiendaDeRopa.Presentacion
{
    public partial class Frm_Proveedor : Form
    {
        private int nEstadoguarda = 0;
        private int idProv = 0;

        // Expresiónes regulares (RegEx) para validacion de campos especiales.
        Regex formatoLetras = new Regex("^[a-zA-Z]+$");
        Regex formatoTelefono = new Regex("^[2578][0-9]{7}$");
        Regex formatoCorreo = new Regex("^[a-zA-Z0-9]{5,50}@[a-zA-Z]{3,10}\\.[a-zA-Z]{2,4}$");

        public Frm_Proveedor()
        {
            InitializeComponent();
        }

        private void LimpiaTexto()
        {
            txtNombre_pr.Text = "";
            txtEmail_pr.Text = "";
            txtTelefono_pr.Text = "";
            txtDireccion_pr.Text = "";
        }
        private void EstadoTexto(bool lEstado)
        {
            txtNombre_pr.Enabled = lEstado;
            txtEmail_pr.Enabled = lEstado;
            txtTelefono_pr.Enabled = lEstado;
            txtDireccion_pr.Enabled = lEstado;
        }

        private void EstadoBotones(bool lEstado)
        {
            btnCancelar_pr.Visible = !lEstado;
            btnGuardar_pr.Visible = !lEstado;

            btnNuevo_pr.Enabled = lEstado;
            btnActualizar_pr.Enabled = lEstado;
            btnEliminar_pr.Enabled = lEstado;
            btnSalir_pr.Enabled = lEstado;

            btnBuscar_pr.Enabled = lEstado;
            txtBuscar_pr.Enabled = lEstado;
            dgvListado_prov.Enabled = lEstado;
        }

        private void Formato_prov()
        {
            dgvListado_prov.Columns[0].Width = 50;
            dgvListado_prov.Columns[0].HeaderText = "ID";
            dgvListado_prov.Columns[1].Width = 100;
            dgvListado_prov.Columns[1].HeaderText = "PROVEEDOR";
            dgvListado_prov.Columns[2].Width = 150;
            dgvListado_prov.Columns[2].HeaderText = "EMAIL";
            dgvListado_prov.Columns[3].Width = 75;
            dgvListado_prov.Columns[3].HeaderText = "TELEFONO";
            dgvListado_prov.Columns[4].Width = 350;
            dgvListado_prov.Columns[4].HeaderText = "DIRECCION";
        }
        
        private void Listado_prov(string cTexto)
        {
            D_Proveedor Datos = new D_Proveedor();
            dgvListado_prov.DataSource = Datos.Listado_prov(cTexto);
            Formato_prov();
        }

        private void Selecciona_Item_prov()
        {
            if (dgvListado_prov.CurrentRow == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(dgvListado_prov.CurrentRow.Cells["id"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                btnActualizar_pr.Enabled = true;
                btnEliminar_pr.Enabled = true;

                idProv = Convert.ToInt32(dgvListado_prov.CurrentRow.Cells["id"].Value);
                txtNombre_pr.Text = Convert.ToString(dgvListado_prov.CurrentRow.Cells["nombre"].Value);
                txtEmail_pr.Text = Convert.ToString(dgvListado_prov.CurrentRow.Cells["email"].Value);
                txtTelefono_pr.Text = Convert.ToString(dgvListado_prov.CurrentRow.Cells["telefono"].Value);
                txtDireccion_pr.Text = Convert.ToString(dgvListado_prov.CurrentRow.Cells["direccion"].Value);
            }

        }

        private void btnNuevo_pr_Click(object sender, EventArgs e)
        {
            nEstadoguarda = 1; //Nuevo Registro
            idProv = 0;
            LimpiaTexto();
            EstadoTexto(true);
            EstadoBotones(false);
            txtNombre_pr.Select();
        }

        private void btnCancelar_pr_Click(object sender, EventArgs e)
        {
            LimpiaTexto();
            EstadoTexto(false);
            EstadoBotones(true);
        }

        private void btnGuardar_pr_Click(object sender, EventArgs e)
        {
            
            string nombre = txtNombre_pr.Text;
            string telefono = txtTelefono_pr.Text;
            string correo = txtEmail_pr.Text;
            string direccion = txtDireccion_pr.Text;

            if (nombre == string.Empty || telefono == string.Empty ||
               correo == string.Empty || direccion == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (!formatoLetras.IsMatch(nombre))
            {
                MessageBox.Show("El nombre solo debe contener caracteres alfabéticos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(telefono, out int tel))
            {
                MessageBox.Show("El telefono solo deben ser números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!formatoTelefono.IsMatch(telefono))
            {
                MessageBox.Show("El formato del telefono ingresado no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!formatoCorreo.IsMatch(correo)) 
            {
                MessageBox.Show("El formato del correo ingresado no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Se procede aguardado si cumple con la validacion
            string Rpta = "";
            E_Proveedor oProv = new E_Proveedor();
            oProv.id = this.idProv;
            oProv.nombre = nombre;
            oProv.email = correo;
            oProv.telefono = telefono;
            oProv.direccion = direccion;
            
            D_Proveedor Datos = new D_Proveedor();
            Rpta = Datos.Guardar_prov(this.nEstadoguarda, oProv); //por el procedimiento o se guarda o actualiza
            
            if (Rpta == "OK")
            {
                this.Listado_prov("%");
                MessageBox.Show("Los datos han sido guardados correctamente",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.idProv = 0;
                this.LimpiaTexto();
                this.EstadoTexto(false);
                this.EstadoBotones(true);
            }
        }

        private void Frm_Proveedor_Load(object sender, EventArgs e)
        {
            this.Listado_prov("%");
        }

        private void dgvListado_prov_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_Item_prov();
        }

        private void btnBuscar_pr_Click(object sender, EventArgs e)
        {
            this.Listado_prov(txtBuscar_pr.Text);
        }

        private void btnActualizar_pr_Click(object sender, EventArgs e)
        {
            this.nEstadoguarda = 2; //Actualizar Registro
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtNombre_pr.Select();
        }

        private void btnEliminar_pr_Click(object sender, EventArgs e)
        {
            if (dgvListado_prov.Rows.Count <= 0 ||
              string.IsNullOrEmpty(Convert.ToString(dgvListado_prov.CurrentRow.Cells["id"].Value)))
            {
                MessageBox.Show("No se tiene informacion para eliminar",
                    "Aviso del sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                string Rpta = "";
                D_Proveedor Datos = new D_Proveedor();
                Rpta = Datos.Activo_prov(idProv, 0);
                if (Rpta == "OK")
                {
                    this.Listado_prov("%");
                    this.LimpiaTexto();
                    idProv = 0;
                    MessageBox.Show("El registro seleccionado ha sido eliminado",
                        "Aviso del sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

            }
        }

        private void btnSalir_pr_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
