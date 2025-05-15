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
        public int DireccionPostal { get; set; }
        public bool Eficiente { get; set; }
        
        //CONSTRUCTOR
        public Urgente(double numTracking, Usuario empleado, Usuario cliente, double peso, string estado, int direccionPostal, List<Seguimiento> seguimientos) : base(numTracking, empleado, cliente, peso, seguimientos)
        {
            DireccionPostal = direccionPostal;
            Eficiente = false;
            Estado = string.IsNullOrEmpty(estado) ? "EN_PROCESO" : estado;
            Validar();
        }

        public void Validar()
        {
            if(DireccionPostal == 0)
            {
                throw new EnvioException("El codigo postal ingresado es incorrecto.");
            }
        }

        public Urgente() { }

        // METODO PARA FINALIZAR ENVIO
        public override void FinalizarEnvio()
        {
            Estado = "FINALIZADO";
            // CALCULAR TIEMPO DE LA ENTREGA
        }
    }
}
