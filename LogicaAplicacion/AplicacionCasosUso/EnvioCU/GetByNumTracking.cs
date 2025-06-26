using Compartido.DTOs;
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
    public class GetByNumTracking : IGetByNumTracking
    {
        IEnvioRepository _repository;
        public GetByNumTracking(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public EnvioDTO Execute(string numTracking)
        {
            Envio envio = _repository.GetByNumTracking(numTracking);
            if (envio == null)
                return null;
            return new EnvioDTO(envio);
        }
    }
}
