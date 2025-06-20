using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Urgente : Envio
    {
        public DateTime FechaCreacion { get; set; } 
        public int DireccionPostal { get; set; }
        public bool Eficiente { get; set; }
        
        //CONSTRUCTOR
        public Urgente(string numTracking, Usuario empleado, Usuario cliente, double peso, string estado, int direccionPostal, List<Seguimiento> seguimientos) : base(numTracking, empleado, cliente, peso, seguimientos)
        {
            DireccionPostal = direccionPostal;
            FechaCreacion = DateTime.Now;
            Eficiente = false;
            Estado = string.IsNullOrEmpty(estado) ? "EN_PROCESO" : estado;
            Validar();
        }

        public void Validar()
        {
            if(DireccionPostal <= 0)
            {
                throw new EnvioException("El codigo postal ingresado es incorrecto.");
            }
            if(Peso <= 0)
            {
                throw new EnvioException("El peso del envio debe ser mayor a 0.");
            }
        }

        public Urgente() { }

        
    }
}
