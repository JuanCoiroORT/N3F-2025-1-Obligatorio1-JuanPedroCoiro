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
    public class CrearEnvioUrgente : ICrearEnvioUrgente
    {
        IUrgenteRepository _repository;

        public CrearEnvioUrgente(IUrgenteRepository repository)
        {
            _repository = repository;
        }

        public UrgenteDTO Execute(UrgenteDTO urgenteDTO)
        {
            // Pasar DTO a urgente
            Urgente urgente = urgenteDTO.ToUrgente();
            // Validar
            urgente.Validar();
            // Agregar envio comun a repositorio
            _repository.Add(urgente);
            UrgenteDTO nuevoUrgenteDTO = new UrgenteDTO(urgente);
            return nuevoUrgenteDTO;
        }
    }
}
