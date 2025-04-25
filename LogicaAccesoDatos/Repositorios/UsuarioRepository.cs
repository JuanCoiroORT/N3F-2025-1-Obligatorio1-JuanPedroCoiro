using LogicaAccesoDatos.Contexto;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContexto _contexto;

        public UsuarioRepository(AppDbContexto contexto)
        {
            _contexto = contexto;
        }

        public Usuario Add(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
            return usuario;
        }

        public Usuario Delete(Usuario usuario)
        {
            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();
            return usuario;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _contexto.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return _contexto.Set<Usuario>().FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> GetByName(string name)
        {
            return _contexto.Set<Usuario>().AsEnumerable().Where(u => u.NombreCompleto.Nombre == name);
        }

        public Usuario Update(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
            return usuario;
        }
    }
}
