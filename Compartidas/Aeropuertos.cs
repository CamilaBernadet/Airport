using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compartidas
{
    public class Aeropuertos
    {
         //atributos

        string _CodigoAeropuerto;
        string _NomAeropuerto;
        string _Direccion;
        int _ImpLlegada;
        int _ImpPartida;

        Ciudades _CodigoCiudad;


        //propiedades

        public string CodigoAeropuerto
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Error - El Codigo debe de ser ingresado!");
                if (value.Length != 3)
                    throw new Exception("Error - El Código debe ser de 3 letras!");

                // Verificar que el valor contenga solo letras y que sean mayúsculas
                foreach (char c in value)
                {
                    if (!char.IsLetter(c) || !char.IsUpper(c))
                        throw new Exception("Error - El Código debe contener solo letras mayúsculas!");
                }
                
                    _CodigoAeropuerto = value;
            }
            get { return _CodigoAeropuerto; }
        }

        public string NomAeropuerto
        {
            set
            {
                if (value == "")
                    throw new Exception("Error - El Nombre debe de ser ingresado!");
                else
                    _NomAeropuerto = value;
            }
            get { return _NomAeropuerto; }
        }

        public string Direccion
        {
            set
            {
                if (value == "")
                    throw new Exception("Error - La Direccion debe de ser ingresada!");
                else
                    _Direccion = value;
            }
            get { return _Direccion; }
        }

        public int ImpLlegada
        {
            set
            {
                if (value >= 0)
                    _ImpLlegada = value;
                else
                    throw new Exception("Error - El Impuesto tiene que ser positivo!");
            }
            get { return _ImpLlegada; }
        }

        public int ImpPartida
        {
            set
            {
                if (value >= 0)
                    _ImpPartida = value;
                else
                    throw new Exception("Error - El Impuesto tiene que ser positivo!");
            }
            get { return _ImpPartida; }
        }


        public Ciudades ciudadAeropuerto
        {
            get { return _CodigoCiudad; }
            set
            {
                if (value != null)
                    _CodigoCiudad = value;
                else
                    throw new Exception("Debe saberse la Ciudad donde se encuentra el Aeropuerto");
            }
        }


        //constructor
        public Aeropuertos(string _CodigoAeropuerto, string _NomAeropuerto, string _Direccion, int _ImpLlegada, int _ImpPartida, Ciudades _CodigoCiudad)
        {
            CodigoAeropuerto = _CodigoAeropuerto;
            NomAeropuerto = _NomAeropuerto;
            Direccion = _Direccion;
            ImpLlegada = _ImpLlegada;
            ImpPartida = _ImpPartida;
            ciudadAeropuerto = _CodigoCiudad;

        }

        //operaciones

        public override string ToString()
        {
            return "Codigo: " + CodigoAeropuerto + " Nombre: " + NomAeropuerto + " Direccion: " + Direccion + "Impuestos de Llegada: " + ImpLlegada + "Impuestos de Partida: " + ImpPartida + "Ciudad: "+ ciudadAeropuerto;
        }
    }
}
