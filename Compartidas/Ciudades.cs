using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compartidas
{
    public class Ciudades
    {
        
        //atributos
       
        string _CodigoCiudad;
        string _NombreCiudad;
        string _Pais;

        //propiedades

        public string CodigoCiudad
        {
            set
            {
                if (value == "")
                    throw new Exception("Error - El Codigo debe de ser ingresado!");
                if (value.Length != 6)
                    throw new Exception("Error - El Codigo debe de ser de 6 letras!");

                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                        throw new Exception("Error - El Codigo debe contener solo letras!");
                }
                    _CodigoCiudad = value;
            }
            get { return _CodigoCiudad; }
        }

        public string NomCiudad
        {
            set
            {
                if (value == "")
                    throw new Exception("Error - El Nombre debe de ser ingresado!");
                else
                    _NombreCiudad = value;
            }
            get { return _NombreCiudad; }
        }

         public string Pais
        {
            set
            {
                if (value == "")
                    throw new Exception("Error - El Pais debe de ser ingresado!");
                else
                    _Pais = value;
            }
            get { return  _Pais; }
        }


  
        //constructor

         public Ciudades(string _CodigoCiudad, string _NombreCiudad, string _Pais)
        {
            CodigoCiudad = _CodigoCiudad;
            NomCiudad = _NombreCiudad;
            Pais = _Pais;
        }

        //operaciones

        public override string ToString()
        {
            return "Codigo: " + CodigoCiudad + " Nombre: " + NomCiudad + " Pais: " + Pais;
        }
    }
}
