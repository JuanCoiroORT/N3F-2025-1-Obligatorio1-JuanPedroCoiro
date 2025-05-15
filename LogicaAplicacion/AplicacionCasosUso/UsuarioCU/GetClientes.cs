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
    public class GetClientes : IGetClientes
    {
        IUsuarioRepository _repository;
        public GetClientes(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UsuarioDTO> Execute()
        {
            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            IEnumerable<Usuario> usuarios = _repository.GetClientes();
            foreach (Usuario usuario in usuarios)
            {
                usuariosDTO.Add(new UsuarioDTO(usuario));
            }
            return usuariosDTO;
        }
    }
}
