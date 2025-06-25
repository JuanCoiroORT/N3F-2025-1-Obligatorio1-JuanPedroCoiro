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
    public class GetByComentario : IGetByComentario
    {
        IEnvioRepository _repository;
        public GetByComentario(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<EnvioDTO> Execute(int id, string comentario)
        {
            List<EnvioDTO> enviosDTO = new List<EnvioDTO>();
            IEnumerable<Envio> envios = _repository.GetByComentario(id, comentario);
            foreach (Envio envio in envios)
            {
                enviosDTO.Add(new EnvioDTO(envio));
            }
            return enviosDTO;
        }
    }
}
