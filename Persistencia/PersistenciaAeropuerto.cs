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
    public class PersistenciaAeropuerto
    {
        public static void Alta(Aeropuertos aAero)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AltaAeropuerto ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoAeropuerto", aAero.CodigoAeropuerto);
            oComando.Parameters.AddWithValue("@NombreAeropuerto", aAero.NomAeropuerto);
            oComando.Parameters.AddWithValue("@DireccionAeropuerto", aAero.Direccion);
            oComando.Parameters.AddWithValue("@ImpuestosPartida", aAero.ImpPartida);
            oComando.Parameters.AddWithValue("@ImpuestosLlegada", aAero.ImpLlegada);
            oComando.Parameters.AddWithValue("@CodigoCiudad", aAero.ciudadAeropuerto.CodigoCiudad);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe el Aeropuerto");
                else if (oAfectados == -2)
                    throw new Exception("No existe la Ciudad elegida");
                else if (oAfectados == -3)
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

        public static void Modificar(Aeropuertos aAero)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ModificarAeropuerto ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoAeropuerto", aAero.CodigoAeropuerto);
            oComando.Parameters.AddWithValue("@NombreAeropuerto", aAero.NomAeropuerto);
            oComando.Parameters.AddWithValue("@DireccionAeropuerto", aAero.Direccion);
            oComando.Parameters.AddWithValue("@ImpuestosPartida", aAero.ImpPartida);
            oComando.Parameters.AddWithValue("@ImpuestosLlegada", aAero.ImpLlegada);
            oComando.Parameters.AddWithValue("@CodigoCiudad", aAero.ciudadAeropuerto.CodigoCiudad);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe el Aeropuerto");
                else if (oAfectados == -2)
                    throw new Exception("No existe la Ciudad elegida");
                else if (oAfectados == -3)
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

        public static void EliminarAero(Aeropuertos unA)
        {
            SqlConnection _Conexion = new SqlConnection(CONEXION.STR);
            SqlCommand _Comando = new SqlCommand("EliminarAeropuerto ", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@CodigoAeropuerto", unA.CodigoAeropuerto);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe el Aeropuerto");
                else if (oAfectados == -2)
                    throw new Exception("No se puede eliminar - Hay Viajes dentro de ese Aeropuerto");
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

        public static Aeropuertos Buscar(string cAero)
        {
            string nomAero = "";
            string dirAero = "";
            int ImpPartida = 0;
            int ImpLlegada = 0;

            Aeropuertos a = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarAeropuerto " + cAero, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    cAero = (string)oReader["CodigoAeropuerto"];
                    nomAero = (string)oReader["NombreAeropuerto"];
                    dirAero = (string)oReader["DireccionAeropuerto"];
                    ImpPartida = (int)oReader["ImpuestosPartida"];
                    ImpLlegada = (int)oReader["ImpuestosLlegada"];
                    

                    a = new Aeropuertos(cAero, nomAero, dirAero, ImpPartida, ImpLlegada, PersistenciaCiudad.Buscar(Convert.ToString(oReader["CodigoCiudad"])));
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
            return a;
        }

        public static List<Aeropuertos> ListarAeros()
        {
            List<Aeropuertos> oListarAeros = new List<Aeropuertos>();
            
            try
            {
                using (SqlConnection oConexion = new SqlConnection(CONEXION.STR))
                {
                    using (SqlCommand oComando = new SqlCommand("ListarAeropuertos", oConexion))
                    {
                        oComando.CommandType = CommandType.StoredProcedure;
                        
                        oConexion.Open();
                        
                        using (SqlDataReader oReader = oComando.ExecuteReader())
                       {
                            if (oReader.HasRows)
                            {
                                while (oReader.Read())
                                
                                {
                                    Ciudades _unaC = PersistenciaCiudad.Buscar(Convert.ToString(oReader["CodigoCiudad"]));
                                    Aeropuertos unA = new Aeropuertos(Convert.ToString(oReader["CodigoAeropuerto"]),
                                        Convert.ToString(oReader["NombreAeropuerto"]),
                                        Convert.ToString(oReader["DireccionAeropuerto"]),
                                        Convert.ToInt32(oReader["ImpuestosLlegada"]),
                                        Convert.ToInt32(oReader["ImpuestosPartida"]),
                                        _unaC);
                                    oListarAeros.Add(unA);
                                }
                            }
                       }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar aeropuertos", ex);
            }
            return oListarAeros;
        }
       
    }
}
