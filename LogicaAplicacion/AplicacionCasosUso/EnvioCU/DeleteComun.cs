using LogicaAplicacion.Interfaces.EnvioInterfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso.EnvioCU
{
    public class DeleteComun : IDeleteComun
    {
        IEnvioRepository _repository;
        public DeleteComun(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.DeleteComun(id);
        }

    }
}
