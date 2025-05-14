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
    
    public class DeleteUsuario : IDeleteUsuario
    {
        IUsuarioRepository _repository;
        public DeleteUsuario(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            {
                if (id <= 0)
                    throw new ArgumentException("El id debe ser mayor a cero.", nameof(id));

                _repository.Delete(id);
            }
        }

    }
}
