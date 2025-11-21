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

var builder = WebApplication.CreateBuilder(args);

//Inicializar DBContext
builder.Services.AddDbContext<LaEmpresaContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("LaEmpresa"))
);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

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

builder.Services.AddSwaggerGen();



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
