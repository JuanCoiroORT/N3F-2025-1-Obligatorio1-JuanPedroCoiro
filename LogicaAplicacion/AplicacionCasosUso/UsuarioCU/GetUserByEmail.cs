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
    public class GetUserByEmail : IGetUserByEmail
    {
        IUsuarioRepository _repository;

        public GetUserByEmail(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public UsuarioDTO Execute(string email)
        {
            Usuario usuario = _repository.GetByEmail(email);
            return new UsuarioDTO(usuario);
        }
    }
}
