using Compartido.DTOs;
using LogicaAplicacion.AplicacionCasosUso.UsuarioCU;
using LogicaAplicacion.Interfaces.EnvioInterfaces;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnviosController : ControllerBase
    {

        private IGetByNumTracking _getByNumTracking;
        private IGetAllByClienteId _getByClienteId;
        private IGetSeguimientosById _getBySeguimientosById;
        private IGetByFechas _getByFechas;
        private IGetByComentario _getByComentario;
        public EnviosController(IGetByNumTracking getByNumTracking, IGetAllByClienteId getAllByClienteId,
            IGetSeguimientosById getBySeguimientosById, IGetByFechas getByFechas, IGetByComentario getByComentario)
        {
            _getByNumTracking = getByNumTracking;
            _getByClienteId = getAllByClienteId;
            _getBySeguimientosById = getBySeguimientosById;
            _getByFechas = getByFechas;
            _getByComentario = getByComentario;
        }


        [HttpGet("{numTracking}")]
        public IActionResult GetByNumTracking(string numTracking)
        {
            EnvioDTO envioDTO = _getByNumTracking.Execute(numTracking);

            if(envioDTO == null)
            {
                return NotFound($"No se encontro un envio con el numero de tracking {numTracking}");
            }

            return Ok(envioDTO);
        }

        [HttpGet("cliente/{id}")]
        public IActionResult GetEnviosCliente(int id)
        {
            IEnumerable<EnvioDTO> envioDTOs = _getByClienteId.Execute(id);
            if(envioDTOs == null)
            {
                return NotFound("No se encontraron envios para el cliente.");
            }
            return Ok(envioDTOs);
        }

        [HttpGet("{id}/seguimientos")]
        public IActionResult GetSeguimientos(int id)
        {
            IEnumerable<SeguimientoDTO> seguimientoDTOs = _getBySeguimientosById.Execute(id);
            if(seguimientoDTOs == null)
            {
                return NotFound("No se encontraron seguimientos.");
            }
            return Ok(seguimientoDTOs);
        }

        [HttpPost("filtrar")]
        public IActionResult GetByFechas([FromBody] FiltroEnvioDTO filtro)
        {
            IEnumerable<EnvioDTO> enviosDTO = _getByFechas.Execute(filtro.FechaInicio, filtro.FechaFin, filtro.Estado);
            if(enviosDTO == null)
            {
                return NotFound("No se encontraron envios con ese filtro.");
            }
            return Ok(enviosDTO);
        }

        [HttpPost("cliente/{idCliente}/buscarPorComentario")]
        public IActionResult GetByComentario(int idCliente, [FromBody] string comentario)
        {
            IEnumerable<EnvioDTO> enviosDTO = _getByComentario.Execute(idCliente, comentario);
            if(enviosDTO == null)
            {
                return NotFound("No se encontraron envios con ese comentario.");
            }
            return Ok(enviosDTO);
        }
    }
}
