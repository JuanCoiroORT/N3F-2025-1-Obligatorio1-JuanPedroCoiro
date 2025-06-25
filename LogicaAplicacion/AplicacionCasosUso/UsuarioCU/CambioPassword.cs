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
    public class CambioPassword : ICambioPassword
    {
        IUsuarioRepository _repository;

        public CambioPassword(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(int id, string actual, string nueva)
        {
             Usuario usuario = _repository.GetById(id);
             if (usuario == null)
             {
                 throw new UsuarioException("Usuario no existe.");
             }

            _repository.CambioPassword(id, actual, nueva);

            return true;

        }
    }
}
