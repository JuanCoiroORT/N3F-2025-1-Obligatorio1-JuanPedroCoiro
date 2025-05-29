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
        public IActionResult Get([FromBody] string name = "")
        {
            IEnumerable<UsuarioDTO> usuariosDTO = _usersByName.Execute(name);
            return Ok(usuariosDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                UsuarioDTO usuarioDTO = _userById.Execute(id);
                return Ok(usuarioDTO);

            }
            catch(UsuarioException ex)
            {
                return NotFound(ex.Message);
            }
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


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                UsuarioDTO usuarioDTOUpd = _updateUsuario.Execute(id, usuarioDTO);
                return Ok(usuarioDTO);

            }
            catch (UsuarioException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
