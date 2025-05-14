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
    public class CrearAgencia : ICrearAgencia
    {
        IAgenciaRepository _repository;
        public CrearAgencia(IAgenciaRepository repository)
        {
            _repository = repository;
        }
        public AgenciaDTO Execute(AgenciaDTO agenciaDTO)
        {
            // Pasar agenciaDTO a agencia 
            Agencia agencia = agenciaDTO.ToAgencia();
            // Validar agencia
            agencia.Validar();
            // Agregar agencia al repositorio
            _repository.Add(agencia);
            AgenciaDTO nuevaAgenciaDTO = new AgenciaDTO(agencia);
            return nuevaAgenciaDTO;
        }
    }
}
