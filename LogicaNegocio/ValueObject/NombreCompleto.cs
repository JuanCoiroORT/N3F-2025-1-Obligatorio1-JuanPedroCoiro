using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObject
{
    [Owned]
    public class NombreCompleto
    {
        public string Nombre { get; }
        public string Apellido { get; }

        public NombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
            Validar();
        }

        public NombreCompleto()
        {
        }

        private void Validar()
        {
            // TODO VALIDAR NOMBRE COMPLETO
        }
    }
}
