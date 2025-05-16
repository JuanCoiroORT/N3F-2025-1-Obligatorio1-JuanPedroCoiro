using LogicaNegocio.ExcepcionesEntidades;
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
        public int AgenciaId { get; set; }

        //CONSTRUCTOR
        public Comun(double numTracking, Usuario empleado, Usuario cliente, double peso, string estado, Agencia agencia, List<Seguimiento> seguimientos) : base(numTracking, empleado, cliente, peso, seguimientos)
        {
            Agencia = agencia;
            Validar();
            AgenciaId = Agencia.Id;
        }

        public Comun() { }

        public void Validar()
        {
            if(Peso <= 0)
            {
                throw new EnvioException("El peso del envio debe ser mayor a 0.");
            }
        }

        // METODO PARA FINALIZAR ENVIO
        public override void FinalizarEnvio()
        {
            Estado = "FINALIZADO";
        }
    }
}
