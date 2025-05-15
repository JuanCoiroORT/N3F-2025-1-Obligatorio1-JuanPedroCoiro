using Compartido.DTOs;
using LogicaAplicacion.Interfaces.ComunInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MVC.Models;
using LogicaAplicacion.Interfaces.UrgenteInterfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.ExcepcionesEntidades;
using System.Security.Claims;
using LogicaAplicacion.Interfaces.AgenciaInterfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Controllers
{
    public class EnviosController : Controller
    {
        private IGetEnviosComunes _getEnviosComunes;
        private IGetEnviosUrgentes _getEnviosUrgentes;
        private ICrearEnvioComun _crearEnvioComun;
        private ICrearEnvioUrgente _crearEnvioUrgente;
        private IGetUserByEmail _getUserByEmail;
        private IGetUserById _getUserById;
        private IGetAgencias _getAgencias;
        private IGetClientes _getClientes;
        private IGetAgenciaById _getAgenciaById;

        public EnviosController(IGetEnviosComunes getEnviosComunes, IGetEnviosUrgentes getEnviosUrgentes,
            ICrearEnvioUrgente crearEnvioUrgente, ICrearEnvioComun crearEnvioComun, IGetUserByEmail getUsersByEmail,
            IGetUserById getUserById, IGetAgencias getAgencias, IGetClientes getClientes, IGetAgenciaById getAgenciaById)
        {   
            _getEnviosComunes = getEnviosComunes;
            _getEnviosUrgentes = getEnviosUrgentes;
            _crearEnvioComun = crearEnvioComun;
            _crearEnvioUrgente = crearEnvioUrgente;
            _getUserByEmail = getUsersByEmail;
            _getUserById = getUserById;
            _getAgencias = getAgencias;
            _getClientes = getClientes;
            _getAgenciaById = getAgenciaById;
        }
        public IActionResult Index()
        {
            IEnumerable <ComunDTO> comunDTOs = _getEnviosComunes.Execute();
            IEnumerable<UrgenteDTO> urgenteDTOs = _getEnviosUrgentes.Execute();
            ViewModelEnviosIndex envios = new ViewModelEnviosIndex(comunDTOs, urgenteDTOs);
            return View(envios);
        }

        [HttpGet]
        public IActionResult CreateUrgente()
        {
            // Traer a los clientes para select de email
            IEnumerable<UsuarioDTO> clientesDTO = _getClientes.Execute();
            var clientesSelect = clientesDTO.Select(c => new SelectListItem
            {
                Text = c.Email,
                Value = c.Id.ToString()
            }).ToList();

            //Armar viewmodel
            var vm = new ViewModelEnvioUrgente
            {
                urgenteDTO = new UrgenteDTO(),
                Clientes = clientesSelect
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult CreateUrgente(ViewModelEnvioUrgente vm)
        {
            try
            {
                UrgenteDTO urgenteDTO = vm.urgenteDTO;

                // Buscar el empleado que dio de alta el envio, es decir el que esta logueado
                int empleadoId = (int)HttpContext.Session.GetInt32("IdLogueado");
                UsuarioDTO empleadoDTO = _getUserById.Execute(empleadoId);

                // Buscar cliente por id
                int clienteId = urgenteDTO.ClienteId;
                UsuarioDTO clienteDTO = _getUserById.Execute(clienteId);

                // Asignar propiedades
                urgenteDTO.ClienteId = clienteDTO.Id;
                urgenteDTO.EmpleadoId = empleadoDTO.Id;
                urgenteDTO.Estado = "EN_PROCESO";

                // Setear los objetos del envio
                urgenteDTO.Cliente = new Usuario { Id = clienteDTO.Id };
                urgenteDTO.Empleado = new Usuario { Id = empleadoDTO.Id };

                // Crear el envio
                _crearEnvioUrgente.Execute(urgenteDTO);

                //Rederigir al index
                return RedirectToAction("Index");
            }
            catch(EnvioException ex) 
            {
                //Mensaje con el error
                ViewBag.Message = ex.Message;

                // Volver a cargar el vm por si hay error al enviar formulario
                vm.Clientes = _getClientes.Execute().Select(c => new SelectListItem
                {
                    Text = c.Email,
                    Value = c.Id.ToString()
                }).ToList();

                return View(vm);
            }
        }

        [HttpGet]
        public IActionResult CreateComun()
        {
            //Traer agencias para select
            IEnumerable<AgenciaDTO> agenciasDTOs = _getAgencias.Execute();

            var agenciasSelect = agenciasDTOs.Select(a => new SelectListItem
            {
                Text = a.Nombre,       
                Value = a.Id.ToString() 
            }).ToList();

            // Traer a los clientes para select de email
            IEnumerable<UsuarioDTO> clientesDTO = _getClientes.Execute();
            var clientesSelect = clientesDTO.Select(c => new SelectListItem
            {
                Text = c.Email,
                Value = c.Id.ToString()
            }).ToList();

            //Armar viewmodel
            var vm = new ViewModelEnvioComun
            {
                comunDTO = new ComunDTO(),
                Agencias = agenciasSelect,
                Clientes = clientesSelect
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult CreateComun(ViewModelEnvioComun vm)
        {
            try
            {
                ComunDTO comunDTO = vm.comunDTO;

                // Buscar el empleado que dio de alta el envio, es decir el que esta logueado
                int empleadoId = (int)HttpContext.Session.GetInt32("IdLogueado");
                UsuarioDTO empleadoDTO = _getUserById.Execute(empleadoId);

                // Buscar cliente por id
                int clienteId = comunDTO.ClienteId;
                UsuarioDTO clienteDTO = _getUserById.Execute(clienteId);

                // Buscar agencia por id
                int agenciaId = comunDTO.AgenciaId;
                AgenciaDTO agenciaDTO = _getAgenciaById.Execute(agenciaId);

                // Asignar propiedades
                comunDTO.ClienteId = clienteDTO.Id;
                comunDTO.EmpleadoId = empleadoDTO.Id;
                comunDTO.AgenciaId = agenciaDTO.Id;
                comunDTO.Estado = "EN_PROCESO";

                // Setear los objetos del envio
                comunDTO.Cliente = new Usuario { Id = clienteDTO.Id };
                comunDTO.Empleado = new Usuario { Id = empleadoDTO.Id };
                
                // Crear el envio
                _crearEnvioComun.Execute(comunDTO);

                // Redirigir al index
                return RedirectToAction("Index");
            }
            catch (EnvioException ex)
            {
                //Mensaje con el error
                ViewBag.Message = ex.Message;

                // Volver a cargar la info en caso de error en el envio
                vm.Agencias = _getAgencias.Execute().Select(a => new SelectListItem
                {
                    Text = a.Nombre,
                    Value = a.Id.ToString()
                }).ToList();

                vm.Clientes = _getClientes.Execute().Select(c => new SelectListItem
                {
                    Text = c.Email,
                    Value = c.Id.ToString()
                }).ToList();

                return View(vm);
            }
        }
    }
}
