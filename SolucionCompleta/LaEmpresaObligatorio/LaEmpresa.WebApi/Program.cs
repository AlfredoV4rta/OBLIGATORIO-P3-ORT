using LaEmpresa.AccesoDatos.EF;
using LaEmpresa.AccesoDatos.EF.RepositoriosEF;
using LaEmpresa.LogicaAplicacion.CasosDeUso.PagoCU;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaAplicacion.CasosDeUso.UsuarioCU;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LaEmpresa.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configurar uso de token
            var clave = "clave_SecretaDeLaEmpr_esaGoated_tieneQueSerMasLarga";

            builder.Services.AddAuthentication(
                aut =>
                {
                    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }

            )
            .AddJwtBearer(aut =>
            {

                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (System.Text.Encoding.UTF8.GetBytes
                            (builder.Configuration.GetSection("SecretTokenKey").Value!)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            }

            );

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opciones =>
            {
                opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Description = "Autorización estándar mediante esquema Bearer",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                opciones.OperationFilter<SecurityRequirementsOperationFilter>();

                opciones.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Documentación de LaEmpresa.Api",
                    Description = "Aqui se encuentran todos los endpoint activos para utilizar los servicios del proyecto LaEmpresa",
                    Contact = new OpenApiContact
                    {
                        Email = "fede.oteiza@gmail.com | alfredo.vartabedian@gmail.com"
                    },
                    Version = "v1"
                });
            });

            //Inicializar DBContext
            builder.Services.AddDbContext<LaEmpresaContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("LaEmpresa"))
            );

            //Inicializar Repositorio
            builder.Services.AddScoped<IPagoRepositorio, RepositorioPagoEF>();
            builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuarioEF>();

            //Inicializar CU
            builder.Services.AddScoped<IObtenerPagos, ObtenerPagosCU>();
            builder.Services.AddScoped<IObtenerPagoPorId, ObtenerPagoPorIdCU>();
            builder.Services.AddScoped<IObtenerPagosMensuales, ObtenerPagosMensualesCU>();
            builder.Services.AddScoped<IObtenerUsuariosMayorMonto, ObtenerUsuariosMayorMontoCU>();
            builder.Services.AddScoped<IObtenerPagosDeUsuario, ObtenerPagosDeUsuarioCU>();
            builder.Services.AddScoped<ILogin, LoginCU>();
            builder.Services.AddScoped<IObtenerEquiposMayorMonto, ObtenerEquiposMayorMontoCU>();

            builder.Services.AddAuthorization(
                options =>
                {
                    options.DefaultPolicy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //Configuracion autenticacion
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}