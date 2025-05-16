using Compartido.DTOs;
using LogicaAplicacion.Interfaces.AgenciaInterfaces;
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
    public class CrearUrgente : ICrearUrgente
    {
        IEnvioRepository _repository;
        public CrearUrgente(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public UrgenteDTO Execute(UrgenteDTO urgenteDTO)
        {
            // Pasa dto a urgente
            Urgente urgente = urgenteDTO.ToUrgente();

            // validar
            urgente.Validar();

            // agregar usuario a repositorio
            _repository.AddUrgente(urgente);

            UrgenteDTO nuevoUrgenteDTO = new UrgenteDTO(urgente);

            return nuevoUrgenteDTO;
        }
    }
}
