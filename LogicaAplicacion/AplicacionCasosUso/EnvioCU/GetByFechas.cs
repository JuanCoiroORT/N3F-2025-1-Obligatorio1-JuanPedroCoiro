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
    public class GetByFechas : IGetByFechas
    {
        IEnvioRepository _repository;
        public GetByFechas(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<EnvioDTO> Execute(DateTime? fch1, DateTime? fch2, string? estado)
        {
            List<EnvioDTO> enviosDTO = new List<EnvioDTO>();
            IEnumerable<Envio> envios = _repository.GetByFechas(fch1, fch2, estado);
            foreach (Envio envio in envios)
            {
                enviosDTO.Add(new EnvioDTO(envio));
            }
            return enviosDTO;
        }
    }
}
