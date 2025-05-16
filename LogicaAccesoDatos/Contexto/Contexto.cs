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

        public DbSet<Envio> Envios { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Agencia> Agencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // HERENCIA: TPH
            modelBuilder.Entity<Envio>()
                .HasDiscriminator<string>("Tipo")
                .HasValue<Comun>("Comun")
                .HasValue<Urgente>("Urgente");

            // Relación Envio -> Seguimiento
            modelBuilder.Entity<Envio>()
                .HasMany(e => e.Seguimientos)
                .WithOne(s => s.Envio)
                .HasForeignKey(s => s.EnvioId);

            // Evitar delete en cascada
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Empleado)
                .WithMany()
                .HasForeignKey(e => e.EmpleadoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comun>()
                .HasOne(c => c.Agencia)
                .WithMany()
                .HasForeignKey(c => c.AgenciaId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
