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
    public class AgenciaRepository : IAgenciaRepository
    {
        private readonly AppDbContexto _contexto;

        public AgenciaRepository(AppDbContexto contexto)
        {
            _contexto = contexto;
        }
        public Agencia Add(Agencia agencia)
        {
            _contexto.Agencias.Add(agencia);
            _contexto.SaveChanges();
            return agencia;
        }

        public IEnumerable<Agencia> GetAll()
        {
            return _contexto.Agencias.ToList();
        }
    }
}
