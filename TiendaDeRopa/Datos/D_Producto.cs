using System;
using System.Data;
using System.Data.SqlClient;
using TiendaDeRopa.Entidades;

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

        public string InsertarProducto(string categoria, string tela, string talla, string estilo, string descripcion, string marca, string nombre_proveedor, float precio)
        {
            string mensaje = "";

            try
            {
                using (SqlConnection sqlCon = Conexion.getInstancia().CrearConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_InsertarProducto", sqlCon))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@categoria", SqlDbType.NVarChar).Value = categoria;
                        comando.Parameters.Add("@tela", SqlDbType.NVarChar).Value = tela;
                        comando.Parameters.Add("@talla", SqlDbType.NVarChar).Value = talla;
                        comando.Parameters.Add("@estilo", SqlDbType.NVarChar).Value = estilo;
                        comando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
                        comando.Parameters.Add("@marca", SqlDbType.NVarChar).Value = marca;
                        comando.Parameters.Add("@nombre_proveedor", SqlDbType.VarChar).Value = nombre_proveedor;
                        comando.Parameters.Add("@precio", SqlDbType.Float).Value = precio;

                        sqlCon.Open();
                        comando.ExecuteNonQuery();

                        mensaje = "Producto insertado correctamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al insertar producto: " + ex.Message;
            }

            return mensaje;
        }
        public string EditarProducto(string categoria, string tela, string talla, string estilo, string descripcion, string marca, string nombre_proveedor, float precio)
        {
            string mensaje = "";

            try
            {
                using (SqlConnection sqlCon = Conexion.getInstancia().CrearConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_EditarProducto", sqlCon))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@categoria", SqlDbType.NVarChar).Value = categoria;
                        comando.Parameters.Add("@tela", SqlDbType.NVarChar).Value = tela;
                        comando.Parameters.Add("@talla", SqlDbType.NVarChar).Value = talla;
                        comando.Parameters.Add("@estilo", SqlDbType.NVarChar).Value = estilo;
                        comando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
                        comando.Parameters.Add("@marca", SqlDbType.NVarChar).Value = marca;
                        comando.Parameters.Add("@nombre_proveedor", SqlDbType.VarChar).Value = nombre_proveedor;
                        comando.Parameters.Add("@precio", SqlDbType.Float).Value = precio;

                        sqlCon.Open();
                        comando.ExecuteNonQuery();

                        mensaje = "Producto editado correctamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al editar producto: " + ex.Message;
            }

            return mensaje;
        }

    }
}