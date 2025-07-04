﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public abstract class Envio
    {
        public int Id { get; set; }
        private static int s_ultId;
        public string NumTracking { get; set; }
        public Usuario Empleado { get; set; }
        public int EmpleadoId { get; set; }
        public Usuario Cliente { get; set; }
        public int ClienteId { get; set; }
        public double Peso { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();

        //CONSTRUCTOR
        public Envio(string numTracking, Usuario empleado, Usuario cliente, double peso, List<Seguimiento> seguimientos)
        {
            NumTracking = numTracking;
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = "EN_PROCESO";
            Seguimientos = seguimientos;
            FechaCreacion = DateTime.Now;
        }
        public Envio() { }
        
    }
}
