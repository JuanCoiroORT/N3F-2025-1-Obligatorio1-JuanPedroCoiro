using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IAgenciaRepository
    {
        Agencia Add(Agencia agencia);
        IEnumerable<Agencia> GetAll();

        Agencia GetAgenciaById(int id);
    }
}
