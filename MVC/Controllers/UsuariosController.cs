﻿using Compartido.DTOs;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.EntidadesNegocio;
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
            if(HttpContext.Session.GetInt32("IdLogueado") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            string nombreNoNulo = String.IsNullOrEmpty(name) ? "" : name;
            IEnumerable<UsuarioDTO> usuariosDTO = _usersByName.Execute(nombreNoNulo);
            ViewModelUsuariosIndex viewModel = new ViewModelUsuariosIndex(usuariosDTO);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("IdLogueado") == null)
            {
                return RedirectToAction("Login", "Home");
            }
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
            if (HttpContext.Session.GetInt32("IdLogueado") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            UsuarioDTO usuarioDTO = _userById.Execute(id);
            return View(usuarioDTO);
        }
        [HttpPost]
        public IActionResult Edit(int id, UsuarioDTO usuarioDTO)
        {
            try
            {
                _updateUsuario.Execute(id, usuarioDTO);
                return RedirectToAction(nameof(Index), new { usuarioDTO });
            }
            catch(UsuarioException ex)
            {
                ViewBag.Message = ex.Message;

                UsuarioDTO mismoUsuarioDTO = _userById.Execute(id);
                return View(mismoUsuarioDTO);
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("IdLogueado") == null)
            {
                return RedirectToAction("Login", "Home");
            }
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
