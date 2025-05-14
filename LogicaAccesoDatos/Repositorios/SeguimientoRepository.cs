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
    public class SeguimientoRepository : ISeguimientoRepository
    {
        private readonly AppDbContexto _contexto;

        public SeguimientoRepository(AppDbContexto contexto)
        {
            _contexto = contexto;
        }

        public Seguimiento Add(Seguimiento s)
        {
            _contexto.Seguimientos.Add(s);
            _contexto.SaveChanges();
            return s;
        }
    }
}
