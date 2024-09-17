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
    public class PersistenciaVuelos
    {
        public static void Alta(Vuelos vVuelos)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AltaVuelo ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoVuelo", vVuelos.CodigoVuelo);
            oComando.Parameters.AddWithValue("@FechaHoraSalida", vVuelos.FechaHoraSalida);
            oComando.Parameters.AddWithValue("@FechaHoraLlegada", vVuelos.FechaHoraLlegada);
            oComando.Parameters.AddWithValue("@Precio", vVuelos.Precio);
            oComando.Parameters.AddWithValue("@CantidadAsientos", vVuelos.Asientos);
            oComando.Parameters.AddWithValue("@CodigoAeropuertoSalida", vVuelos.aeropuertoVueloPartida.CodigoAeropuerto);
            oComando.Parameters.AddWithValue("@CodigoAeropuertoLlegada", vVuelos.aeropuertoVueloLlegada.CodigoAeropuerto);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe el Aeropuerto de Salida");
                if (oAfectados == -2)
                    throw new Exception("No existe el Aeropuerto de Llegada");
                if (oAfectados == -3)
                    throw new Exception("Ya existe ese Vuelo");
            }
            catch (Exception ex)
            {
                throw new Exception("Error en PersistenciaVuelos " + ex.Message, ex);
            }
            finally
            {
                oConexion.Close();
            }
        }
        public static Vuelos Buscar(string codigoVuelo)
        {
            Vuelos v = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("BuscarVuelos '" + codigoVuelo + "'",  oConexion);

           // DateTime FechaSalida, FechaHoraLlegada;
            //int Precio, cantAsientos;
            //Aeropuertos unAL, unAS;

            

            try
            {

                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {

                    while (oReader.Read())
                    {
                        string codigo = (string)oReader["CodigoVuelo"];
                        DateTime FechaSalida = DateTime.Parse(oReader["FechaHoraSalida"].ToString());
                        DateTime FechaHoraLlegada = DateTime.Parse(oReader["FechaHoraLlegada"].ToString());
                        int Precio = Convert.ToInt32(oReader["Precio"]);
                        int cantAsientos = Convert.ToInt32(oReader["CantidadAsientos"]);
                        Aeropuertos unAL = PersistenciaAeropuerto.Buscar(oReader["AeropuertoLlegada"].ToString());
                        Aeropuertos unAS = PersistenciaAeropuerto.Buscar(oReader["AeropuertoSalida"].ToString());

                        v = new Vuelos(codigo, FechaSalida, FechaHoraLlegada, Precio, cantAsientos, unAL, unAS);

                    }
                }

                oReader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Problemas con la base de datosS:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return v;
        }


        public static List<Vuelos> ListarVuelosporBusqueda(string vCodigo)
        {


            List<Vuelos> _listaVB = new List<Vuelos>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(CONEXION.STR);
            SqlCommand _Comando = new SqlCommand("ListarVuelosporBusqueda", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@codigoV", vCodigo);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Vuelos unV = new Vuelos(Convert.ToString((_Reader["CodigoVuelo"])),
                            Convert.ToDateTime(_Reader["FechaHoraSalida"]), 
                            Convert.ToDateTime(_Reader["FechaHoraLlegada"]), 
                            Convert.ToInt32(_Reader["Precio"]),
                            Convert.ToInt32(_Reader["CantidadAsientos"]), 
                            PersistenciaAeropuerto.Buscar(Convert.ToString(_Reader["CodigoAeropuerto"])), 
                            PersistenciaAeropuerto.Buscar(Convert.ToString(_Reader["CodigoAeropuerto"])));
                        _listaVB.Add(unV);
                    }
                }

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return _listaVB;
        }
  


        public static List<Vuelos> ListarVuelos()
        {
            SqlConnection _cnn = new SqlConnection(CONEXION.STR);
            SqlCommand _comando = new SqlCommand("ListarVuelos", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            Vuelos unV = null;
            List<Vuelos> _listaV = new List<Vuelos>();

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        unV = new Vuelos(Convert.ToString((_lector["CodigoVuelo"])),
                            Convert.ToDateTime(_lector["FechaHoraSalida"]), 
                            Convert.ToDateTime(_lector["FechaHoraLlegada"]), 
                            Convert.ToInt32(_lector["Precio"]), 
                            Convert.ToInt32(_lector["CantidadAsientos"]),
                            PersistenciaAeropuerto.Buscar(Convert.ToString(_lector["AeropuertoLlegada"])),
                            PersistenciaAeropuerto.Buscar(Convert.ToString(_lector["AeropuertoSalida"])));
                        _listaV.Add(unV);
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

            return _listaV;

        }
        public static List<Vuelos> ListarPorAeropuerto(Aeropuertos unA)
        {
            List<Vuelos> _lista = new List<Vuelos>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(CONEXION.STR);
            SqlCommand _Comando = new SqlCommand("ListarVuelosporAeropuertos", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@aero", unA.CodigoAeropuerto);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Vuelos V = new Vuelos(Convert.ToString((_Reader["CodigoVuelo"])),Convert.ToDateTime(_Reader["FechaHoraSalida"]), Convert.ToDateTime(_Reader["FechaHoraLlegada"]), Convert.ToInt32(_Reader["Precio"]), Convert.ToInt32(_Reader["CantidadAsientos"]), unA, unA);
                        _lista.Add(V);
                    }
                }

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return _lista;
        }

        public static List<Vuelos> ListarVuelosSinPartir(Aeropuertos unA)
        {

            SqlConnection _str = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ListarVuelosSinPartir ", _str);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@aero", unA.CodigoAeropuerto);


            Vuelos unV = null;
            List<Vuelos> _listaV = new List<Vuelos>();

            try
            {
                _str.Open();

                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        unV = new Vuelos(Convert.ToString((oReader["CodigoVuelo"])),Convert.ToDateTime(oReader["FechaHoraSalida"]), Convert.ToDateTime(oReader["FechaHoraLlegada"]), Convert.ToInt32(oReader["Precio"]), Convert.ToInt32(oReader["CantidadAsientos"]), unA, unA);

                        _listaV.Add(unV);


                    }
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _str.Close();
            }

            return _listaV;

        }

        public static List<Vuelos> ListarVuelosSinLlegar(Aeropuertos unA)
        {

            SqlConnection _str = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ListarVuelosSinLlegar ", _str);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@aero", unA.CodigoAeropuerto);


            Vuelos unV = null;
            List<Vuelos> _listaV = new List<Vuelos>();

            try
            {
                _str.Open();

                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        unV = new Vuelos(Convert.ToString((oReader["CodigoVuelo"])),Convert.ToDateTime(oReader["FechaHoraSalida"]), Convert.ToDateTime(oReader["FechaHoraLlegada"]), Convert.ToInt32(oReader["Precio"]), Convert.ToInt32(oReader["CantidadAsientos"]), unA, unA);

                        _listaV.Add(unV);


                    }
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _str.Close();
            }

            return _listaV;

        }
    }
}
