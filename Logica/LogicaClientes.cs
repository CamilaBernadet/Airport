using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Compartidas;
using Persistencia;

namespace Logica
{
    public class LogicaClientes
    {
        public static Clientes Logueo (string Pasaporte, string ContraCliente)
        {
            return PersistenciaCliente.Logueo(Pasaporte, ContraCliente);
        }

        public static Clientes BuscarCliente(string Pasaporte)
        {
            return PersistenciaCliente.Buscar(Pasaporte);
        }

        public static void AltaCliente(Clientes unC)
        {
            PersistenciaCliente.Alta(unC);
        }

        public static void ModificarCliente(Clientes unC)
        {
            PersistenciaCliente.Modificar(unC);
        }

        public static void EliminarCliente(Clientes unC)
        {
            PersistenciaCliente.EliminarCliente(unC);
        }

        public static List<Clientes> ListarClientes()
        {
            return PersistenciaCliente.ListarClientes();
        }
    }
}
