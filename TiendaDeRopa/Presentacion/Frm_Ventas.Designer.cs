namespace TiendaDeRopa.Presentacion
{
    partial class Frm_Ventas
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
            this.Btn_BuscarVenta = new System.Windows.Forms.Button();
            this.lbl_BuscarVenta = new System.Windows.Forms.Label();
            this.Txt_BuscarVenta = new System.Windows.Forms.TextBox();
            this.dgvVenta = new System.Windows.Forms.DataGridView();
            this.txtCategoriaVenta = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtCantidaVenta = new System.Windows.Forms.TextBox();
            this.Btn_ListaVenta = new System.Windows.Forms.Button();
            this.Btn_LimpiarVenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_FormaPago = new System.Windows.Forms.Label();
            this.CbEfectivoVenta = new System.Windows.Forms.CheckBox();
            this.CbTarjetaVenta = new System.Windows.Forms.CheckBox();
            this.BtnCancelarVenta = new System.Windows.Forms.Button();
            this.BtnEliminarProductoVenta = new System.Windows.Forms.Button();
            this.BtnfInsertarVenta = new System.Windows.Forms.Button();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.lblSubTotalventa = new System.Windows.Forms.Label();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.lblIvaVenta = new System.Windows.Forms.Label();
            this.lblFechaVenta = new System.Windows.Forms.Label();
            this.txtSubVenta = new System.Windows.Forms.TextBox();
            this.txtIvaVenta = new System.Windows.Forms.TextBox();
            this.txtTotalVenta = new System.Windows.Forms.TextBox();
            this.txtFechaVenta = new System.Windows.Forms.TextBox();
            this.lblNumfactVenta = new System.Windows.Forms.Label();
            this.txtNumFacVenta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_BuscarVenta
            // 
            this.Btn_BuscarVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Btn_BuscarVenta.Location = new System.Drawing.Point(354, 57);
            this.Btn_BuscarVenta.Name = "Btn_BuscarVenta";
            this.Btn_BuscarVenta.Size = new System.Drawing.Size(94, 27);
            this.Btn_BuscarVenta.TabIndex = 0;
            this.Btn_BuscarVenta.Text = "Buscar";
            this.Btn_BuscarVenta.UseVisualStyleBackColor = true;
            this.Btn_BuscarVenta.Click += new System.EventHandler(this.Btn_BuscarVenta_Click);
            // 
            // lbl_BuscarVenta
            // 
            this.lbl_BuscarVenta.AutoSize = true;
            this.lbl_BuscarVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_BuscarVenta.Location = new System.Drawing.Point(13, 60);
            this.lbl_BuscarVenta.Name = "lbl_BuscarVenta";
            this.lbl_BuscarVenta.Size = new System.Drawing.Size(54, 20);
            this.lbl_BuscarVenta.TabIndex = 2;
            this.lbl_BuscarVenta.Text = "Buscar";
            // 
            // Txt_BuscarVenta
            // 
            this.Txt_BuscarVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.Txt_BuscarVenta.Location = new System.Drawing.Point(79, 57);
            this.Txt_BuscarVenta.Name = "Txt_BuscarVenta";
            this.Txt_BuscarVenta.Size = new System.Drawing.Size(257, 27);
            this.Txt_BuscarVenta.TabIndex = 3;
            this.Txt_BuscarVenta.TextChanged += new System.EventHandler(this.Txt_BuscarVenta_TextChanged);
            // 
            // dgvVenta
            // 
            this.dgvVenta.AllowUserToAddRows = false;
            this.dgvVenta.AllowUserToDeleteRows = false;
            this.dgvVenta.AllowUserToOrderColumns = true;
            this.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVenta.Location = new System.Drawing.Point(16, 100);
            this.dgvVenta.Name = "dgvVenta";
            this.dgvVenta.ReadOnly = true;
            this.dgvVenta.Size = new System.Drawing.Size(432, 144);
            this.dgvVenta.TabIndex = 4;
            this.dgvVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVenta_CellContentClick);
            // 
            // txtCategoriaVenta
            // 
            this.txtCategoriaVenta.Enabled = false;
            this.txtCategoriaVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtCategoriaVenta.Location = new System.Drawing.Point(454, 100);
            this.txtCategoriaVenta.Name = "txtCategoriaVenta";
            this.txtCategoriaVenta.Size = new System.Drawing.Size(146, 27);
            this.txtCategoriaVenta.TabIndex = 5;
            this.txtCategoriaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Enabled = false;
            this.txtPrecioVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtPrecioVenta.Location = new System.Drawing.Point(454, 142);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(146, 27);
            this.txtPrecioVenta.TabIndex = 6;
            this.txtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantidaVenta
            // 
            this.txtCantidaVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtCantidaVenta.Location = new System.Drawing.Point(455, 222);
            this.txtCantidaVenta.Name = "txtCantidaVenta";
            this.txtCantidaVenta.Size = new System.Drawing.Size(145, 27);
            this.txtCantidaVenta.TabIndex = 7;
            // 
            // Btn_ListaVenta
            // 
            this.Btn_ListaVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Btn_ListaVenta.Location = new System.Drawing.Point(606, 97);
            this.Btn_ListaVenta.Name = "Btn_ListaVenta";
            this.Btn_ListaVenta.Size = new System.Drawing.Size(107, 30);
            this.Btn_ListaVenta.TabIndex = 8;
            this.Btn_ListaVenta.Text = "Lista Venta";
            this.Btn_ListaVenta.UseVisualStyleBackColor = true;
            this.Btn_ListaVenta.Click += new System.EventHandler(this.Btn_ListaVenta_Click);
            // 
            // Btn_LimpiarVenta
            // 
            this.Btn_LimpiarVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Btn_LimpiarVenta.Location = new System.Drawing.Point(606, 142);
            this.Btn_LimpiarVenta.Name = "Btn_LimpiarVenta";
            this.Btn_LimpiarVenta.Size = new System.Drawing.Size(107, 27);
            this.Btn_LimpiarVenta.TabIndex = 9;
            this.Btn_LimpiarVenta.Text = "Nueva Venta";
            this.Btn_LimpiarVenta.UseVisualStyleBackColor = true;
            this.Btn_LimpiarVenta.Click += new System.EventHandler(this.Btn_LimpiarVenta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(489, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cantidad";
            // 
            // lbl_FormaPago
            // 
            this.lbl_FormaPago.AutoSize = true;
            this.lbl_FormaPago.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_FormaPago.Location = new System.Drawing.Point(482, 332);
            this.lbl_FormaPago.Name = "lbl_FormaPago";
            this.lbl_FormaPago.Size = new System.Drawing.Size(113, 20);
            this.lbl_FormaPago.TabIndex = 11;
            this.lbl_FormaPago.Text = "Forma de pago";
            // 
            // CbEfectivoVenta
            // 
            this.CbEfectivoVenta.AutoSize = true;
            this.CbEfectivoVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.CbEfectivoVenta.Location = new System.Drawing.Point(485, 369);
            this.CbEfectivoVenta.Name = "CbEfectivoVenta";
            this.CbEfectivoVenta.Size = new System.Drawing.Size(82, 24);
            this.CbEfectivoVenta.TabIndex = 12;
            this.CbEfectivoVenta.Text = "Efectivo";
            this.CbEfectivoVenta.UseVisualStyleBackColor = true;
            this.CbEfectivoVenta.CheckedChanged += new System.EventHandler(this.CbEfectivoVenta_CheckedChanged);
            // 
            // CbTarjetaVenta
            // 
            this.CbTarjetaVenta.AutoSize = true;
            this.CbTarjetaVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.CbTarjetaVenta.Location = new System.Drawing.Point(485, 404);
            this.CbTarjetaVenta.Name = "CbTarjetaVenta";
            this.CbTarjetaVenta.Size = new System.Drawing.Size(74, 24);
            this.CbTarjetaVenta.TabIndex = 13;
            this.CbTarjetaVenta.Text = "Tarjeta";
            this.CbTarjetaVenta.UseVisualStyleBackColor = true;
            this.CbTarjetaVenta.CheckedChanged += new System.EventHandler(this.CbTarjetaVenta_CheckedChanged);
            // 
            // BtnCancelarVenta
            // 
            this.BtnCancelarVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnCancelarVenta.Location = new System.Drawing.Point(601, 332);
            this.BtnCancelarVenta.Name = "BtnCancelarVenta";
            this.BtnCancelarVenta.Size = new System.Drawing.Size(107, 28);
            this.BtnCancelarVenta.TabIndex = 14;
            this.BtnCancelarVenta.Text = "Cancelar";
            this.BtnCancelarVenta.UseVisualStyleBackColor = true;
            this.BtnCancelarVenta.Click += new System.EventHandler(this.BtnCancelarVenta_Click);
            // 
            // BtnEliminarProductoVenta
            // 
            this.BtnEliminarProductoVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnEliminarProductoVenta.Location = new System.Drawing.Point(601, 366);
            this.BtnEliminarProductoVenta.Name = "BtnEliminarProductoVenta";
            this.BtnEliminarProductoVenta.Size = new System.Drawing.Size(107, 27);
            this.BtnEliminarProductoVenta.TabIndex = 15;
            this.BtnEliminarProductoVenta.Text = "Eliminar producto";
            this.BtnEliminarProductoVenta.UseVisualStyleBackColor = true;
            this.BtnEliminarProductoVenta.Click += new System.EventHandler(this.BtnEliminarProductoVenta_Click);
            // 
            // BtnfInsertarVenta
            // 
            this.BtnfInsertarVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnfInsertarVenta.Location = new System.Drawing.Point(601, 407);
            this.BtnfInsertarVenta.Name = "BtnfInsertarVenta";
            this.BtnfInsertarVenta.Size = new System.Drawing.Size(112, 31);
            this.BtnfInsertarVenta.TabIndex = 16;
            this.BtnfInsertarVenta.Text = "Generar Factura ";
            this.BtnfInsertarVenta.UseVisualStyleBackColor = true;
            this.BtnfInsertarVenta.Click += new System.EventHandler(this.BtnfInsertarVenta_Click);
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AllowUserToDeleteRows = false;
            this.dgvDetalleVenta.AllowUserToOrderColumns = true;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(16, 276);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.ReadOnly = true;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(432, 145);
            this.dgvDetalleVenta.TabIndex = 17;
            this.dgvDetalleVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellClick);
            // 
            // lblSubTotalventa
            // 
            this.lblSubTotalventa.AutoSize = true;
            this.lblSubTotalventa.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSubTotalventa.Location = new System.Drawing.Point(31, 436);
            this.lblSubTotalventa.Name = "lblSubTotalventa";
            this.lblSubTotalventa.Size = new System.Drawing.Size(68, 20);
            this.lblSubTotalventa.TabIndex = 18;
            this.lblSubTotalventa.Text = "SubTotal";
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalVenta.Location = new System.Drawing.Point(284, 436);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(42, 20);
            this.lblTotalVenta.TabIndex = 19;
            this.lblTotalVenta.Text = "Total";
            // 
            // lblIvaVenta
            // 
            this.lblIvaVenta.AutoSize = true;
            this.lblIvaVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIvaVenta.Location = new System.Drawing.Point(175, 436);
            this.lblIvaVenta.Name = "lblIvaVenta";
            this.lblIvaVenta.Size = new System.Drawing.Size(29, 20);
            this.lblIvaVenta.TabIndex = 20;
            this.lblIvaVenta.Text = "Iva";
            // 
            // lblFechaVenta
            // 
            this.lblFechaVenta.AutoSize = true;
            this.lblFechaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaVenta.Location = new System.Drawing.Point(31, 490);
            this.lblFechaVenta.Name = "lblFechaVenta";
            this.lblFechaVenta.Size = new System.Drawing.Size(54, 20);
            this.lblFechaVenta.TabIndex = 21;
            this.lblFechaVenta.Text = "Fecha";
            // 
            // txtSubVenta
            // 
            this.txtSubVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtSubVenta.Location = new System.Drawing.Point(16, 455);
            this.txtSubVenta.Name = "txtSubVenta";
            this.txtSubVenta.Size = new System.Drawing.Size(100, 27);
            this.txtSubVenta.TabIndex = 22;
            this.txtSubVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIvaVenta
            // 
            this.txtIvaVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIvaVenta.Location = new System.Drawing.Point(138, 455);
            this.txtIvaVenta.Name = "txtIvaVenta";
            this.txtIvaVenta.Size = new System.Drawing.Size(100, 27);
            this.txtIvaVenta.TabIndex = 23;
            this.txtIvaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalVenta
            // 
            this.txtTotalVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalVenta.Location = new System.Drawing.Point(262, 455);
            this.txtTotalVenta.Name = "txtTotalVenta";
            this.txtTotalVenta.Size = new System.Drawing.Size(100, 27);
            this.txtTotalVenta.TabIndex = 24;
            this.txtTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFechaVenta
            // 
            this.txtFechaVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtFechaVenta.Location = new System.Drawing.Point(16, 513);
            this.txtFechaVenta.Name = "txtFechaVenta";
            this.txtFechaVenta.Size = new System.Drawing.Size(100, 27);
            this.txtFechaVenta.TabIndex = 25;
            this.txtFechaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNumfactVenta
            // 
            this.lblNumfactVenta.AutoSize = true;
            this.lblNumfactVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblNumfactVenta.Location = new System.Drawing.Point(792, 64);
            this.lblNumfactVenta.Name = "lblNumfactVenta";
            this.lblNumfactVenta.Size = new System.Drawing.Size(84, 20);
            this.lblNumfactVenta.TabIndex = 26;
            this.lblNumfactVenta.Text = "No.Factura";
            // 
            // txtNumFacVenta
            // 
            this.txtNumFacVenta.Enabled = false;
            this.txtNumFacVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNumFacVenta.Location = new System.Drawing.Point(884, 63);
            this.txtNumFacVenta.Name = "txtNumFacVenta";
            this.txtNumFacVenta.Size = new System.Drawing.Size(131, 27);
            this.txtNumFacVenta.TabIndex = 27;
            this.txtNumFacVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Frm_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 561);
            this.ControlBox = false;
            this.Controls.Add(this.txtNumFacVenta);
            this.Controls.Add(this.lblNumfactVenta);
            this.Controls.Add(this.txtFechaVenta);
            this.Controls.Add(this.txtTotalVenta);
            this.Controls.Add(this.txtIvaVenta);
            this.Controls.Add(this.txtSubVenta);
            this.Controls.Add(this.lblFechaVenta);
            this.Controls.Add(this.lblIvaVenta);
            this.Controls.Add(this.lblTotalVenta);
            this.Controls.Add(this.lblSubTotalventa);
            this.Controls.Add(this.dgvDetalleVenta);
            this.Controls.Add(this.BtnfInsertarVenta);
            this.Controls.Add(this.BtnEliminarProductoVenta);
            this.Controls.Add(this.BtnCancelarVenta);
            this.Controls.Add(this.CbTarjetaVenta);
            this.Controls.Add(this.CbEfectivoVenta);
            this.Controls.Add(this.lbl_FormaPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_LimpiarVenta);
            this.Controls.Add(this.Btn_ListaVenta);
            this.Controls.Add(this.txtCantidaVenta);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.txtCategoriaVenta);
            this.Controls.Add(this.dgvVenta);
            this.Controls.Add(this.Txt_BuscarVenta);
            this.Controls.Add(this.lbl_BuscarVenta);
            this.Controls.Add(this.Btn_BuscarVenta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Ventas";
            this.Text = "WfVentas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_BuscarVenta;
        private System.Windows.Forms.Label lbl_BuscarVenta;
        private System.Windows.Forms.TextBox Txt_BuscarVenta;
        private System.Windows.Forms.DataGridView dgvVenta;
        private System.Windows.Forms.TextBox txtCategoriaVenta;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtCantidaVenta;
        private System.Windows.Forms.Button Btn_ListaVenta;
        private System.Windows.Forms.Button Btn_LimpiarVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_FormaPago;
        private System.Windows.Forms.CheckBox CbEfectivoVenta;
        private System.Windows.Forms.CheckBox CbTarjetaVenta;
        private System.Windows.Forms.Button BtnCancelarVenta;
        private System.Windows.Forms.Button BtnEliminarProductoVenta;
        private System.Windows.Forms.Button BtnfInsertarVenta;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.Label lblSubTotalventa;
        private System.Windows.Forms.Label lblTotalVenta;
        private System.Windows.Forms.Label lblIvaVenta;
        private System.Windows.Forms.Label lblFechaVenta;
        private System.Windows.Forms.TextBox txtSubVenta;
        private System.Windows.Forms.TextBox txtIvaVenta;
        private System.Windows.Forms.TextBox txtTotalVenta;
        private System.Windows.Forms.TextBox txtFechaVenta;
        private System.Windows.Forms.Label lblNumfactVenta;
        private System.Windows.Forms.TextBox txtNumFacVenta;
    }
}