using System;
using System.Data.SqlClient;
using System.Data;

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
    }
}
