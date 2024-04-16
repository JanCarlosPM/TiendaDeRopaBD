using System;
using System.Data;
using System.Data.SqlClient;
using TiendaDeRopa.Entidades;

namespace TiendaDeRopa.Datos
{
    public class D_Factura
    {
        public string GuardarCompra(E_Factura e_Factura)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();

                SqlCommand comandoNumeroFactura = new SqlCommand("SP_NumeroFactura", SqlCon);
                comandoNumeroFactura.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                string numeroFactura = (string)comandoNumeroFactura.ExecuteScalar();

                SqlCommand comandoGuardar = new SqlCommand("SP_GuardarFactura", SqlCon);
                comandoGuardar.CommandType = CommandType.StoredProcedure;
                comandoGuardar.Parameters.Add("@cod_factura", SqlDbType.VarChar).Value = numeroFactura;
                comandoGuardar.Parameters.Add("@fecha", SqlDbType.DateTime).Value = e_Factura.fecha;
                comandoGuardar.Parameters.Add("@subtotal", SqlDbType.Float).Value = e_Factura.subtotal;
                comandoGuardar.Parameters.Add("@iva", SqlDbType.Float).Value = e_Factura.iva;
                comandoGuardar.Parameters.Add("@total", SqlDbType.Float).Value = e_Factura.total;
                comandoGuardar.Parameters.Add("@forma_pago", SqlDbType.VarChar).Value = e_Factura.forma_pago;
                comandoGuardar.Parameters.Add("@tipo", SqlDbType.Int).Value = e_Factura.tipo;

                Rpta = comandoGuardar.ExecuteNonQuery() >= 1 ? "Compra registrada correctamente" : "No se pudo registrar la compra";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }


        public string GuardarVenta(E_Factura e_Factura)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();

                SqlCon.Open();

                SqlCommand comandoGuardarVenta = new SqlCommand("SP_ActualizarStockVenta", SqlCon);
                comandoGuardarVenta.CommandType = CommandType.StoredProcedure;
                comandoGuardarVenta.Parameters.Add("@cod_factura_venta", SqlDbType.VarChar).Value = e_Factura.cod_factura;
                comandoGuardarVenta.Parameters.Add("@fecha_venta", SqlDbType.DateTime).Value = e_Factura.fecha;
                comandoGuardarVenta.Parameters.Add("@subtotal_venta", SqlDbType.Float).Value = e_Factura.subtotal;
                comandoGuardarVenta.Parameters.Add("@iva_venta", SqlDbType.Float).Value = e_Factura.iva;
                comandoGuardarVenta.Parameters.Add("@total_venta", SqlDbType.Float).Value = e_Factura.total;
                comandoGuardarVenta.Parameters.Add("@forma_pago_venta", SqlDbType.VarChar).Value = e_Factura.forma_pago;
                comandoGuardarVenta.Parameters.Add("@tipo_venta", SqlDbType.Int).Value = e_Factura.tipo;

                Rpta = comandoGuardarVenta.ExecuteNonQuery() >= 1 ? "Venta registrada correctamente" : "No se pudo registrar la venta";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
    }
}