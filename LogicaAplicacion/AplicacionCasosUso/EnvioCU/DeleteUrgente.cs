using LogicaAplicacion.Interfaces.EnvioInterfaces;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso.EnvioCU
{
    public class DeleteUrgente : IDeleteUrgente
    {
        IEnvioRepository _repository;
        public DeleteUrgente(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.DeleteUrgente(id);
        }
    }
}
