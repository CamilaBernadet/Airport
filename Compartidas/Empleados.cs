using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compartidas
{
    public class Empleados
    {
        
        //atributos
       
        string _Usuario;
        string _ContraseñaEmpleado;
        string _NombreEmp;
        string _Labor;

        //propiedades

        public string Usuario
        {
            set
            {
                if (value == "")
                    throw new Exception("Error - El Usuario debe de ser ingresado!");
                else
                    _Usuario = value;
            }
            get { return _Usuario; }
        }

        public string ContraEmpleado
        {
            set
            {
                if (value == "")
                    throw new Exception("Error - La Contraseña debe de ser ingresada!");
                else
                    _ContraseñaEmpleado = value;
            }
            get { return _ContraseñaEmpleado; }
        }

         public string NombreEmp
        {
            set
            {
                if (value == "")
                    throw new Exception("Error - El Nombre debe de ser ingresado!");
                else
                    _NombreEmp = value;
            }
            get { return _NombreEmp; }
        }

         public string Labor
        {
            set
            {
                if ((value != "Vendedor") && (value != "Gerente" ) && (value!= "Admin"))
                    throw new Exception("Error - El Labor debe de ser ingresado!");
                else
                    _Labor = value;
            }
            get { return _Labor; }
        }


        
        //constructor

         public Empleados(string _Usuario, string _ContraseñaEmpleado, string _NombreEmp, string _Labor)
        {
            Usuario = _Usuario;
            ContraEmpleado = _ContraseñaEmpleado;
            NombreEmp = _NombreEmp;
            Labor = _Labor;
        }

        //operaciones

        public override string ToString()
        {
            return "Usuario: " + Usuario + " Contraseña: " + ContraEmpleado + " Nombre: " + NombreEmp + "Labor: " + Labor;
        }
    }
}
