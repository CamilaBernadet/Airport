using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compartidas
{
    public class Pasajes
    {
        //atributos
        int _nroVenta;
        int _PrecioTotal;
        DateTime _FechaCompra;

        Vuelos _CodigoVuelo;
        Clientes _Pasaporte;

               


        //propiedades
        public int NroVenta
        {
            get { return _nroVenta; }
            set { _nroVenta = value; }
        }

         public int PrecioTotal
        {
            get { return _PrecioTotal; }
            set { _PrecioTotal = value; }
        }

        public DateTime FechaCompra
        {
            get { return _FechaCompra; }
            set { _FechaCompra = value; }
        }



        public Vuelos vueloPasaje
        {
            get { return _CodigoVuelo; }
            set
            {
                if (value != null)
                    _CodigoVuelo = value;
                else
                    throw new Exception("Debe saberse el Vuelo del Pasaje");
            }
        }

        public Clientes clientePasaje
        {
            get { return _Pasaporte; }
            set
            {
                if (value != null)
                    _Pasaporte = value;
                else
                    throw new Exception("Debe saberse el Cliente del Pasaje");
            }
        }




        //constructor


        public Pasajes( int _NroVenta,int _PrecioTotal, DateTime _FechaCompra, Vuelos _CodigoVuelo, Clientes _Pasaporte)
        {
            NroVenta = _nroVenta;
            PrecioTotal = _PrecioTotal;
            FechaCompra = _FechaCompra;
            vueloPasaje = _CodigoVuelo;
            clientePasaje = _Pasaporte;

        }

        //operaciones

        //public int CalcularPrecioTotal()
        //{

        //    int precioVuelo = vueloPasaje.Precio;
        //    int impuestoPartida = vueloPasaje.aeropuertoVueloPartida.ImpPartida;
        //    int impuestoLlegada = vueloPasaje.aeropuertoVueloLlegada.ImpLlegada;

        //    // Calcular el precio total sumando el precio del vuelo y los impuestos
        //    int precioTotalVenta = precioVuelo + impuestoPartida + impuestoLlegada;

        //    return precioTotalVenta;
        //}


        public override string ToString()
        {
            return "Numero de Venta: " + NroVenta + "Precio Total (sumando los Impuestos): " + PrecioTotal + " Fecha de Compra: " + FechaCompra + "Vuelo del Pasaje: " + vueloPasaje + "Cliente del Pasaje " + clientePasaje;
        }
    }
}
