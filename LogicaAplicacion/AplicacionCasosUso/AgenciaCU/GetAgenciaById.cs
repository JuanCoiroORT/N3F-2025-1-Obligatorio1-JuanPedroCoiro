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
    public class GetAgenciaById : IGetAgenciaById
    {
        IAgenciaRepository _repository;

        public GetAgenciaById(IAgenciaRepository repository)
        {
            _repository = repository;
        }

        public AgenciaDTO Execute(int id)
        {
            Agencia agencia = _repository.GetAgenciaById(id);
            return new AgenciaDTO(agencia);
        }
    }
}
