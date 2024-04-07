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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre_pr = new System.Windows.Forms.TextBox();
            this.txtEmail_pr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono_pr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion_pr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvListado_pr = new System.Windows.Forms.DataGridView();
            this.txtBuscar_pr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscar_pr = new System.Windows.Forms.Button();
            this.btnGuardar_pr = new System.Windows.Forms.Button();
            this.btnCancelar_pr = new System.Windows.Forms.Button();
            this.btnNuevo_pr = new System.Windows.Forms.Button();
            this.btnActualizar_pr = new System.Windows.Forms.Button();
            this.btnEliminar_pr = new System.Windows.Forms.Button();
            this.btnSalir_pr = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado_pr)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Teal;
            this.flowLayoutPanel1.Controls.Add(this.btnNuevo_pr);
            this.flowLayoutPanel1.Controls.Add(this.btnActualizar_pr);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar_pr);
            this.flowLayoutPanel1.Controls.Add(this.btnSalir_pr);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(659, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(141, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 100);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(161, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROVEEDORES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // txtNombre_pr
            // 
            this.txtNombre_pr.Enabled = false;
            this.txtNombre_pr.Location = new System.Drawing.Point(90, 133);
            this.txtNombre_pr.MaxLength = 50;
            this.txtNombre_pr.Name = "txtNombre_pr";
            this.txtNombre_pr.Size = new System.Drawing.Size(174, 22);
            this.txtNombre_pr.TabIndex = 3;
            // 
            // txtEmail_pr
            // 
            this.txtEmail_pr.Enabled = false;
            this.txtEmail_pr.Location = new System.Drawing.Point(361, 133);
            this.txtEmail_pr.MaxLength = 100;
            this.txtEmail_pr.Name = "txtEmail_pr";
            this.txtEmail_pr.Size = new System.Drawing.Size(174, 22);
            this.txtEmail_pr.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email:";
            // 
            // txtTelefono_pr
            // 
            this.txtTelefono_pr.Enabled = false;
            this.txtTelefono_pr.Location = new System.Drawing.Point(90, 189);
            this.txtTelefono_pr.MaxLength = 20;
            this.txtTelefono_pr.Name = "txtTelefono_pr";
            this.txtTelefono_pr.Size = new System.Drawing.Size(174, 22);
            this.txtTelefono_pr.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telefono:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtDireccion_pr
            // 
            this.txtDireccion_pr.Enabled = false;
            this.txtDireccion_pr.Location = new System.Drawing.Point(361, 189);
            this.txtDireccion_pr.MaxLength = 300;
            this.txtDireccion_pr.Name = "txtDireccion_pr";
            this.txtDireccion_pr.Size = new System.Drawing.Size(174, 22);
            this.txtDireccion_pr.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Direccion:";
            // 
            // dgvListado_pr
            // 
            this.dgvListado_pr.AllowUserToAddRows = false;
            this.dgvListado_pr.AllowUserToDeleteRows = false;
            this.dgvListado_pr.AllowUserToOrderColumns = true;
            this.dgvListado_pr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado_pr.Location = new System.Drawing.Point(3, 288);
            this.dgvListado_pr.Name = "dgvListado_pr";
            this.dgvListado_pr.ReadOnly = true;
            this.dgvListado_pr.RowHeadersWidth = 51;
            this.dgvListado_pr.RowTemplate.Height = 24;
            this.dgvListado_pr.Size = new System.Drawing.Size(650, 150);
            this.dgvListado_pr.TabIndex = 10;
            // 
            // txtBuscar_pr
            // 
            this.txtBuscar_pr.Location = new System.Drawing.Point(70, 262);
            this.txtBuscar_pr.MaxLength = 80;
            this.txtBuscar_pr.Name = "txtBuscar_pr";
            this.txtBuscar_pr.Size = new System.Drawing.Size(174, 22);
            this.txtBuscar_pr.TabIndex = 12;
            this.txtBuscar_pr.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Buscar:";
            // 
            // btnBuscar_pr
            // 
            this.btnBuscar_pr.Location = new System.Drawing.Point(250, 262);
            this.btnBuscar_pr.Name = "btnBuscar_pr";
            this.btnBuscar_pr.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar_pr.TabIndex = 13;
            this.btnBuscar_pr.Text = "Buscar";
            this.btnBuscar_pr.UseVisualStyleBackColor = true;
            // 
            // btnGuardar_pr
            // 
            this.btnGuardar_pr.Location = new System.Drawing.Point(361, 231);
            this.btnGuardar_pr.Name = "btnGuardar_pr";
            this.btnGuardar_pr.Size = new System.Drawing.Size(75, 31);
            this.btnGuardar_pr.TabIndex = 14;
            this.btnGuardar_pr.Text = "Guardar";
            this.btnGuardar_pr.UseVisualStyleBackColor = true;
            this.btnGuardar_pr.Visible = false;
            this.btnGuardar_pr.Click += new System.EventHandler(this.btnGuardar_pr_Click);
            // 
            // btnCancelar_pr
            // 
            this.btnCancelar_pr.Location = new System.Drawing.Point(460, 231);
            this.btnCancelar_pr.Name = "btnCancelar_pr";
            this.btnCancelar_pr.Size = new System.Drawing.Size(75, 31);
            this.btnCancelar_pr.TabIndex = 15;
            this.btnCancelar_pr.Text = "Cancelar";
            this.btnCancelar_pr.UseVisualStyleBackColor = true;
            this.btnCancelar_pr.Visible = false;
            // 
            // btnNuevo_pr
            // 
            this.btnNuevo_pr.Location = new System.Drawing.Point(3, 3);
            this.btnNuevo_pr.Name = "btnNuevo_pr";
            this.btnNuevo_pr.Size = new System.Drawing.Size(126, 64);
            this.btnNuevo_pr.TabIndex = 15;
            this.btnNuevo_pr.Text = "Nuevo";
            this.btnNuevo_pr.UseVisualStyleBackColor = true;
            this.btnNuevo_pr.Visible = false;
            // 
            // btnActualizar_pr
            // 
            this.btnActualizar_pr.Location = new System.Drawing.Point(3, 73);
            this.btnActualizar_pr.Name = "btnActualizar_pr";
            this.btnActualizar_pr.Size = new System.Drawing.Size(126, 64);
            this.btnActualizar_pr.TabIndex = 16;
            this.btnActualizar_pr.Text = "Actualizar";
            this.btnActualizar_pr.UseVisualStyleBackColor = true;
            this.btnActualizar_pr.Visible = false;
            // 
            // btnEliminar_pr
            // 
            this.btnEliminar_pr.Location = new System.Drawing.Point(3, 143);
            this.btnEliminar_pr.Name = "btnEliminar_pr";
            this.btnEliminar_pr.Size = new System.Drawing.Size(126, 64);
            this.btnEliminar_pr.TabIndex = 17;
            this.btnEliminar_pr.Text = "Eliminar";
            this.btnEliminar_pr.UseVisualStyleBackColor = true;
            this.btnEliminar_pr.Visible = false;
            // 
            // btnSalir_pr
            // 
            this.btnSalir_pr.Location = new System.Drawing.Point(3, 213);
            this.btnSalir_pr.Name = "btnSalir_pr";
            this.btnSalir_pr.Size = new System.Drawing.Size(126, 64);
            this.btnSalir_pr.TabIndex = 18;
            this.btnSalir_pr.Text = "Salir";
            this.btnSalir_pr.UseVisualStyleBackColor = true;
            this.btnSalir_pr.Visible = false;
            // 
            // Frm_Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar_pr);
            this.Controls.Add(this.btnGuardar_pr);
            this.Controls.Add(this.btnBuscar_pr);
            this.Controls.Add(this.txtBuscar_pr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvListado_pr);
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
            this.Name = "Frm_Proveedor";
            this.Text = "Frm_Proveedor";
            this.Load += new System.EventHandler(this.Frm_Proveedor_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado_pr)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvListado_pr;
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