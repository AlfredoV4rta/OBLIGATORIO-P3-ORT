using LaEmpresa.AccesoDatos.EF;
using LaEmpresa.AccesoDatos.EF.RepositoriosEF;
using LaEmpresa.LogicaAplicacion.CasosDeUso.PagoCU;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inicializar DBContext
builder.Services.AddDbContext<LaEmpresaContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("LaEmpresa"))
);

//Inicializar Repositorio
builder.Services.AddScoped<IPagoRepositorio, RepositorioPagoEF>();

//Inicializar CU
builder.Services.AddScoped<IObtenerPagos, ObtenerPagosCU>();
builder.Services.AddScoped<IObtenerPagoPorId, ObtenerPagoPorIdCU>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
