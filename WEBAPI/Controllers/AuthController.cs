using Compartido.DTOs;
using LogicaAccesoDatos.Contexto;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.Servicios;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly AppDbContexto _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContexto context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
                return BadRequest("Debe ingresar email y contraseña.");

            var usuario = _context.Usuarios.FirstOrDefault(u =>
                u.Email.Valor == loginDto.Email && u.Password == loginDto.Password);

            if (usuario == null)
                return Unauthorized("Credenciales incorrectas.");

            var token = _tokenService.GenerarToken(usuario);

            var resultado = new LoginResultDTO
            {
                Token = token,
                Id = usuario.Id, 
                Rol = usuario.Rol
            };

            return Ok(resultado);
        }
    }
}
