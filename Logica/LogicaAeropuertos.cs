using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Compartidas;
using Persistencia;

namespace Logica
{
    public class LogicaAeropuertos
    {
        public static Aeropuertos BuscarAeropuerto(string cAero)
        {
            return PersistenciaAeropuerto.Buscar(cAero);
        }

        public static void AltaAeropuerto(Aeropuertos unA)
        {
            PersistenciaAeropuerto.Alta(unA);
        }

        public static void ModificarAeropuerto(Aeropuertos unA)
        {
            PersistenciaAeropuerto.Modificar(unA);
        }

        public static void EliminarAeropuerto(Aeropuertos unA)
        {
           PersistenciaAeropuerto.EliminarAero(unA);
        }

        public static List<Aeropuertos> ListarAeros()
        {
            return PersistenciaAeropuerto.ListarAeros();
        }
    }
}
