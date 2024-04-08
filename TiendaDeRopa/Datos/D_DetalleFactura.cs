using System.Data.SqlClient;
using System.Data;
using System;
using TiendaDeRopa.Datos;
using TiendaDeRopa.Entidades;
using System.Collections.Generic;

public class D_DetalleFactura
{
    public string GuardarCompra(E_DetalleFactura e_Detalle)
    {
        string mensaje = "";
        SqlConnection conexion = new SqlConnection();

        try
        {
            conexion = Conexion.getInstancia().CrearConexion();

            SqlCommand comando = new SqlCommand("SP_DetalleFactura", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_producto_inventario", SqlDbType.Int).Value = e_Detalle.id_producto_inventario;
            comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = e_Detalle.cantidad;
            comando.Parameters.Add("@precio_venta", SqlDbType.Int).Value = e_Detalle.precio_venta;

            conexion.Open();

            int filasAfectadas = comando.ExecuteNonQuery();
            mensaje = filasAfectadas >= 1 ? "Detalles de Factura registrados correctamente" : "No se pudo registrar los Detalles de la Factura";
        }
        catch (SqlException ex)
        {
            mensaje = "Error SQL: " + ex.Message;
        }
        catch (Exception ex)
        {
            mensaje = "Error: " + ex.Message;
        }
        finally
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }

        return mensaje;
    }
}