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
            try
            {
                var envioDTO = _getByNumTracking.Execute(numTracking);
                if (envioDTO == null)
                    return NotFound($"No se encontró un envío con el número de tracking {numTracking}.");

                return Ok(envioDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("cliente/{id}")]
        public IActionResult GetEnviosCliente(int id)
        {
            try
            {
                var envios = _getByClienteId.Execute(id);
                if (envios == null || !envios.Any())
                    return NotFound("No se encontraron envíos para el cliente.");

                return Ok(envios);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id}/seguimientos")]
        public IActionResult GetSeguimientos(int id)
        {
            try
            {
                var seguimientos = _getBySeguimientosById.Execute(id);
                if (seguimientos == null || !seguimientos.Any())
                    return NotFound("No se encontraron seguimientos.");

                return Ok(seguimientos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost("filtrar")]
        public IActionResult GetByFechas([FromBody] FiltroEnvioDTO filtro)
        {
            try
            {
                var envios = _getByFechas.Execute(filtro.FechaInicio, filtro.FechaFin, filtro.Estado);
                if (envios == null || !envios.Any())
                    return NotFound("No se encontraron envíos con ese filtro.");

                return Ok(envios);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost("cliente/{idCliente}/buscarPorComentario")]
        public IActionResult GetByComentario(int idCliente, [FromBody] string comentario)
        {
            try
            {
                var envios = _getByComentario.Execute(idCliente, comentario);
                if (envios == null || !envios.Any())
                    return NotFound("No se encontraron envíos con ese comentario.");

                return Ok(envios);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
