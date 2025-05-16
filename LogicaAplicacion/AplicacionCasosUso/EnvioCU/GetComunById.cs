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
    public class GetComunById : IGetComunById
    {
        IEnvioRepository _repository;
        public GetComunById(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public ComunDTO Execute(int id)
        {
            Comun comun = _repository.GetComunById(id);
            return new ComunDTO(comun);
        }
    }
}
