using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;
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

        public NombreCompleto() { }

        private void Validar()
        {
            if (String.IsNullOrEmpty(Nombre) || Nombre.Length < 3)
            {
                throw new UsuarioException("Ingrese un nombre.");
            }
            if (String.IsNullOrEmpty(Apellido) || Apellido.Length < 3)
            {
                throw new UsuarioException("Ingrese un apellido.");
            }
        }
    }
}
