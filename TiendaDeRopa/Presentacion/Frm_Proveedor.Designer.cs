namespace TiendaDeRopa.Presentacion
{
    partial class Frm_Proveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Proveedor));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnActualizar_pr = new System.Windows.Forms.Button();
            this.btnEliminar_pr = new System.Windows.Forms.Button();
            this.btnSalir_pr = new System.Windows.Forms.Button();
            this.btnNuevo_pr = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre_pr = new System.Windows.Forms.TextBox();
            this.txtEmail_pr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono_pr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion_pr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvListado_prov = new System.Windows.Forms.DataGridView();
            this.txtBuscar_pr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscar_pr = new System.Windows.Forms.Button();
            this.btnGuardar_pr = new System.Windows.Forms.Button();
            this.btnCancelar_pr = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado_prov)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Teal;
            this.flowLayoutPanel1.Controls.Add(this.btnNuevo_pr);
            this.flowLayoutPanel1.Controls.Add(this.btnActualizar_pr);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar_pr);
            this.flowLayoutPanel1.Controls.Add(this.btnSalir_pr);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(588, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(98, 384);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnActualizar_pr
            // 
            this.btnActualizar_pr.Enabled = false;
            this.btnActualizar_pr.Location = new System.Drawing.Point(2, 58);
            this.btnActualizar_pr.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualizar_pr.Name = "btnActualizar_pr";
            this.btnActualizar_pr.Size = new System.Drawing.Size(94, 52);
            this.btnActualizar_pr.TabIndex = 16;
            this.btnActualizar_pr.Text = "Actualizar";
            this.btnActualizar_pr.UseVisualStyleBackColor = true;
            this.btnActualizar_pr.Click += new System.EventHandler(this.btnActualizar_pr_Click);
            // 
            // btnEliminar_pr
            // 
            this.btnEliminar_pr.Enabled = false;
            this.btnEliminar_pr.Location = new System.Drawing.Point(2, 114);
            this.btnEliminar_pr.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar_pr.Name = "btnEliminar_pr";
            this.btnEliminar_pr.Size = new System.Drawing.Size(94, 52);
            this.btnEliminar_pr.TabIndex = 17;
            this.btnEliminar_pr.Text = "Eliminar";
            this.btnEliminar_pr.UseVisualStyleBackColor = true;
            this.btnEliminar_pr.Click += new System.EventHandler(this.btnEliminar_pr_Click);
            // 
            // btnSalir_pr
            // 
            this.btnSalir_pr.Location = new System.Drawing.Point(2, 170);
            this.btnSalir_pr.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir_pr.Name = "btnSalir_pr";
            this.btnSalir_pr.Size = new System.Drawing.Size(94, 52);
            this.btnSalir_pr.TabIndex = 18;
            this.btnSalir_pr.Text = "Salir";
            this.btnSalir_pr.UseVisualStyleBackColor = true;
            this.btnSalir_pr.Click += new System.EventHandler(this.btnSalir_pr_Click);
            // 
            // btnNuevo_pr
            // 
            this.btnNuevo_pr.Location = new System.Drawing.Point(2, 2);
            this.btnNuevo_pr.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo_pr.Name = "btnNuevo_pr";
            this.btnNuevo_pr.Size = new System.Drawing.Size(94, 52);
            this.btnNuevo_pr.TabIndex = 15;
            this.btnNuevo_pr.Text = "Nuevo";
            this.btnNuevo_pr.UseVisualStyleBackColor = true;
            this.btnNuevo_pr.Click += new System.EventHandler(this.btnNuevo_pr_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 81);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(121, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROVEEDORES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // txtNombre_pr
            // 
            this.txtNombre_pr.Enabled = false;
            this.txtNombre_pr.Location = new System.Drawing.Point(69, 105);
            this.txtNombre_pr.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre_pr.MaxLength = 50;
            this.txtNombre_pr.Name = "txtNombre_pr";
            this.txtNombre_pr.Size = new System.Drawing.Size(175, 20);
            this.txtNombre_pr.TabIndex = 3;
            // 
            // txtEmail_pr
            // 
            this.txtEmail_pr.Enabled = false;
            this.txtEmail_pr.Location = new System.Drawing.Point(312, 105);
            this.txtEmail_pr.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail_pr.MaxLength = 100;
            this.txtEmail_pr.Name = "txtEmail_pr";
            this.txtEmail_pr.Size = new System.Drawing.Size(216, 20);
            this.txtEmail_pr.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email:";
            // 
            // txtTelefono_pr
            // 
            this.txtTelefono_pr.Enabled = false;
            this.txtTelefono_pr.Location = new System.Drawing.Point(69, 154);
            this.txtTelefono_pr.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono_pr.MaxLength = 15;
            this.txtTelefono_pr.Name = "txtTelefono_pr";
            this.txtTelefono_pr.Size = new System.Drawing.Size(175, 20);
            this.txtTelefono_pr.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 157);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telefono:";
            // 
            // txtDireccion_pr
            // 
            this.txtDireccion_pr.Enabled = false;
            this.txtDireccion_pr.Location = new System.Drawing.Point(312, 154);
            this.txtDireccion_pr.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion_pr.MaxLength = 300;
            this.txtDireccion_pr.Name = "txtDireccion_pr";
            this.txtDireccion_pr.Size = new System.Drawing.Size(216, 20);
            this.txtDireccion_pr.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Direccion:";
            // 
            // dgvListado_prov
            // 
            this.dgvListado_prov.AllowUserToAddRows = false;
            this.dgvListado_prov.AllowUserToDeleteRows = false;
            this.dgvListado_prov.AllowUserToOrderColumns = true;
            this.dgvListado_prov.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListado_prov.ColumnHeadersHeight = 35;
            this.dgvListado_prov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListado_prov.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListado_prov.Location = new System.Drawing.Point(16, 251);
            this.dgvListado_prov.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListado_prov.MultiSelect = false;
            this.dgvListado_prov.Name = "dgvListado_prov";
            this.dgvListado_prov.ReadOnly = true;
            this.dgvListado_prov.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvListado_prov.RowTemplate.Height = 24;
            this.dgvListado_prov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado_prov.Size = new System.Drawing.Size(549, 122);
            this.dgvListado_prov.TabIndex = 10;
            this.dgvListado_prov.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_prov_CellClick);
            // 
            // txtBuscar_pr
            // 
            this.txtBuscar_pr.Location = new System.Drawing.Point(69, 210);
            this.txtBuscar_pr.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar_pr.MaxLength = 80;
            this.txtBuscar_pr.Name = "txtBuscar_pr";
            this.txtBuscar_pr.Size = new System.Drawing.Size(132, 20);
            this.txtBuscar_pr.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 214);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Buscar:";
            // 
            // btnBuscar_pr
            // 
            this.btnBuscar_pr.Location = new System.Drawing.Point(205, 211);
            this.btnBuscar_pr.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar_pr.Name = "btnBuscar_pr";
            this.btnBuscar_pr.Size = new System.Drawing.Size(56, 19);
            this.btnBuscar_pr.TabIndex = 13;
            this.btnBuscar_pr.Text = "Buscar";
            this.btnBuscar_pr.UseVisualStyleBackColor = true;
            this.btnBuscar_pr.Click += new System.EventHandler(this.btnBuscar_pr_Click);
            // 
            // btnGuardar_pr
            // 
            this.btnGuardar_pr.Location = new System.Drawing.Point(472, 208);
            this.btnGuardar_pr.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar_pr.Name = "btnGuardar_pr";
            this.btnGuardar_pr.Size = new System.Drawing.Size(56, 25);
            this.btnGuardar_pr.TabIndex = 14;
            this.btnGuardar_pr.Text = "Guardar";
            this.btnGuardar_pr.UseVisualStyleBackColor = true;
            this.btnGuardar_pr.Visible = false;
            this.btnGuardar_pr.Click += new System.EventHandler(this.btnGuardar_pr_Click);
            // 
            // btnCancelar_pr
            // 
            this.btnCancelar_pr.Location = new System.Drawing.Point(402, 208);
            this.btnCancelar_pr.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar_pr.Name = "btnCancelar_pr";
            this.btnCancelar_pr.Size = new System.Drawing.Size(66, 25);
            this.btnCancelar_pr.TabIndex = 15;
            this.btnCancelar_pr.Text = "Cancelar";
            this.btnCancelar_pr.UseVisualStyleBackColor = true;
            this.btnCancelar_pr.Visible = false;
            this.btnCancelar_pr.Click += new System.EventHandler(this.btnCancelar_pr_Click);
            // 
            // Frm_Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 384);
            this.Controls.Add(this.btnCancelar_pr);
            this.Controls.Add(this.btnGuardar_pr);
            this.Controls.Add(this.btnBuscar_pr);
            this.Controls.Add(this.txtBuscar_pr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvListado_prov);
            this.Controls.Add(this.txtDireccion_pr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTelefono_pr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail_pr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombre_pr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Proveedor";
            this.Text = "Frm_Proveedor";
            this.Load += new System.EventHandler(this.Frm_Proveedor_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado_prov)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre_pr;
        private System.Windows.Forms.TextBox txtEmail_pr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono_pr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion_pr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvListado_prov;
        private System.Windows.Forms.TextBox txtBuscar_pr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscar_pr;
        private System.Windows.Forms.Button btnGuardar_pr;
        private System.Windows.Forms.Button btnCancelar_pr;
        private System.Windows.Forms.Button btnNuevo_pr;
        private System.Windows.Forms.Button btnActualizar_pr;
        private System.Windows.Forms.Button btnEliminar_pr;
        private System.Windows.Forms.Button btnSalir_pr;
    }
}