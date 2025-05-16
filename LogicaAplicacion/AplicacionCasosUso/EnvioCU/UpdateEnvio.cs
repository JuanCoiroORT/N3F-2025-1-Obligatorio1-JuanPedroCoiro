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
    public class UpdateEnvio : IUpdateEnvio
    {
        IEnvioRepository _repository;
        public UpdateEnvio(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public EnvioDTO Execute(int id, EnvioDTO envioDTO)
        {
            Envio envio;
            if(envioDTO is UrgenteDTO urgenteDTO)
            {
                envio = urgenteDTO.ToUrgente();
                envio.Id = id;
            }
            else if (envioDTO is ComunDTO comunDTO)
            {
                envio = comunDTO.ToComun();
                envio.Id = id;
                
            }
            else
            {
                throw new ArgumentException("Tipo de envio no reconocido.");
            }

            // Editar el envio
            _repository.Update(id, envio);
            //Pasarlo a DTO
            EnvioDTO envioEditadoDTO = new EnvioDTO(envio);

            return envioEditadoDTO;

        }
    }
}
