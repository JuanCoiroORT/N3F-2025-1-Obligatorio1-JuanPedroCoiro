using Compartido.DTOs;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class UsuariosController : Controller
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

        public IActionResult Index(string name)
        {
            // METODO ESTATICO DE CLASE STRING SI ES NULL RETORNA "" SINO NAME
            string nombreNoNulo = String.IsNullOrEmpty(name) ? "" : name;
            IEnumerable<UsuarioDTO> usuariosDTO = _usersByName.Execute(nombreNoNulo);
            ViewModelUsuariosIndex viewModel = new ViewModelUsuariosIndex(usuariosDTO);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsuarioDTO usuarioDTO)
        {
            try
            {
                _crearUsuario.Execute(usuarioDTO);
                return RedirectToAction(nameof(Index), new {name = ""});
            }
            catch(UsuarioException ex) 
            {
                ViewBag.Message = ex.Message;
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            UsuarioDTO usuarioDTO = _userById.Execute(id);
            return View(usuarioDTO);
        }
        [HttpPost]
        public IActionResult Edit(int id, UsuarioDTO usuarioDTO)
        {
            _updateUsuario.Execute(id, usuarioDTO);
            return RedirectToAction(nameof(Index), new { usuarioDTO});
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            UsuarioDTO usuarioDTO = _userById.Execute(id);
            return View(usuarioDTO);
        }

        [HttpPost]
        public IActionResult Delete(int id, UsuarioDTO usuarioDTO)
        {
            _deleteUsuario.Execute(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
