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
        public NombreCompleto NombreCompleto { get; set; }
        public string CI { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        //CONSTRUCTORES
        public Usuario(NombreCompleto nombreCompleto, string ci, string email, string password, string rol)
        {
            NombreCompleto = nombreCompleto;
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
            if (Rol != "Administrador" || Rol != "Funcionario")
            {
                throw new UsuarioException("El rol ingresado es invalido.");
            }
            if(Password.Length < 8)
            {
                throw new UsuarioException("La Password debe tener al menos 8 caracteres.");
            }
            if(CI.Length != 9)
            {
                throw new UsuarioException("La CI ingresada es incorrecta.");
            }
        }
    }
}
