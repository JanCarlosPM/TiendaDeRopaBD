using TiendaDeRopa.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace TiendaDeRopa.Datos
{
    public class D_Proveedor
    {
        public DataTable ListarProveedores(string cTexto)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection sqlCon = Conexion.getInstancia().CrearConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_LISTADO_PROV", sqlCon))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                        sqlCon.Open();

                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            tabla.Load(resultado);
                        }

                        if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar proveedores: " + ex.Message);
            }
            return tabla;
        }

        public DataTable ObtenerNombresProveedores()
        {
            DataTable nombres = new DataTable();

            try
            {
                using (SqlConnection sqlCon = Conexion.getInstancia().CrearConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ObtenerNombresProveedores", sqlCon))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        sqlCon.Open();
                        nombres.Load(comando.ExecuteReader());
                    }

                    if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener nombres de proveedores: " + ex.Message);
            }
            return nombres;
        }

        public string InsertarProveedor(int nOpcion, E_Proveedor oProv)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_GUARDAR_PROV", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@opcion", SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("@id", SqlDbType.Int).Value = oProv.id;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = oProv.nombre;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = oProv.email;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = oProv.telefono;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = oProv.direccion;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo registrar los datos";
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

        public string ActivarProducto(int Id_prov, int Estado_activo)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_ACTIVO_PROV", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@id", SqlDbType.Int).Value = Id_prov;
                Comando.Parameters.Add("@estado", SqlDbType.Int).Value = Estado_activo;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo cambiar el estado activo del producto";
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