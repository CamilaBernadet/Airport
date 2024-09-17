using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Compartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCiudades
    {
        public static Ciudades BuscarCiudad(string cCodigo)
        {
            return PersistenciaCiudad.Buscar(cCodigo);
        }

        public static void AltaCiudad(Ciudades unaC)
        {
            PersistenciaCiudad.Alta(unaC);
        }

        public static void ModificarCiudad(Ciudades unaC)
        {
            PersistenciaCiudad.Modificar(unaC);
        }

        public static void EliminarCiudad(Ciudades unaC)
        {
            PersistenciaCiudad.EliminarCiudad(unaC);
        }

        public static List<Ciudades> ListarCiudad()
        {
            return PersistenciaCiudad.ListarCiudad();
        }
    }
}
