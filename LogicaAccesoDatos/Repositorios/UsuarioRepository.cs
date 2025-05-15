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
        public Usuario Update(int id, Usuario usuario)
        {
            // BUSCAR USUARIO
            Usuario usuarioBuscado = _contexto.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (usuarioBuscado == null)
            {
                throw new ArgumentException("usuario no encontrado", nameof(usuario));
            }
            // ACTUALIZAR PROPIEDADES
            usuarioBuscado.CI = usuario.CI;
            usuarioBuscado.Nombre = usuario.Nombre;
            usuarioBuscado.Apellido = usuario.Apellido;
            usuarioBuscado.Email = usuario.Email;
            usuarioBuscado.Password = usuario.Password;
            usuarioBuscado.Rol = usuario.Rol;
            // GUARDAR CAMPOS
            _contexto.SaveChanges();
            return usuario;
        }

        public Usuario Delete(int id)
        {
            // BUSCAR USUARIO EN BD
            Usuario usuarioBuscado = _contexto.Usuarios.FirstOrDefault(u => u.Id == id);
            if(usuarioBuscado == null)
            {
                throw new ArgumentException("Usuario no encontrado.");
            }
            // ELIMINAR USUARIO
            _contexto.Usuarios.Remove(usuarioBuscado);
            _contexto.SaveChanges();
            return usuarioBuscado;
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
            if (String.IsNullOrEmpty(name))
            {
                return _contexto.Usuarios.ToList();
            }
            else
            {
                return _contexto.Usuarios.Where(u => u.Nombre.ToLower().Contains(name.ToLower())).ToList();
            }
        }

        public Usuario GetByEmail(string email)
        {
            return _contexto.Set<Usuario>().FirstOrDefault(u => u.Email == email);
        }

        public IEnumerable<Usuario> GetClientes()
        {
            return _contexto.Usuarios.Where(u => u.Rol == "Cliente").ToList();
        }
    }
}
