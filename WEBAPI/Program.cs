
using LogicaAccesoDatos.Contexto;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.AplicacionCasosUso.AgenciaCU;
using LogicaAplicacion.AplicacionCasosUso.EnvioCU;
using LogicaAplicacion.AplicacionCasosUso.UsuarioCU;
using LogicaAplicacion.Interfaces.AgenciaInterfaces;
using LogicaAplicacion.Interfaces.EnvioInterfaces;
using LogicaAplicacion.Interfaces.UsuarioInterfaces;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WEBAPI.Servicios;



namespace WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // CONEXION CON LA BASE DE DATOS
            builder.Services.AddDbContext<AppDbContexto>(
                options => options.UseSqlServer(
                        builder.Configuration.GetConnectionString("StringConnection")
                )
            );

            // INYECCION DE DEPENDENCIAS

            //Inyeccion TokenService
            builder.Services.AddSingleton(new TokenService("ClaveSuperSecretaQueDebeSerLarga123!"));


            // Dependencia Usuario
            builder.Services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            builder.Services.AddScoped(typeof(ICrearUsuario), typeof(CrearUsuario));
            builder.Services.AddScoped(typeof(IDeleteUsuario), typeof(DeleteUsuario));
            builder.Services.AddScoped(typeof(IUpdateUsuario), typeof(UpdateUsuario));
            builder.Services.AddScoped(typeof(IGetUserById), typeof(GetUserById));
            builder.Services.AddScoped(typeof(IGetUsersByName), typeof(GetUsersByName));
            builder.Services.AddScoped(typeof(IGetClientes), typeof(GetClientes));

            // Dependencias Envio
            builder.Services.AddScoped(typeof(IEnvioRepository), typeof(EnvioRepository));
            builder.Services.AddScoped(typeof(ICrearComun), typeof(CrearComun));
            builder.Services.AddScoped(typeof(ICrearUrgente), typeof(CrearUrgente));
            builder.Services.AddScoped(typeof(IGetAllComunes), typeof(GetAllComunes));
            builder.Services.AddScoped(typeof(IGetAllUrgentes), typeof(GetAllUrgentes));
            builder.Services.AddScoped(typeof(IGetUrgenteById), typeof(GetUrgenteById));
            builder.Services.AddScoped(typeof(IGetComunById), typeof(GetComunById));
            builder.Services.AddScoped(typeof(IUpdateEnvio), typeof(UpdateEnvio));
            builder.Services.AddScoped(typeof(IDeleteUrgente), typeof(DeleteUrgente));
            builder.Services.AddScoped(typeof(IDeleteComun), typeof(DeleteComun));
            builder.Services.AddScoped(typeof(IGetByNumTracking), typeof(GetByNumTracking));

            // Dependecias Agencia
            builder.Services.AddScoped(typeof(IAgenciaRepository), typeof(AgenciaRepository));
            builder.Services.AddScoped(typeof(ICrearAgencia), typeof(CrearAgencia));
            builder.Services.AddScoped(typeof(IGetAgencias), typeof(GetAgencias));
            builder.Services.AddScoped(typeof(IGetAgenciaById), typeof(GetAgenciaById));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //JWT
            // Clave secreta para firmar el token JWT
            var jwtKey = "ClaveSuperSecretaQueDebeSerLarga123!"; // Podés ponerla en appsettings.json también

            // Agregá el TokenService como servicio (opcional pero mejor)
            builder.Services.AddSingleton(new TokenService(jwtKey));

            // Configurar JWT Bearer
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // simplificamos
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication(); //JWT
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
