using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario
    {
        public int Id { get; set; }
        private static int s_ultId;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CI { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        //CONSTRUCTORES
        public Usuario(string nombre, string apellido, string ci, string email, string password, string rol)
        {
            Nombre = nombre;
            Apellido = apellido;
            CI = ci;
            Email = email;
            Password = password;
            Rol = rol;
            Validar();
        }

        public Usuario()
        {
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Email) || Email.Length < 7 || !Email.Contains("@") || !Email.Contains(".com"))
            {
                throw new UsuarioException("Email invalido.");
            }
            if (String.IsNullOrEmpty(Email) || Nombre.Length < 3)
            {
                throw new UsuarioException("Ingrese un nombre correcto.");
            }
            if (String.IsNullOrEmpty(Email) || Apellido.Length < 3)
            {
                throw new UsuarioException("Ingrese un apellido correcto.");
            }
            if (String.IsNullOrEmpty(Email) || Password.Length < 8)
            {
                throw new UsuarioException("La Password debe tener al menos 8 caracteres.");
            }
            if(CI.Length != 8)
            {
                throw new UsuarioException("La CI ingresada es incorrecta, recuerde no utilizar el guion.");
            }
        }
    }
}
