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
    }
    public string ActualizarStockVenta(E_Factura e_Factura)
    {
        string Rpta = "";
        SqlConnection SqlCon = new SqlConnection();
        try
        {
            SqlCon = Conexion.getInstancia().CrearConexion();

            SqlCon.Open();

            // Guardar venta
            SqlCommand comandoGuardarVenta = new SqlCommand("SP_ActualizarStockVenta", SqlCon);
            comandoGuardarVenta.CommandType = CommandType.StoredProcedure;
            comandoGuardarVenta.Parameters.Add("@cod_factura_venta", SqlDbType.VarChar).Value = e_Factura.cod_factura;
            comandoGuardarVenta.Parameters.Add("@fecha_venta", SqlDbType.DateTime).Value = e_Factura.fecha;
            comandoGuardarVenta.Parameters.Add("@subtotal_venta", SqlDbType.Float).Value = e_Factura.subtotal;
            comandoGuardarVenta.Parameters.Add("@iva_venta", SqlDbType.Float).Value = e_Factura.iva;
            comandoGuardarVenta.Parameters.Add("@total_venta", SqlDbType.Float).Value = e_Factura.total;
            comandoGuardarVenta.Parameters.Add("@forma_pago_venta", SqlDbType.VarChar).Value = e_Factura.forma_pago;
            comandoGuardarVenta.Parameters.Add("@tipo_venta", SqlDbType.Int).Value = e_Factura.tipo;

            int filasAfectadasVenta = comandoGuardarVenta.ExecuteNonQuery();

            // Verificar si la venta se guardó correctamente
            if (filasAfectadasVenta >= 1)
            {
                // Ejecutar procedimiento almacenado para actualizar el stock
                SqlCommand comandoActualizarStock = new SqlCommand("SP_ActualizarStockVenta", SqlCon);
                comandoActualizarStock.CommandType = CommandType.StoredProcedure;
                comandoActualizarStock.Parameters.Add("@categorias", SqlDbType.NVarChar).Value = e_Factura.categorias;
                comandoActualizarStock.Parameters.Add("@cantidades", SqlDbType.NVarChar).Value = e_Factura.cantidades;
                comandoActualizarStock.Parameters.Add("@fechasIngreso", SqlDbType.NVarChar).Value = e_Factura.fechasIngreso; // Aquí se pasa la lista de fechas de ingreso

                int filasAfectadasStock = comandoActualizarStock.ExecuteNonQuery();

                if (filasAfectadasStock >= 1)
                {
                    Rpta = "Venta registrada correctamente";
                }
                else
                {
                    Rpta = "Error al actualizar el inventario";
                }
            }
            else
            {
                Rpta = "Error al guardar la venta";
            }
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
