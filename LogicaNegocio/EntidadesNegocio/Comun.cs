using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Comun : Envio
    {
        public Agencia Agencia { get; set; }

        //CONSTRUCTOR
        public Comun(double numTracking, Usuario empleado, Usuario cliente, double peso, string estado, Agencia agencia, List<Seguimiento> seguimientos) : base(numTracking, empleado, cliente, peso, estado, seguimientos)
        {
            Agencia = agencia;
        }

        // METODO PARA FINALIZAR ENVIO
        public override void FinalizarEnvio()
        {
            Estado = "FINALIZADO";
        }
    }
}
