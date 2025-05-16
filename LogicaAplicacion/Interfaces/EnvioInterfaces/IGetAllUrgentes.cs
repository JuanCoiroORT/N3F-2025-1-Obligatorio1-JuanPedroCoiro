using Compartido.DTOs;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Interfaces.EnvioInterfaces
{
    public interface IGetAllUrgentes
    {
        IEnumerable<UrgenteDTO> Execute();
    }
}
