using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Persistencia;
using TiendaServicios.Api.Libro.RemoteInterfaces;
using TiendaServicios.Api.Libro.RemoteServices;
using static TiendaServicios.Api.Libro.Aplicacion.Nuevo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibroContexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Agrega MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

//Agregar FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<EjecutaValidacion>();

// Agregar AutoMapper y buscar perfiles en el ensamblado actual
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddHttpClient("Autor", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Autor"]);
});

builder.Services.AddScoped<IAutorService, AutorService>();

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
