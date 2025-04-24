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
        }

        public Usuario()
        {
        }

        public void Validar()
        {
            //TODO VALIDACION USUARIO
        }
    }
}
