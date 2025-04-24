using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Urgente : Envio
    {
        public int DireccionEsp { get; set; }
        public bool Eficiente { get; set; }
        
        //CONSTRUCTOR
        public Urgente(double numTracking, Usuario empleado, Usuario cliente, double peso, string estado, int direccionEsp, bool eficiente, List<Seguimiento> seguimientos) : base(numTracking, empleado, cliente, peso, estado, seguimientos)
        {
            DireccionEsp = direccionEsp;
            Eficiente = eficiente;
        }

        // METODO PARA FINALIZAR ENVIO
        public override void FinalizarEnvio()
        {
            Estado = "FINALIZADO";
            // CALCULAR TIEMPO DE LA ENTREGA
        }
    }
}
