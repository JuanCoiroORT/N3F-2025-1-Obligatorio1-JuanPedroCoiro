using Compartido.DTOs;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso.UsuarioCU
{
    public class GetUsersByName : IGetUsersByName
    {
        IUsuarioRepository _repository;
        public GetUsersByName(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UsuarioDTO> Execute(string name)
        {
            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            IEnumerable<Usuario> usuarios = _repository.GetByName(name);
            foreach (Usuario usuario in usuarios)
            {
                usuariosDTO.Add(new UsuarioDTO(usuario));
            }
            return usuariosDTO;
        }
    }
}
