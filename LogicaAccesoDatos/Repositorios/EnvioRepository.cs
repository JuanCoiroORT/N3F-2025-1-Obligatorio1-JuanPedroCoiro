using LogicaAccesoDatos.Contexto;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class EnvioRepository : IEnvioRepository
    {
        private readonly AppDbContexto _contexto;
        public EnvioRepository(AppDbContexto contexto)
        {
            _contexto = contexto;
        }

        public Urgente AddUrgente(Urgente urgente)
        {
            _contexto.Envios.Add(urgente);
            _contexto.SaveChanges();
            return urgente;
        }

        public Comun AddComun(Comun comun)
        {
            _contexto.Envios.Add(comun);
            _contexto.SaveChanges();
            return comun;
        }

        public IEnumerable<Comun> GetAllComunes()
        {
            return _contexto.Envios
                .OfType<Comun>()
                .Include(c => c.Agencia)
                .Include(c => c.Seguimientos)
                .ToList();
        }

        public IEnumerable<Urgente> GetAllUrgentes()
        {
            return _contexto.Envios
                .OfType<Urgente>()
                .Include(u => u.Seguimientos)
                .ToList();
        }

        public Comun GetComunById(int id)
        {
            return _contexto.Set<Comun>()
                .Include(c => c.Agencia)
                .FirstOrDefault(c => c.Id == id);
        }
        public Urgente GetUrgenteById(int id)
        {
            return _contexto.Set<Urgente>().FirstOrDefault(c => c.Id == id);
        }

        public Envio Update(int id, Envio envio)
        {
            try
            {
                // Buscar el envio en la tabla Envios
                Envio envioBuscado = null;

                if (envio is Comun envioComun)
                {
                    envioBuscado = _contexto.Envios
                        .OfType<Comun>()
                        .Include(c => c.Agencia)
                        .Include(c => c.Seguimientos)
                        .FirstOrDefault(c => c.Id == envioComun.Id);
                    if (envioBuscado == null)
                        throw new ArgumentException("Envio común no encontrado.");

                    // Actualizar propiedades específicas de Comun
                    Comun comunBuscado = (Comun)envioBuscado;

                    comunBuscado.Peso = envioComun.Peso;
                    comunBuscado.Estado = envioComun.Estado;
                    comunBuscado.EmpleadoId = envioComun.EmpleadoId;
                    comunBuscado.AgenciaId = envioComun.AgenciaId;
                    comunBuscado.ClienteId = envioComun.ClienteId;
                    comunBuscado.NumTracking = envioComun.NumTracking;

                    // Actualizar seguimientos nuevos
                    foreach (var seg in envioComun.Seguimientos)
                    {
                        if (!comunBuscado.Seguimientos.Any(s => s.Id == seg.Id))
                        {
                            comunBuscado.Seguimientos.Add(seg);
                        }
                    }
                }
                else if (envio is Urgente envioUrgente)
                {
                    envioBuscado = _contexto.Envios
                        .OfType<Urgente>()
                        .Include(u => u.Seguimientos)
                        .FirstOrDefault(u => u.Id == envioUrgente.Id);
                    if (envioBuscado == null)
                        throw new ArgumentException("Envio urgente no encontrado.");

                    // Actualizar propiedades específicas de Urgente
                    Urgente urgenteBuscado = (Urgente)envioBuscado;

                    urgenteBuscado.Peso = envioUrgente.Peso;
                    urgenteBuscado.Estado = envioUrgente.Estado;
                    urgenteBuscado.EmpleadoId = envioUrgente.EmpleadoId;
                    urgenteBuscado.ClienteId = envioUrgente.ClienteId;
                    urgenteBuscado.NumTracking = envioUrgente.NumTracking;
                    urgenteBuscado.DireccionPostal = envioUrgente.DireccionPostal;
                    urgenteBuscado.Eficiente = envioUrgente.Eficiente;

                    // Actualizar seguimientos nuevos
                    foreach (var seg in envioUrgente.Seguimientos)
                    {
                        if (!urgenteBuscado.Seguimientos.Any(s => s.Id == seg.Id))
                        {
                            urgenteBuscado.Seguimientos.Add(seg);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Tipo de envío no soportado.");
                }

                // Guardar cambios en la base
                _contexto.SaveChanges();

                return envioBuscado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el envío: " + ex.Message, ex);
            }
        }

        public void DeleteUrgente(int id)
        {
            Urgente urgente =  _contexto.Envios.OfType<Urgente>().FirstOrDefault(e => e.Id == id);
            _contexto.Envios.Remove(urgente);
            _contexto.SaveChanges();
        }

        public void DeleteComun(int id)
        {
            Comun comun = _contexto.Envios.OfType<Comun>().FirstOrDefault(e => e.Id == id);
            _contexto.Envios.Remove(comun);
            _contexto.SaveChanges();
        }
    }
}
