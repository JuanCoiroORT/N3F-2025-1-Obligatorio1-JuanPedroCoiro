using Compartido.DTOs;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Interfaces.EnvioInterfaces
{
    public interface IGetByFechas
    {
        IEnumerable<EnvioDTO> Execute(DateTime? fch1, DateTime? fch2, string? estado);
    }
}
