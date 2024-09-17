using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Compartidas;

namespace Persistencia
{
    public class PersistenciaPasajes
    {
        public static void Venta(Pasajes pPasajes)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("VentaPasajes ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@PrecioTotal", pPasajes.PrecioTotal);
            oComando.Parameters.AddWithValue("@CodigoVuelo", pPasajes.vueloPasaje.CodigoVuelo);
            oComando.Parameters.AddWithValue("@Pasaporte", pPasajes.clientePasaje.Pasaporte);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe Vuelo con ese Codigo");
                else if (oAfectados == -2)
                    throw new Exception("Ya no hay asientos para este Vuelo");
                else if (oAfectados == -3)
                    throw new Exception("No existe el Cliente");
                else if (oAfectados == -4)
                    throw new Exception("Error en BD");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Pasajes> Compras(Clientes cliente)
        {
            List<Pasajes> _lista = new List<Pasajes>();
            SqlDataReader _Reader;

            using (SqlConnection _Conexion = new SqlConnection(CONEXION.STR))
            {
                using (SqlCommand _Comando = new SqlCommand("Compras", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    _Comando.Parameters.AddWithValue("@Pasaporte", cliente.Pasaporte);

                    try
                    {
                        _Conexion.Open();
                        _Reader = _Comando.ExecuteReader();

                            if (_Reader.HasRows)
                            {
                                while (_Reader.Read())
                                {
                                    Pasajes unP = new Pasajes(
                                        Convert.ToInt32(_Reader["NroVenta"]),
                                        Convert.ToInt32(_Reader["PrecioTotal"]),
                                        Convert.ToDateTime(_Reader["FechaCompra"]),
                                        PersistenciaVuelos.Buscar(Convert.ToString(_Reader["CodigoVuelo"])),
                                        cliente);

                                    _lista.Add(unP);
                                }
                            }
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                    finally
                    {
                        _Conexion.Close();
                    }
                }

                return _lista;
            }
        }
    }
}
