using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Compartidas;
using Persistencia;

namespace Logica
{
    public class LogicaVuelos
    {
        public static void AltaVuelos(Vuelos unV)
        {
            string fechaCodigo = unV.FechaHoraSalida.ToString("yyyyMMddHHmm");
            string codigoVuelo = unV.aeropuertoVueloPartida.CodigoAeropuerto;
            unV.CodigoVuelo = fechaCodigo + codigoVuelo;

            PersistenciaVuelos.Alta(unV);
        }

        public static List<Vuelos> ListarVuelos()
        {
            return PersistenciaVuelos.ListarVuelos();
        }

        public static Vuelos BuscarVuelos(string codigoV)
        {
            return PersistenciaVuelos.Buscar(codigoV);
        }

        public static List<Vuelos> ListarVuelosporBusqueda(string codigoV)
        {
            return PersistenciaVuelos.ListarVuelosporBusqueda(codigoV);
        }

        public static List<Vuelos> ListarPorAeropuerto(Aeropuertos unA)
        {
            return PersistenciaVuelos.ListarPorAeropuerto(unA);
        }

        public static List<Vuelos> ListarVuelosSinPartir(Aeropuertos unA)
        {
            return PersistenciaVuelos.ListarVuelosSinPartir(unA);
        }

        public static List<Vuelos> ListarVuelosSinLlegar(Aeropuertos unA)
        {
            return PersistenciaVuelos.ListarVuelosSinLlegar(unA);
        }
    }
}
