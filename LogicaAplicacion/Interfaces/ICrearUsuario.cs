using Compartido.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Interfaces
{
    public interface ICrearUsuario
    {
        UsuarioDTO Execute(UsuarioDTO usuarioDTO);
    }
}
