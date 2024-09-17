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
    public class PersistenciaCiudad
    {
        public static void Alta(Ciudades cCiudad)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AltaCiudad ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoCiudad", cCiudad.CodigoCiudad);
            oComando.Parameters.AddWithValue("@NombreCiudad", cCiudad.NomCiudad);
            oComando.Parameters.AddWithValue("@Pais", cCiudad.Pais);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe la Ciudad");
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

        public static void Modificar(Ciudades cCiudad)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ModificarCiudad ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoCiudad", cCiudad.CodigoCiudad);
            oComando.Parameters.AddWithValue("@NombreCiudad", cCiudad.NomCiudad);
            oComando.Parameters.AddWithValue("@Pais", cCiudad.Pais);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe la Ciudad");
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

        public static void EliminarCiudad(Ciudades cCodigo)
        {
            SqlConnection _Conexion = new SqlConnection(CONEXION.STR);
            SqlCommand _Comando = new SqlCommand("EliminarCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@CodigoCiudad", cCodigo.CodigoCiudad);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe la Ciudad");
                else if (oAfectados == -2)
                    throw new Exception("No se puede eliminar - Hay Aeropuertos");
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

        public static Ciudades Buscar(string cCodigo)
        {
            string pPais = "";
            string nombreCiudad = "";

            Ciudades c = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarCiudad " + cCodigo, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    cCodigo = (string)oReader["CodigoCiudad"];
                    nombreCiudad = (string)oReader["NombreCiudad"];
                    pPais = (string)oReader["Pais"];


                    c = new Ciudades(cCodigo, nombreCiudad, pPais);
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
            return c;
        }

        public static List<Ciudades> ListarCiudad()
        {
            SqlConnection _cnn = new SqlConnection(CONEXION.STR);
            SqlCommand _comando = new SqlCommand("ListarCiudad", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            
            List<Ciudades> _listaC = new List<Ciudades>();

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        Ciudades unC = new Ciudades(Convert.ToString(_lector["CodigoCiudad"]), Convert.ToString(_lector["NombreCiudad"]), Convert.ToString(_lector["Pais"]));
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

    }
}
