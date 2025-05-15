using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs
{
    public class ComunDTO
    {
        public int Id { get; set; }
        public double Peso { get; set; }
        public double NumTracking { get; set; }
        public Usuario Cliente { get; set; }
        public Usuario Empleado { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public string Estado { get; set; }
        public List<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
        public Agencia Agencia { get; set; }
        public int AgenciaId { get; set; }  

        public ComunDTO(Comun envioComun) 
        {
            Id = envioComun.Id;
            Peso = envioComun.Peso;
            NumTracking = envioComun.NumTracking;
            Cliente = envioComun.Cliente;
            Empleado = envioComun.Empleado;
            ClienteId = envioComun.ClienteId;
            EmpleadoId = envioComun.EmpleadoId;
            Estado = envioComun.Estado;
            Seguimientos = envioComun.Seguimientos;
            Agencia = envioComun.Agencia;
            AgenciaId = envioComun.AgenciaId;
        }

        public ComunDTO() { }

        public Comun ToComun()
        {
            Comun envioComun = new Comun()
            {
                Id = this.Id,
                Peso = this.Peso,
                NumTracking = this.NumTracking,
                EmpleadoId = this.EmpleadoId,
                ClienteId = this.ClienteId,
                Estado = this.Estado,
                Seguimientos = this.Seguimientos,
                Agencia = this.Agencia,
                AgenciaId = this.AgenciaId,
            };
            return envioComun;
        }
    }
}
