using Compartido.DTOs;
using LogicaAplicacion.Interfaces.ComunInterfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso.ComunCU
{
    public class GetEnviosComunes : IGetEnviosComunes
    {
        IComunRepository _repository;
        public GetEnviosComunes(IComunRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ComunDTO> Execute()
        {
            List<ComunDTO> comunDTOs = new List<ComunDTO>();
            IEnumerable<Comun> comunes = _repository.GetAll();
            foreach (Comun comun in comunes)
            {
                comunDTOs.Add(new ComunDTO(comun));
            }
            return comunDTOs;
        }
    }
}
