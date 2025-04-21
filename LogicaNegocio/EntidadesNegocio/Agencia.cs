using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Agencia
    {
        public int Id { get; set; }
        private static int s_ultId;
        public string Nombre { get; set; }
        public int DireccionPostal { get; set; }
        public Ubicacion Ubicacion { get; set; }

        //CONSTRUCTOR
        public Agencia(string nombre, int direccionPostal, Ubicacion ubicacion)
        {
            Nombre = nombre;
            DireccionPostal = direccionPostal;
            Ubicacion = ubicacion;
        }

    }
}
