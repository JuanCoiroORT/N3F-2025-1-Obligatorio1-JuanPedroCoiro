using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;

namespace Compartido.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CI { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        public UsuarioDTO(Usuario usuario)
        {
            Id = usuario.Id;
            CI = usuario.CI;
            Nombre = usuario.Nombre;
            Apellido = usuario.Apellido;
            Email = usuario.Email;
            Password = usuario.Password;
            Rol = usuario.Rol;
        }

        public UsuarioDTO()
        {
        }

        public Usuario ToUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                CI = this.CI,
                Email = this.Email,
                Password = this.Password,
                Rol = this.Rol
            };
            return usuario;
        }
    }
}
