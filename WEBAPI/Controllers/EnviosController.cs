using Compartido.DTOs;
using LogicaAplicacion.AplicacionCasosUso.UsuarioCU;
using LogicaAplicacion.Interfaces.EnvioInterfaces;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnviosController : ControllerBase
    {

        private IGetByNumTracking _getByNumTracking;

        public EnviosController(IGetByNumTracking getByNumTracking)
        {
            _getByNumTracking = getByNumTracking;
        }


        [HttpGet("{numTracking}")]
        public IActionResult GetByNumTracking(double numTracking)
        {
            EnvioDTO envioDTO = _getByNumTracking.Execute(numTracking);

            if(envioDTO == null)
            {
                return NotFound($"No se encontro un envio con el numero de tracking {numTracking}");
            }

            return Ok(envioDTO);
        }
    }
}
