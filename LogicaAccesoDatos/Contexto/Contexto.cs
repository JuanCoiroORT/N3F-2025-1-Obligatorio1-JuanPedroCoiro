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
        public DbSet<EnvioEliminado> EnviosEliminados { get; set; }

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
                .WithOne()
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

            modelBuilder.Entity<EnvioEliminado>()
            .HasDiscriminator<string>("Tipo")
            .HasValue<ComunEliminado>("Comun")
            .HasValue<UrgenteEliminado>("Urgente");

            modelBuilder.Entity<Agencia>(ag =>
            {
                ag.OwnsOne(a => a.Ubicacion, ubic =>
                {
                    ubic.Property(u => u.Latitud).HasColumnName("Latitud").IsRequired();
                    ubic.Property(u => u.Longitud).HasColumnName("Longitud").IsRequired();
                });
            });

            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.OwnsOne(u => u.NombreCompleto, nombre =>
                {
                    nombre.Property(n => n.Nombre).HasColumnName("Nombre").HasMaxLength(100);
                    nombre.Property(n => n.Apellido).HasColumnName("Apellido").HasMaxLength(100);
                });
            });

            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Valor).HasColumnName("Email").HasMaxLength(100);
                });
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
