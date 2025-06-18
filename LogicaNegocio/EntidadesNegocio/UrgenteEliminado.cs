using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class UrgenteEliminado : EnvioEliminado
    {
        public DateTime FechaCreacion {  get; set; }
        public int DireccionPostal { get; set; }
        public bool Eficiente { get; set; }

        public UrgenteEliminado() { }
        public UrgenteEliminado(Urgente envio) : base()//TODO base
        {

            FechaCreacion = envio.FechaCreacion;
            DireccionPostal = envio.DireccionPostal;
            Eficiente = envio.Eficiente;
        }
    }
}
