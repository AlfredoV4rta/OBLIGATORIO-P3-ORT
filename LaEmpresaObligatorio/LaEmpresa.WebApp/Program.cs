using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaAplicacion.CasosDeUso;
using LaEmpresa.LogicaAplicacion.CasosDeUso.TipoDeGastoCU;
using LaEmpresa.AccesoDatos.EF;
using Microsoft.EntityFrameworkCore;
using LaEmpresa.AccesoDatos.EF.RepositoriosEF;
using Microsoft.Extensions.DependencyInjection;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaAplicacion.CasosDeUso.UsuarioCU;

namespace LaEmpresa.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Inicializar DBContext
            builder.Services.AddDbContext<LaEmpresaContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("LaEmpresa"))    
            );

            // Inicalizar Repositorios
            builder.Services.AddScoped<ITipoDeGastoRepositorio, RepositorioTipoDeGastoEF>();
            builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuarioEF>();


            //Inicializar CU
            builder.Services.AddScoped<IObtenerTipoDeGasto, ObtenerTipoDeGastoCU>();
            builder.Services.AddScoped<IAltaTipoDeGasto, AltaTipoDeGastoCU>();
            builder.Services.AddScoped<IBorrarTipoDeGasto, BorrarTipoDeGastoCU>();
            builder.Services.AddScoped<IObtenerTipoDeGastoPorId, ObtenerTipoDeGastoPorIdCU>();
            builder.Services.AddScoped<IEditarTipoDeGasto, EditarTipoDeGastoCU>();
            builder.Services.AddScoped<ILogin, LoginCU>();
            builder.Services.AddScoped<IObtenerUsuarios, ObtenerUsuariosCU>();

            //Sesion
            builder.Services.AddSession();

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
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
