using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Contexto
{
    public class AppDbContexto : DbContext
    {
        public AppDbContexto(DbContextOptions<AppDbContexto> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Comun> EnviosComunes { get; set; }
        public DbSet<Urgente> EnviosUrgentes { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
    }
}
