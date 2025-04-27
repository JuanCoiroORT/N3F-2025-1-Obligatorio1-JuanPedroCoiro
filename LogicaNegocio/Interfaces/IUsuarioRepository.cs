using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Add(Usuario usuario);
        Usuario Update(int id, Usuario usuario);
        Usuario Delete(int id);
        Usuario GetById(int id);
        IEnumerable<Usuario> GetAll();
        IEnumerable<Usuario> GetByName(string name);
    }
}
