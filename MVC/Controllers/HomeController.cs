using Compartido.DTOs;
using LogicaAplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using LogicaNegocio.ValueObject;
using LogicaAccesoDatos.Contexto;
using LogicaNegocio.EntidadesNegocio;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContexto _context;

        public HomeController(AppDbContexto context)
        {
            _context = context;
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Login(string email, string password)
        {
            // VALIDACION USUARIO
            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Email.Valor == email && u.Password == password);
            if(usuario == null)
            {
                ViewBag.Message = "Credenciales incorrectas";
                return View();
            }
            // GUARDAR EL USUARIO
            HttpContext.Session.SetString("RolLogueado", usuario.Rol);
            HttpContext.Session.SetInt32("IdLogueado", usuario.Id);
            return RedirectToAction("Index");
        }
        
        public IActionResult Logout()
        {
            // ELIMINAR LA SESION
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
