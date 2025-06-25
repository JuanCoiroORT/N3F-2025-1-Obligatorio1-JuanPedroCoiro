using LogicaAccesoDatos.Contexto;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
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
            // Buscar usuario
            Usuario usuarioBuscado = GetById(id);

            // Actualizar propiedades
            if(usuario.CI != null)
            {
                usuarioBuscado.CI = usuario.CI;
            }
            if(usuario.NombreCompleto != null)
            {
                usuarioBuscado.NombreCompleto = new NombreCompleto(usuario.NombreCompleto.Nombre, usuario.NombreCompleto.Apellido);  
            }
            if(usuario.Email != null)
            {
                usuarioBuscado.Email = usuario.Email;
            }
            if (usuario.Rol != null)
            {
                usuarioBuscado.Rol = usuario.Rol;
            }
            if(usuario.Password != null)
            {
                usuarioBuscado.Password = usuario.Password;
            }
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
            List<Usuario> usuarios = new List<Usuario>();

            if (String.IsNullOrEmpty(name))
            {
                // Logica para filtrar a los funcionarios
                foreach (var usuario in _contexto.Usuarios.ToList())
                {
                    if (usuario.Rol == "Funcionario")
                    {
                        usuarios.Add(usuario);
                    }
                }
            }
            else
            {
                string nameLower = name.ToLower();
                
                //Logica para encontrar por el nombre
                foreach (var usuario in _contexto.Usuarios.ToList())
                {
                    if (usuario.Rol == "Funcionario" &&
                        usuario.NombreCompleto != null &&
                        usuario.NombreCompleto.Nombre.ToLower().Contains(nameLower))
                    {
                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }


        public IEnumerable<Usuario> GetClientes()
        {
            return _contexto.Usuarios.Where(u => u.Rol == "Cliente").ToList();
        }
    }
}
