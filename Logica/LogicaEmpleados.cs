using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Compartidas;
using Persistencia;

namespace Logica
{
    public class LogicaEmpleados
    {
        public static Empleados Logueo(string Usuario, string ContraEmp)
        {
            return Persistencia.PersistenciaEmpleado.Logueo(Usuario, ContraEmp);
        }
    }
}
