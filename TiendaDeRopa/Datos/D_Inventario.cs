using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using TiendaDeRopa.Entidades;

namespace TiendaDeRopa.Datos
{
    public class D_Inventario
    {
        public DataTable ListarInventario()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection sqlCon = Conexion.getInstancia().CrearConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarInventario", sqlCon))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        sqlCon.Open();

                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            tabla.Load(resultado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar inventario: " + ex.Message);
            }
            return tabla;
        }

        public string ActualizarStock(List<E_Inventario> listaInventario, List<string> categorias, List<int> cantidades, List<DateTime> fechasIngreso)
        {
            string mensaje = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = Conexion.getInstancia().CrearConexion();
                conexion.Open();

                string categoriasStr = string.Join(",", categorias);
                string cantidadesStr = string.Join(",", cantidades);

                List<string> fechasIngresoStrList = new List<string>();
                foreach (DateTime fecha in fechasIngreso)
                {
                    fechasIngresoStrList.Add(fecha.ToString("yyyy/MM/dd"));
                }

                string fechasIngresoStr = string.Join(",", fechasIngresoStrList);

                SqlCommand comando = new SqlCommand("SP_ActualizarStock", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@categorias", SqlDbType.NVarChar).Value = categoriasStr;
                comando.Parameters.Add("@cantidades", SqlDbType.NVarChar).Value = cantidadesStr;
                comando.Parameters.Add("@fechasIngreso", SqlDbType.NVarChar).Value = fechasIngresoStr;

                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas < 1)
                {
                    mensaje = "No se pudo actualizar el stock del inventario.";
                    return mensaje;
                }

                mensaje = "El stock del inventario se actualizó correctamente.";
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

        public string ActualizarStockVenta(List<E_Inventario> listaInventario1, List<string> categorias, List<int> cantidades, List<DateTime> fechasIngreso)
        {
            string mensaje = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = Conexion.getInstancia().CrearConexion();
                conexion.Open();

                string categoriasStr = string.Join(",", categorias);
                string cantidadesStr = string.Join(",", cantidades);

                List<string> fechasIngresoStrList = new List<string>();
                foreach (DateTime fecha in fechasIngreso)
                {
                    fechasIngresoStrList.Add(fecha.ToString("yyyy/MM/dd"));
                }

                string fechasIngresoStr = string.Join(",", fechasIngresoStrList);

                SqlCommand comando = new SqlCommand("SP_ActualizarStockVenta", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@categorias", SqlDbType.NVarChar).Value = categoriasStr;
                comando.Parameters.Add("@cantidades", SqlDbType.NVarChar).Value = cantidadesStr;
                comando.Parameters.Add("@fechasIngreso", SqlDbType.NVarChar).Value = fechasIngresoStr;

                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas < 1)
                {
                    mensaje = "No se pudo actualizar el stock del inventario.";
                    return mensaje;
                }

                mensaje = "El stock del inventario se actualizó correctamente.";
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