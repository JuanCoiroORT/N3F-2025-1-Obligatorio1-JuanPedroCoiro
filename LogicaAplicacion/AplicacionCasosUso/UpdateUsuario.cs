using Compartido.DTOs;
using LogicaAplicacion.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso
{
    public class UpdateUsuario : IUpdateUsuario
    {
        IUsuarioRepository _repository;
        public UpdateUsuario(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioDTO Execute(int id, UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException(nameof(usuarioDTO), "El usuario no puede ser nulo.");
            }
            Usuario usuario = usuarioDTO.ToUsuario();
            usuario.Id = id;
            _repository.Update(id, usuario);
            UsuarioDTO usuarioEditadoDTO = new UsuarioDTO(usuario);
            return usuarioEditadoDTO;
        }
    }
}
