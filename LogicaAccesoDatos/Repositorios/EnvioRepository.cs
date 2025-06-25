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

        public IEnumerable<Envio> GetAllByClienteId(int id)
        {
            return _contexto.Envios
                .Where(e => e.ClienteId == id)
                .Include(e => e.Seguimientos) .ToList();
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
            //Encontrar el envio urgente
            Urgente urgente =  _contexto.Envios.OfType<Urgente>().FirstOrDefault(e => e.Id == id);

            // Crear el regitro eliminado
            UrgenteEliminado urgenteEliminado = new UrgenteEliminado(urgente);

            // Camiar estado
            urgenteEliminado.Estado = "FINALIZADO";

            // Calcular si fue eficiente y asignar
            TimeSpan duracion = urgenteEliminado.FechaCreacion - urgenteEliminado.FechaEliminacion;
            if ( duracion.Days < 1)
            {
                urgenteEliminado.Eficiente = true;
            }

            // Agregar a la tabla auditoria
            _contexto.EnviosEliminados.Add(urgenteEliminado);

            // Eliminar de la tabla principal
            _contexto.Envios.Remove(urgente);

            // Guardar cambios
            _contexto.SaveChanges();
        }

        public void DeleteComun(int id)
        {
            //Encontrar el envio comun
            Comun comun = _contexto.Envios.OfType<Comun>().FirstOrDefault(e => e.Id == id);

            // Crear el registro elimnado
            ComunEliminado comunEliminado = new ComunEliminado(comun);

            // Agregar a la tabla auditoria
            _contexto.EnviosEliminados.Add(comunEliminado);

            //Eliminar de la tabla principal
            _contexto.Envios.Remove(comun);

            //Guardar cambios
            _contexto.SaveChanges();
        }

        public bool ExisteNumTracking(string numTracking)
        {
            return _contexto.Envios.Any(e => e.NumTracking == numTracking);
        }

        public Envio GetByNumTracking(string numTracking)
        {
            return _contexto.Set<Envio>().FirstOrDefault(e => e.NumTracking == numTracking);
        }

        public IEnumerable<Seguimiento> GetSeguimientosById(int id)
        {
            return _contexto.Envios
                .Where(e => e.Id == id)
                .SelectMany(e => e.Seguimientos);
        }

        public IEnumerable<Envio> GetByFechas(DateTime? fch1, DateTime? fch2, string? estado)
        {
            return _contexto.Envios
                .Where(e => e.FechaCreacion >= fch1 && e.FechaCreacion <= fch2 && e.Estado == estado)
                .OrderBy(e => e.NumTracking);
        }
    }
}
