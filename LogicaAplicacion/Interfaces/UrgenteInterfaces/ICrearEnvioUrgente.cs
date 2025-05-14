using Compartido.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Interfaces.UrgenteInterfaces
{
    public interface ICrearEnvioUrgente
    {
        UrgenteDTO Execute(UrgenteDTO urgenteDTO);
    }
}
