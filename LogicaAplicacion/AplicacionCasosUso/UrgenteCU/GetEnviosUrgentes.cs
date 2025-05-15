using Compartido.DTOs;
using LogicaAplicacion.Interfaces.UrgenteInterfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso.UrgenteCU
{
    public class GetEnviosUrgentes : IGetEnviosUrgentes
    {
        IUrgenteRepository _repository;
        public GetEnviosUrgentes(IUrgenteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UrgenteDTO> Execute()
        {
            List<UrgenteDTO> urgenteDTOs = new List<UrgenteDTO>();
            IEnumerable<Urgente> urgentes = _repository.GetAll();
            foreach (Urgente u in urgentes)
            {
                urgenteDTOs.Add(new UrgenteDTO(u)); 
            }
            return urgenteDTOs;
        }
    }
}
