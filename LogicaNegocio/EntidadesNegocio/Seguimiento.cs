﻿using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Seguimiento
    {
        public int Id { get; set; }
        private static int s_ultId;
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Empleado { get; set; }
        public int EmpleadoId {  get; set; }

        public int EnvioId { get; set; }

        public Seguimiento(string comentario, Usuario empleado, int envioId)
        {
            Comentario = comentario;
            Empleado = empleado;
            Fecha = DateTime.Now;
            EmpleadoId = empleado.Id;
            EnvioId = envioId;
            Validar();
        }

        public Seguimiento() { }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Comentario))
            {
                throw new SeguimientoException("ingrese un comentario.");
            }
        }
    }
}
