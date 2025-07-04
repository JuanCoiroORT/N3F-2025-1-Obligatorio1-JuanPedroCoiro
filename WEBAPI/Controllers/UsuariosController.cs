using Compartido.DTOs;
using Excepciones;
using LogicaAplicacion.AplicacionCasosUso.UsuarioCU;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {


        private IUpdateUsuario _updateUsuario;
        private IGetUserById _getUserById;
        private ICambioPassword _cambioPassword;

        public UsuariosController(IUpdateUsuario updateUsuario, IGetUserById getUserById, ICambioPassword cambioPassword)
        {
            _updateUsuario = updateUsuario;
            _getUserById = getUserById;
            _cambioPassword = cambioPassword;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var usuarioDTO = _getUserById.Execute(id);
                if (usuarioDTO == null)
                    return NotFound("Usuario no encontrado.");

                return Ok(usuarioDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost("cambiarPassword")]
        public IActionResult CambiarPassword([FromBody] CambioPasswordDTO dto)
        {
            try
            {
                bool exito = _cambioPassword.Execute(dto.Id, dto.PasswordActual, dto.PasswordNueva);

                if (!exito)
                {
                    return BadRequest("La contraseņa actual es incorrecta.");
                }

                return Ok("Contraseņa actualizada correctamente.");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ElementoInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

    }
}
