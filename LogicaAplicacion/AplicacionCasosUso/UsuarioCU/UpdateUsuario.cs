using Compartido.DTOs;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso.UsuarioCU
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
            //Pasa dto a usuario
            Usuario usuario = usuarioDTO.ToUsuario();
            if (usuario == null)
            {
                throw new UsuarioException("Usuario no existe.");
            }

            //Validar
            usuario.Validar();

            // Ejecutar Update
            _repository.Update(id, usuario);

            // Devolver usuarionuevoDTO
            UsuarioDTO usuarioEditadoDTO = new UsuarioDTO(usuario);
            return usuarioEditadoDTO;
        }
    }
}
