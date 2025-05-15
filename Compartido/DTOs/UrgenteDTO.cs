using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs
{
    public class UrgenteDTO
    {
        public int Id { get; set; }
        public double Peso { get; set; }
        public double NumTracking { get; set; }
        public Usuario Cliente { get; set; }
        public Usuario Empleado { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public string Estado {  get; set; }
        public List<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
        public int DireccionPostal { get; set; }
        public bool Eficiente { get; set; }

        public UrgenteDTO(Urgente envioUrgente)
        {
            Id = envioUrgente.Id;
            Peso = envioUrgente.Peso;
            NumTracking = envioUrgente.NumTracking;
            Cliente = envioUrgente.Cliente;
            Empleado = envioUrgente.Empleado;
            EmpleadoId = envioUrgente.EmpleadoId;
            ClienteId = envioUrgente.ClienteId;
            Estado = envioUrgente.Estado;
            Seguimientos = envioUrgente.Seguimientos;
            DireccionPostal = envioUrgente.DireccionPostal;
            Eficiente = envioUrgente.Eficiente;
        }

        public UrgenteDTO() { }

        public Urgente ToUrgente()
        {
            Urgente envioUrgente = new Urgente()
            {
                Id = this.Id,
                Peso = this.Peso,
                NumTracking = this.NumTracking,
                EmpleadoId = this.EmpleadoId,
                ClienteId = this.ClienteId,
                Estado = this.Estado,
                Seguimientos = this.Seguimientos,
                DireccionPostal = this.DireccionPostal,
                Eficiente = this.Eficiente,
            };
            return envioUrgente;
        }
    }
}
