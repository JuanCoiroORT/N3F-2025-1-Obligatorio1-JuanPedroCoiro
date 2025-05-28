using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class ComunEliminado : EnvioEliminado
    {
        public int AgenciaId { get; set; }

        public ComunEliminado() { }
        public ComunEliminado(Comun envio) : base(envio)
        {
            AgenciaId = envio.AgenciaId;
        }
    }
}
