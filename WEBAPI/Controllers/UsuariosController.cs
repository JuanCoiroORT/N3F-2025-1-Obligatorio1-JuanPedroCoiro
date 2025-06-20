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

        public UsuariosController(IUpdateUsuario updateUsuario, IGetUserById getUserById)
        {
            _updateUsuario = updateUsuario;
            _getUserById = getUserById;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                _updateUsuario.Execute(id, usuarioDTO);
                return Ok(); // 200
            }
            catch(ElementoInvalidoException ex)
            {
                return BadRequest(ex.Message); // 400
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message); //404
            }
        }
    }
}
