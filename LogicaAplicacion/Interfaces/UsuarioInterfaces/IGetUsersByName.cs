using Compartido.DTOs;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Interfaces.UsuarioInterfaces
{
    public interface IGetUsersByName
    {
        IEnumerable<UsuarioDTO> Execute(string name);
    }
}
