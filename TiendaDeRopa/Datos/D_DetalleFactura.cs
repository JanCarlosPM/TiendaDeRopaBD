using System.Data.SqlClient;
using System.Data;
using System;
using TiendaDeRopa.Entidades;
using System.Collections.Generic;

namespace TiendaDeRopa.Datos
{
    public class D_DetalleFactura
    {
        public string GuardarDetalleFactura(List<E_DetalleFactura> listaDetalles, List<string> categorias, List<int> cantidades, List<float> precios, string codFactura)
        {
            string mensaje = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = Conexion.getInstancia().CrearConexion();
                conexion.Open();

                string categoriasStr = string.Join(",", categorias);
                string cantidadesStr = string.Join(",", cantidades);
                string preciosStr = string.Join(",", precios);

                SqlCommand comando = new SqlCommand("SP_DetalleFactura", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@categorias", SqlDbType.NVarChar).Value = categoriasStr;
                comando.Parameters.Add("@cantidades", SqlDbType.NVarChar).Value = cantidadesStr;
                comando.Parameters.Add("@precios", SqlDbType.NVarChar).Value = preciosStr;
                comando.Parameters.Add("@cod_factura", SqlDbType.NVarChar, 10).Value = codFactura;

                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas < 1)
                {
                    mensaje = "No se pudo registrar todos los detalles de la factura.";
                    return mensaje;
                }

                mensaje = "Todos los detalles de la factura se registraron correctamente.";
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
}