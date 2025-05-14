using LogicaAccesoDatos.Contexto;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class ComunRepository : IComunRepository
    {
        private readonly AppDbContexto _contexto;

        public ComunRepository(AppDbContexto contexto)
        {
            _contexto = contexto;
        }
        public Comun Add(Comun envioComun)
        {
            _contexto.EnviosComunes.Add(envioComun);
            _contexto.SaveChanges();
            return envioComun;
        }

        public IEnumerable<Comun> GetAll()
        {
            return _contexto.EnviosComunes.ToList();
        }

        public Comun Update(Comun envioComun)
        {
            throw new NotImplementedException();
        }
    }
}
