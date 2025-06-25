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
    public class GetSeguimientosById : IGetSeguimientosById
    {
        IEnvioRepository _repository;
        public GetSeguimientosById(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SeguimientoDTO> Execute(int id)
        {
            List<SeguimientoDTO> seguimientosDTO = new List<SeguimientoDTO>();
            IEnumerable<Seguimiento> seguimientos = _repository.GetSeguimientosById(id);

            foreach (Seguimiento s in seguimientos)
            {
                seguimientosDTO.Add(new SeguimientoDTO(s));
            }
            return seguimientosDTO;
        }
    }
}
