using Compartido.DTOs;
using LogicaAplicacion.AplicacionCasosUso.UsuarioCU;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {

        private ICrearUsuario _crearUsuario;
        private IUpdateUsuario _updateUsuario;
        private IDeleteUsuario _deleteUsuario;
        private IGetUserById _userById;
        private IGetUsersByName _usersByName;

        public UsuariosController(ICrearUsuario crearUsuario,
                                    IGetUserById userById,
                                    IGetUsersByName usersByName,
                                    IDeleteUsuario deleteUsuario,
                                    IUpdateUsuario updateUsuario)
        {
            _crearUsuario = crearUsuario;
            _userById = userById;
            _usersByName = usersByName;
            _deleteUsuario = deleteUsuario;
            _updateUsuario = updateUsuario;
        }


        [HttpGet]
        public IActionResult  Get()
        {
            IEnumerable<UsuarioDTO> usuariosDTO = _usersByName.Execute("");
            return Ok(usuariosDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            UsuarioDTO usuarioDTO = _userById.Execute(id);
            if (usuarioDTO == null)
                return NotFound();

            return Ok(usuarioDTO);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                UsuarioDTO nuevoUsuarioDTO = _crearUsuario.Execute(usuarioDTO);

                // 200 usuario creado
                return Ok(nuevoUsuarioDTO);
            }
            catch (UsuarioException ex)
            {
                // 400 Bad Request
                return BadRequest(new { error = ex.Message});
            }
           
        }
    }
}
