using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IEnvioRepository
    {
        Urgente AddUrgente(Urgente urgente);
        Comun AddComun(Comun comun);
        IEnumerable<Comun> GetAllComunes();
        IEnumerable<Urgente> GetAllUrgentes();
        Comun GetComunById(int id);
        Urgente GetUrgenteById(int id);
        Envio Update(int id, Envio envio);  
        void DeleteUrgente(int id);
        void DeleteComun(int id);
        bool ExisteNumTracking(string numTracking);
        Envio GetByNumTracking(string numTracking);

    }
}
