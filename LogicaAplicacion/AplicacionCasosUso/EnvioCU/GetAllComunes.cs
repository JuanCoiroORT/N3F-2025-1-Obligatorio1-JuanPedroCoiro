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
    public class GetAllComunes : IGetAllComunes
    {
        IEnvioRepository _repository;
        public GetAllComunes(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ComunDTO> Execute()
        {
            List<ComunDTO> comunesDTO = new List<ComunDTO>();
            IEnumerable<Comun> comunes = _repository.GetAllComunes();
            foreach (Comun comun in comunes)
            {
                comunesDTO.Add(new ComunDTO(comun));
            }
            return comunesDTO;
        }
    }
}
