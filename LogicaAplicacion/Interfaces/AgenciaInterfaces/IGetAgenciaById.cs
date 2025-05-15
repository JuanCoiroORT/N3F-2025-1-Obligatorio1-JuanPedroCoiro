using Compartido.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Interfaces.AgenciaInterfaces
{
    public interface IGetAgenciaById
    {
        AgenciaDTO Execute(int id);
    }
}
