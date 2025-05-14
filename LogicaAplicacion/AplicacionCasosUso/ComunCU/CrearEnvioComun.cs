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
    public class CrearEnvioComun : ICrearEnvioComun
    {
        IComunRepository _repository;

        public CrearEnvioComun(IComunRepository repository)
        {
            _repository = repository;
        }

        public ComunDTO Execute(ComunDTO comunDTO)
        {
            // Pasar DTO a comun
            Comun comun = comunDTO.ToComun();
            // Validar
            comun.Validar();
            // Agregar envio comun a repositorio
            _repository.Add(comun);
            ComunDTO nuevoComunDTO = new ComunDTO(comun);
            return nuevoComunDTO;
        }
    }
}
