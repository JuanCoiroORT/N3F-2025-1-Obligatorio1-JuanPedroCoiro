using LogicaAplicacion.Interfaces.EnvioInterfaces;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso.EnvioCU
{
    public class ExisteNumTracking : IExisteNumTracking
    {
        IEnvioRepository _repository;
        public ExisteNumTracking(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(double numTracking)
        {
            return _repository.ExisteNumTracking(numTracking);
        }
    }
}
