using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compartidas
{
    public class Clientes
    {
         //atributos
        
        string _Pasaporte;
        string _ContraseñaCliente;
        string _NombreCliente;
        int _NroTarjeta;


        //propiedades

        public string Pasaporte
        {
            get { return _Pasaporte; }
            set { _Pasaporte = value; }
        }

 
        public string NomCliente
        {
            set
            {
                if (value == "")
                    throw new Exception("Error - El Nombre debe de ser ingresado!");
                else
                    _NombreCliente = value;
            }
            get { return _NombreCliente; }
        }

         public int NroTarjeta
        {
            get { return _NroTarjeta; }
            set { _NroTarjeta = value; }
        }

         public string ContraCliente
         {
             set
             {
                 if (value == "")
                     throw new Exception("Error - La Contraseña debe de ser ingresada!");
                 else
                     _ContraseñaCliente = value;
             }
             get { return _ContraseñaCliente; }
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

         public Clientes(string _Pasaporte, string _NombreCliente, int _NroTarjeta, string _ContraseñaCliente)
        {
            Pasaporte = _Pasaporte;
            NomCliente = _NombreCliente;
            NroTarjeta = _NroTarjeta;
            ContraCliente = _ContraseñaCliente;
        }

        //operaciones

        public override string ToString()
        {
            return "Pasaporte: " + Pasaporte + " Nombre: " + NomCliente + "NroTarjeta: " + NroTarjeta + " Contraseña: " + ContraCliente;
        }
    }
}
