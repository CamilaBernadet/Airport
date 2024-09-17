using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Compartidas;

namespace Persistencia
{
    public class PersistenciaEmpleado
    {
        public static Compartidas.Empleados Logueo(string Usuario, string ContraEmp)
        {
            //variables
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("LogueoEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            Empleados logEmpleado = null;
            SqlDataReader oReader;

            //parametros
            oComando.Parameters.AddWithValue("@Usuario", Usuario);
            oComando.Parameters.AddWithValue("@ContraseñaEmp", ContraEmp);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    string NombreEmpleado = (string)oReader["NombreEmpleado"];
                    string Labor = (string)oReader["Labor"];

                    logEmpleado = new Empleados(Usuario, ContraEmp, NombreEmpleado, Labor);
                }

                oReader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return logEmpleado;
        }
    }
}
