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
            if (usuario == null)
            {
                throw new UsuarioException("Usuario no existe.");
            }
            return new UsuarioDTO(usuario);
        }
    }
}
