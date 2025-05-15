using Compartido.DTOs;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Interfaces.AgenciaInterfaces
{
    public interface IGetAgencias
    {
        IEnumerable<AgenciaDTO> Execute();
    }
}
