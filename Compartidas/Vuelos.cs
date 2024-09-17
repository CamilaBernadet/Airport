using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compartidas
{
    public class Vuelos
    {
        //atributos

        string _CodigoVuelo;
        DateTime _FechaHoraSalida;
        DateTime _FechaHoraLlegada;
        int _Precio;
        int _CantAsientos;

        Aeropuertos _CodigoAeropuertoLlegada;
        Aeropuertos _CodigoAeropuertoPartida;

        private List<Pasajes> _ListarPasajes;

        //propiedades

        public string CodigoVuelo
        {
            get { return _CodigoVuelo; }
            set { _CodigoVuelo = value; }
        }

        public DateTime FechaHoraSalida
        {
            get { return _FechaHoraSalida; }
            set { _FechaHoraSalida = value; }
        }

        public DateTime FechaHoraLlegada
        {
            set
            {
                if (value > FechaHoraSalida)
                    _FechaHoraLlegada = value;
                else
                    throw new Exception("La hora y fecha de llegada debe ser mayor a la de salida!");
            }
            get { return _FechaHoraLlegada; }
        }


        public int Precio
        {
            set
            {
                if (value >= 0)
                    _Precio = value;
                else
                    throw new Exception("Error - No puede ser gratis ni negativo!");
            }
            get { return _Precio; }
        }

        public int Asientos
        {
            set
            {
                if (value <= 300)  
                   _CantAsientos = value;
                else throw new Exception("Error - Maximo 300!");

                 if (100 <= value)
                 _CantAsientos = value;
                 else throw new Exception("Error - Minimo 100!"); 

            }
            get { return _CantAsientos; }
        }


        public Aeropuertos aeropuertoVueloPartida
        {
            get { return _CodigoAeropuertoPartida; }
            set
            {
                if (value != null)
                    _CodigoAeropuertoPartida = value;
                else
                    throw new Exception("Debe saberse el Aeropuerto de Partida");
            }
        }

        public Aeropuertos aeropuertoVueloLlegada
        {
            get { return _CodigoAeropuertoLlegada; }
            set
            {
                if (value != null)
                    _CodigoAeropuertoLlegada = value;
                else
                    throw new Exception("Debe saberse el Aeropuerto de Llegada");
            }
        }


        //public List<Pasajes> ListarPasajes
        //{
        //    get { return _ListarPasajes; }
        //    set
        //    {
        //        if (value == null)
        //            throw new Exception("No tiene Pasajes");
        //        if (value.Count == 0)
        //            throw new Exception("No tiene Pasajes");

        //        _ListarPasajes = value;
        //    }
        //}

        //constructor


        public Vuelos(string _codigoVuelo, DateTime _FechaHoraSalida, DateTime _FechaHoraLlegada, int _Precio, int _CantAsientos, Aeropuertos _CodigoAeropuertoLlegada, Aeropuertos _CodigoAeropuertoPartida)
        {
            CodigoVuelo = _codigoVuelo;
            FechaHoraSalida = _FechaHoraSalida;
            FechaHoraLlegada = _FechaHoraLlegada;
            Precio = _Precio;
            Asientos = _CantAsientos;
            aeropuertoVueloLlegada = _CodigoAeropuertoLlegada;
            aeropuertoVueloPartida = _CodigoAeropuertoPartida;

            //GenerarCodigoVuelo();

        }

        //operaciones

        public override string ToString()
        {
            return "Codigo: " + CodigoVuelo + " Fecha y Hora de Salida: " + FechaHoraSalida + " Fecha y Hora de Llegada: " + FechaHoraLlegada + "Precio: " + Precio + "Cantidad de Asientos: " + Asientos + "Aeropuerto de Salida: "+ aeropuertoVueloPartida + "Aeropuerto de Llegada: " + aeropuertoVueloLlegada;
        }

         

    }
}
