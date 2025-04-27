using LogicaAccesoDatos.Contexto;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.AplicacionCasosUso;
using LogicaAplicacion.Interfaces;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // CONEXION CON LA BASE DE DATOS
            builder.Services.AddDbContext<AppDbContexto>(
                options => options.UseSqlServer(
                        builder.Configuration.GetConnectionString("StringConnection")
                )
            );

            // INYECCION DE DEPENDENCIAS
            builder.Services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            builder.Services.AddScoped(typeof(ICrearUsuario), typeof(CrearUsuario));
            builder.Services.AddScoped(typeof(IDeleteUsuario), typeof(DeleteUsuario));
            builder.Services.AddScoped(typeof(IUpdateUsuario), typeof(UpdateUsuario));
            builder.Services.AddScoped(typeof(IGetUserById), typeof(GetUserById));
            builder.Services.AddScoped(typeof(IGetUsersByName), typeof(GetUsersByName));



            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
