using FluentValidation;
using FluentValidation.AspNetCore;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RouteManagement.Infraestructure.Filters;
using RouteManagement.Infraestructure.Validators;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add service Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add filter validations from App 
IMvcBuilder mvcBuilder = builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
}).AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add conection database
var conectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));

// ID Interface registration

builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IAdministratorRepository, AdministratorRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IDocumentTypeRepository, DocumentTypeRepository>();
builder.Services.AddTransient<IDriverRepository, DriverRepository>();
builder.Services.AddTransient<IDrivingLicenseTypeRepository, DrivingLicenseTypeRepository>();
builder.Services.AddTransient<IHeadquarterRespository, HeadquarterRepository>();
builder.Services.AddTransient<IPeopleRepository, PeopleRepository>();
builder.Services.AddTransient<IPassengerRepository, PassengerRepository>();
builder.Services.AddTransient<IPermissionRepository, PermissionRepository>();
builder.Services.AddTransient<IRolRepository, RolRepository>();
builder.Services.AddTransient<IRolPermissionRepository, RolPermissionRepository>();
builder.Services.AddTransient<IRouteRepository, RouteRepository>();
builder.Services.AddTransient<IRouteStopRepository, RouteStopRepository>();
builder.Services.AddTransient<IStopRepository, StopRepository>();
builder.Services.AddTransient<IStreetTypeRepository, StreetTypeRepository>();
builder.Services.AddTransient<ITransportRepository, TransportRepository>();
builder.Services.AddTransient<ITransportRequestRepository, TransportRequestRepository>();
builder.Services.AddTransient<ITransportStateRepository, TransportStateRepository>();
builder.Services.AddTransient<ITransportTypeRepository, TransportTypeRepository>();



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
