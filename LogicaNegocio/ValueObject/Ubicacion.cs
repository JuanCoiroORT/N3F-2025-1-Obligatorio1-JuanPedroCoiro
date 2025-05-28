using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class Ubicacion
    {
        public double Latitud { get; }
        public double Longitud { get; }

        public Ubicacion(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
            Validar();
        }

        public Ubicacion() { }  

        private void Validar()
        {
            if(Latitud < -90 && Latitud > 90)
            {
                throw new UsuarioException("Latitud fuera de rango.");
            }
            if(Longitud < -180 && Longitud > 180)
            {
                throw new UsuarioException("Longitud fuera de rango.");
            }
        }
    }
}
