using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Compartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPasajes
    {
        public static void VentaPasajes(Pasajes unP)
        {
            
           PersistenciaPasajes.Venta(unP);
        }

        public static List<Pasajes> Compras(Clientes pasaporte)
        {
            return PersistenciaPasajes.Compras(pasaporte);
        }
    }
}
