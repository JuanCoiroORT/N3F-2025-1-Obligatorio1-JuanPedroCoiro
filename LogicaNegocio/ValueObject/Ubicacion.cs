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

        private void Validar()
        {
            //Validacion de la longitud y latitud
        }
    }
}
