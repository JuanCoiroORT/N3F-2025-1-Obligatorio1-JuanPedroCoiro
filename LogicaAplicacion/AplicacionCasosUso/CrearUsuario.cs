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
    public class CrearUsuario : ICrearUsuario
    {
        IUsuarioRepository _repository;
        public CrearUsuario(IUsuarioRepository repository) 
        {
            _repository = repository;
        }
        public UsuarioDTO Execute(UsuarioDTO usuarioDTO)
        {
            // PASA DTO A USUARIO
            Usuario usuario = usuarioDTO.ToUsuario();
            // VALIDA EL USUARIO
            usuario.Validar();
            // AGREGA USUARIO A REPOSITORIO
            _repository.Add(usuario);
            UsuarioDTO nuevoUsuarioDTO = new UsuarioDTO(usuario);
            return nuevoUsuarioDTO;
        }
    }
}
