using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class EnvioEliminado
    {
        public int Id { get; set; }
        public double NumTracking { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public double Peso { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEliminacion { get; set; }
        public string Tipo {  get; set; }

        public EnvioEliminado(Envio envio)
        {
            NumTracking = envio.NumTracking;
            EmpleadoId = envio.EmpleadoId;
            ClienteId = envio.ClienteId;
            Peso = envio.Peso;
            Estado = envio.Estado;
            FechaEliminacion = DateTime.Now;
            Tipo = envio is Urgente ? "Urgente" : "Comun";
        }

        public EnvioEliminado() { }
    }
}
