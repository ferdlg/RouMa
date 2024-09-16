using FluentValidation.AspNetCore;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RouteManagement.Infraestructure.Filters;
using RouteManagement.Infraestructure.Repositories;
using RouteManagment.Core.Interfaces;
using RouteManagment.Core.Services;
using RouteManagment.Server.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add service Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add filter validations from App 


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add conection database
var conectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));

// ID Interface registration --> Implementacion Generica

builder.Services.AddTransient<IRouteService, RouteService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPeopleService, PeopleService>();

builder.Services.AddScoped<ITransportRepository, TransportRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IServiceR<>), typeof(BaseServiceR<>));
builder.Services.AddScoped(typeof(IServiceP<>), typeof(BaseServiceP<>));
builder.Services.AddScoped(typeof(IServiceT<>), typeof(BaseServiceT<>));

builder.Services.AddScoped<IRouteUnitOfWork, RouteUnitOfWork >();
builder.Services.AddScoped<ITransportUnitOfWork, TransportUnitOfWork>();
builder.Services.AddScoped<IPeopleUnitOfWork, PeopleUnitOfWork>();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
