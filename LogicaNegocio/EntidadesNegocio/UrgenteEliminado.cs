using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class UrgenteEliminado : EnvioEliminado
    {
        public int DireccionPostal { get; set; }
        public bool Eficiente { get; set; }

        public UrgenteEliminado() { }
        public UrgenteEliminado(Urgente envio)
        {
            DireccionPostal = envio.DireccionPostal;
            Eficiente = envio.Eficiente;
        }
    }
}
