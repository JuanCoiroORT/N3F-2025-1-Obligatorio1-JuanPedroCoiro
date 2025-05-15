using LogicaAccesoDatos.Contexto;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class UrgenteRepository : IUrgenteRepository
    {
        private readonly AppDbContexto _contexto;

        public UrgenteRepository(AppDbContexto contexto)
        {
            _contexto = contexto;
        }
        public Urgente Add(Urgente urgente)
        {
            _contexto.EnviosUrgentes.Add(urgente);
            _contexto.SaveChanges();
            return urgente;
        }

        public IEnumerable<Urgente> GetAll()
        {
            return _contexto.EnviosUrgentes.ToList();
        }

        public Urgente Update(Urgente urgente)
        {
            throw new NotImplementedException();
        }
    }
}
