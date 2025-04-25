using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LogicaAccesoDatos.Contexto
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContexto>
    {
        public AppDbContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContexto>();

            // Construir la configuración desde el archivo appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Obtener la cadena de conexión del archivo de configuración
            var connectionString = configuration.GetConnectionString("StringConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContexto(optionsBuilder.Options);
        }
    }
}
