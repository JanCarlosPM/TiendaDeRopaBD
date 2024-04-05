using TiendaDeRopa.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeRopa.Datos
{
    public class D_Productos
    {

        public DataTable Listado_prov(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_PROV", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }


        }

        public string Guardar_prov(int nOpcion,
                               E_Proveedor oProv)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_GUARDAR_PROV", SqlCon);
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
    }
}