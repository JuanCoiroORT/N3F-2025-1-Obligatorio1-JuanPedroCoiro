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
    public class CrearComun : ICrearComun
    {
        IEnvioRepository _repository;

        public CrearComun(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public ComunDTO Execute(ComunDTO comunDTO)
        {
            // PASA DTO A comun
            Comun comun = comunDTO.ToComun();
            // valida comun
            comun.Validar();
            // AGREGA USUARIO A REPOSITORIO
            _repository.AddComun(comun);
            ComunDTO nuevoComunDTO = new ComunDTO(comun);
            return nuevoComunDTO;
        }
    }
}
