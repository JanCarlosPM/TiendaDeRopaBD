using System;
using System.Data;
using System.Data.SqlClient;

namespace TiendaDeRopa.Datos
{
    public class D_Producto
    {

        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlConnection sqlCon = Conexion.getInstancia().CrearConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarProductos", sqlCon))
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
                Console.WriteLine("Error al listar productos: " + ex.Message);
            }
            return tabla;
        }
        public DataTable ListarProductosFiltro(string categoria)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlConnection sqlCon = Conexion.getInstancia().CrearConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ObtenerProductosFiltro", sqlCon))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@categoria", SqlDbType.VarChar).Value = categoria;
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
                Console.WriteLine("Error al listar productos: " + ex.Message);
            }
            return tabla;
        }

        public string ObtenerIDProducto(string categoria)
        {
            string idProducto = null;
            try
            {
                using (SqlConnection sqlCon = Conexion.getInstancia().CrearConexion())
                {
                    string query = "SELECT IDProducto FROM Productos WHERE Categoria = @Categoria";
                    using (SqlCommand comando = new SqlCommand(query, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@Categoria", categoria);
                        sqlCon.Open();
                        idProducto = comando.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener IDProducto: " + ex.Message);
            }
            return idProducto;
        }

    }
}
