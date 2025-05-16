using Compartido.DTOs;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso.UsuarioCU
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
            // Pasa DTO a Usuario
            Usuario usuario = usuarioDTO.ToUsuario();

            // Validar
            usuario.Validar();

            // Agregar
            _repository.Add(usuario);
            UsuarioDTO nuevoUsuarioDTO = new UsuarioDTO(usuario);
            return nuevoUsuarioDTO;
        }
    }
}
