using Compartido.DTOs;
using LogicaAplicacion.Interfaces.AgenciaInterfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso.AgenciaCU
{
    public class GetAgencias : IGetAgencias
    {
        IAgenciaRepository _repository;

        public GetAgencias(IAgenciaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AgenciaDTO> Execute()
        {
            List<AgenciaDTO> agenciaDTOs = new List<AgenciaDTO>();
            IEnumerable<Agencia> agencias = _repository.GetAll();
            foreach (Agencia a in agencias)
            {
                agenciaDTOs.Add(new AgenciaDTO(a));
            }
            return agenciaDTOs;
        }
    }
}
