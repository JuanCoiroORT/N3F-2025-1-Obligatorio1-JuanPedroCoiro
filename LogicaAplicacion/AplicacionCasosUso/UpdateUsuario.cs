using Compartido.DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso
{
    public class UpdateUsuario
    {
        IUsuarioRepository _repository;
        public UpdateUsuario(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioDTO Execute(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException(nameof(usuarioDTO), "El usuario no puede ser nulo.");
            }
            Usuario usuario = usuarioDTO.ToUsuario();
            _repository.Update(usuario);
            UsuarioDTO usuarioEditadoDTO = new UsuarioDTO(usuario);
            return usuarioEditadoDTO;
        }
    }
}
