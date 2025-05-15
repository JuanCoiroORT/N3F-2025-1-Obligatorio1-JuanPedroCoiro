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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar herencia
            modelBuilder.Entity<Urgente>().ToTable("EnviosUrgentes");
            modelBuilder.Entity<Comun>().ToTable("EnviosComunes");

            // Configuración de las claves foráneas para evitar el ciclo de cascada
            modelBuilder.Entity<Urgente>()
                .HasOne(u => u.Cliente)
                .WithMany()
                .HasForeignKey(u => u.ClienteId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Urgente>()
                .HasOne(u => u.Empleado)
                .WithMany()
                .HasForeignKey(u => u.EmpleadoId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Comun>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comun>()
                .HasOne(c => c.Empleado)
                .WithMany()
                .HasForeignKey(c => c.EmpleadoId)
                .OnDelete(DeleteBehavior.NoAction); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
