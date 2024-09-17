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
    public class PersistenciaCliente
    {
        public static void Alta(Clientes cCliente)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AltaCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Pasaporte", cCliente.Pasaporte);
            oComando.Parameters.AddWithValue("@NombreCliente", cCliente.NomCliente);
            oComando.Parameters.AddWithValue("@NroTarjeta", cCliente.NroTarjeta);
            oComando.Parameters.AddWithValue("@ContraseñaCliente", cCliente.ContraCliente);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe un Cliente con ese pasaporte");
             
                else if (oAfectados == -2)
                    throw new Exception("Error en BD");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Modificar(Clientes cCliente)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ModificarCliente ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            
            oComando.Parameters.AddWithValue("@Pasaporte", cCliente.Pasaporte);
            oComando.Parameters.AddWithValue("@NombreCliente", cCliente.NomCliente);
            oComando.Parameters.AddWithValue("@NroTarjeta", cCliente.NroTarjeta);
            oComando.Parameters.AddWithValue("@ContraseñaCliente", cCliente.ContraCliente);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe - No se modifica");
                    
                else if (oAfectados == -2)
                    throw new Exception("Error en BD");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void EliminarCliente(Clientes unC)
        {
            SqlConnection _Conexion = new SqlConnection(CONEXION.STR);
            SqlCommand _Comando = new SqlCommand("EliminarCliente", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Pasaporte", unC.Pasaporte);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe el Cliente");
                else if (oAfectados == -2)
                    throw new Exception("No se puede eliminar - Ese Cliente tiene Pasajes");
                else if (oAfectados == -3)
                    throw new Exception("Error en BD");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }

        public static List<Clientes> ListarClientes()
        {
            SqlConnection _cnn = new SqlConnection(CONEXION.STR);
            SqlCommand _comando = new SqlCommand("ListarClientes", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            Clientes unC = null;
            List<Clientes> _listaC = new List<Clientes>();

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        unC = new Clientes(Convert.ToString(_lector["Pasaporte"]), Convert.ToString(_lector["NombreCliente"]), Convert.ToInt32(_lector["NroTarjeta"]), Convert.ToString(_lector["ContraseñaCliente"]));
                        _listaC.Add(unC);
                    }
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }

            return _listaC;

        }

        public static Clientes Buscar(string Pasaporte)
        {
            string NombreCliente = "";
            int NroTarjeta = 0;
            string ContraCliente = "";

            Clientes cs = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarCliente " + Pasaporte, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    Pasaporte = (string)oReader["Pasaporte"];
                    NombreCliente = (string)oReader["NombreCliente"];
                    NroTarjeta = (int)oReader["NroTarjeta"];
                    ContraCliente = (string)oReader["ContraseñaCliente"];

                    cs = new Clientes(Pasaporte, NombreCliente, NroTarjeta, ContraCliente);
                }

                oReader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return cs;
        }

        public static Compartidas.Clientes Logueo(string Pasaporte, string ContraCliente)
        {
            //variables
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("LogueoCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            Clientes logCliente = null;
            SqlDataReader oReader;

            //parametros
            oComando.Parameters.AddWithValue("@Pasaporte", Pasaporte);
            oComando.Parameters.AddWithValue("@ContraseñaCli", ContraCliente);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    string NombreCliente = (string)oReader["NombreCliente"];
                    int NroTarjeta = (int)oReader["NroTarjeta"];

                    logCliente = new Clientes(Pasaporte, NombreCliente, NroTarjeta, ContraCliente);
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

            return logCliente;
        }




    }
}
