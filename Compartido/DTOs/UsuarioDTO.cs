using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;

namespace Compartido.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string CI { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }

        public UsuarioDTO(Usuario usuario)
        {
            Id = usuario.Id;
            CI = usuario.CI;
            NombreCompleto = usuario.NombreCompleto;
            Email = usuario.Email;
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
                NombreCompleto = this.NombreCompleto,
                CI = this.CI,
                Email = this.Email,
                Rol = this.Rol
            };
            return usuario;
        }
    }
}
