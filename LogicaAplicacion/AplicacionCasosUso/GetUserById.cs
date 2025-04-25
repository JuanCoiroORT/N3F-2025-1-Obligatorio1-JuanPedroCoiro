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
    public class GetUserById : IGetUserById
    {
        IUsuarioRepository _repository;

        public GetUserById(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioDTO Execute(int id)
        {
            Usuario usuario = _repository.GetById(id);
            return new UsuarioDTO(usuario);
        }
    }
}
