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
    public class GetUrgenteById : IGetUrgenteById
    {
        IEnvioRepository _repository;
        public GetUrgenteById(IEnvioRepository envioRepository)
        {
            _repository = envioRepository;
        }

        public UrgenteDTO Execute(int id)
        {
            Urgente urgente = _repository.GetUrgenteById(id);
            return new UrgenteDTO(urgente);
        }
    }
}
