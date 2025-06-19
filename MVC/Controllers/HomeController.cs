using Compartido.DTOs;
using LogicaAplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using LogicaNegocio.ValueObject;
using LogicaAccesoDatos.Contexto;
using LogicaNegocio.EntidadesNegocio;

using WEBAPI.Servicios;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContexto _context;
        private readonly TokenService _tokenService;

        public HomeController(AppDbContexto context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public IActionResult Index()
        {
            string rolLogueado = HttpContext.Session.GetString("RolLogueado");
            ViewBag.Rol = rolLogueado;
            
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Contrasenia))
                return BadRequest("Debe ingresar email y contraseña.");

            var usuario = _context.Usuarios.FirstOrDefault(u =>
                u.Email.Valor == loginDto.Email && u.Password == loginDto.Contrasenia);

            if (usuario == null)
                return Unauthorized("Credenciales incorrectas.");

            var token = _tokenService.GenerarToken(usuario);

            var resultado = new LoginResultDTO
            {
                Token = token,
                Nombre = usuario.Nombre,
                Email = usuario.Email.Valor
            };

            return Ok(resultado);
        }

        public IActionResult Logout()
        {
            // ELIMINAR LA SESION
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
