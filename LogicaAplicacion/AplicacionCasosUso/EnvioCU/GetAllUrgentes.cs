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
    public class GetAllUrgentes : IGetAllUrgentes
    {
        IEnvioRepository _repository;
        public GetAllUrgentes(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UrgenteDTO> Execute()
        {
            List<UrgenteDTO> urgentesDTO = new List<UrgenteDTO>();
            IEnumerable<Urgente> urgentes = _repository.GetAllUrgentes();
            foreach (Urgente urgente in urgentes)
            {
                urgentesDTO.Add(new UrgenteDTO(urgente));
            }
            return urgentesDTO;
        }
    }
}
