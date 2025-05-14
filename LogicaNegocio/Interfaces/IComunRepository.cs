using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IComunRepository
    {
        Comun Add(Comun envioComun);
        Comun Update(Comun envioComun);
        IEnumerable<Comun> GetAll();
    }
}
