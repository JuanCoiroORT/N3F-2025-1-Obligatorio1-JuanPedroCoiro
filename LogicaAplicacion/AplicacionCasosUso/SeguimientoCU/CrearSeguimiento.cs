using Compartido.DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.AplicacionCasosUso.SeguimientoCU
{
    public class CrearSeguimiento
    {
        ISeguimientoRepository _repository;

        public CrearSeguimiento(ISeguimientoRepository repository)
        {
            _repository = repository;
        }

        public SeguimientoDTO Execute(SeguimientoDTO seguimientoDTO)
        {
            // Pasar DTO a seguimiento
            Seguimiento s = seguimientoDTO.ToSeguimiento();
            // Validar
            s.Validar();
            // Agregar seguimento a repositorio
            _repository.Add(s);
            SeguimientoDTO sDTO = new SeguimientoDTO();
            return sDTO;
        }

    }
}
