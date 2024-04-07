using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiendaDeRopa.Datos;
using TiendaDeRopa.Entidades;

namespace TiendaDeRopa.Presentacion
{
    public partial class Frm_Proveedor : Form
    {
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
            
            dgvListado_prov.Columns[0].Width = 210;
            dgvListado_prov.Columns[0].HeaderText = "PROVEEDOR";
            dgvListado_prov.Columns[1].Width = 110;
            dgvListado_prov.Columns[1].HeaderText = "EMAIL";
            dgvListado_prov.Columns[2].Width = 110;
            dgvListado_prov.Columns[2].HeaderText = "TELEFONO";
            dgvListado_prov.Columns[3].Width = 110;
            dgvListado_prov.Columns[3].HeaderText = "DIRECCION";

        }

        private void Listado_prov(string cTexto)
        {
            D_Proveedor Datos = new D_Proveedor();
            dgvListado_prov.DataSource = Datos.Listado_prov(cTexto);
            this.Formato_prov();
        }

        private void btnNuevo_pr_Click(object sender, EventArgs e)
        {
            this.LimpiaTexto();
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtNombre_pr.Select();
        }


        private void btnCancelar_pr_Click(object sender, EventArgs e)
        {
            this.LimpiaTexto();
            this.EstadoTexto(false);
            this.EstadoBotones(true);
        }

        private void btnGuardar_pr_Click(object sender, EventArgs e)
        {
            if (txtNombre_pr.Text == string.Empty ||
               txtEmail_pr.Text == string.Empty ||
               txtTelefono_pr.Text == string.Empty ||
               txtDireccion_pr.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else 
            {
                string Rpta = "";
                E_Proveedor oProv = new E_Proveedor();
                oProv.id = 0;
                oProv.nombre= txtNombre_pr.Text;
                oProv.email = txtEmail_pr.Text;
                oProv.telefono = txtTelefono_pr.Text;
                oProv.direccion = txtDireccion_pr.Text;

                D_Proveedor Datos = new D_Proveedor();
                Rpta = Datos.Guardar_prov(1, oProv); //por el procedimiento o se guarda o actualiza

                if (Rpta == "OK")
                {
                    this.Listado_prov("%");
                    MessageBox.Show("Los datos han sido guardados correctamente",
                        "Aviso del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                  
                    this.LimpiaTexto();
                    this.EstadoTexto(false);
                    this.EstadoBotones(true);
                }
            }
        }

        private void Frm_Proveedor_Load_1(object sender, EventArgs e)
        {
            this.Listado_prov("%");
        }
    }
}
