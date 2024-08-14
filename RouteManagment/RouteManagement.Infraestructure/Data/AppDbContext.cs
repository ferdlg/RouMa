
using Microsoft.EntityFrameworkCore;
using RouteManagement.Infraestructure.Data.Configuraions;
using RouteManagement.Infraestructure.Data.Configurations;
using RouteManagment.Core.Entities;

namespace RouteManagment.Server.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesPermission> RolesPermissions { get; set; }

    public virtual DbSet<Core.Entities.Route> Routes { get; set; }

    public virtual DbSet<RoutesStop> RoutesStops { get; set; }

    public virtual DbSet<Stop> Stops { get; set; }

    public virtual DbSet<StreetType> StreetTypes { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<TransportRequest> TransportRequests { get; set; }

    public virtual DbSet<TransportStatus> TransportStatuses { get; set; }

    public virtual DbSet<TransportType> TransportTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfiguration());

        modelBuilder.ApplyConfiguration(new AdministratorConfiguration());


        modelBuilder.ApplyConfiguration(new CompanyConfiguration());

        modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());

        modelBuilder.ApplyConfiguration(new DriverConfiguration());

        modelBuilder.ApplyConfiguration(new EfmigrationshistoryConfiguration());

        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

        modelBuilder.ApplyConfiguration(new PassengerConfiguration());

        modelBuilder.ApplyConfiguration(new PermissionConfiguration());

        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        modelBuilder.ApplyConfiguration(new RolesPermissionsConfiguration());

        modelBuilder.ApplyConfiguration(new RouteConfiguration());

        modelBuilder.ApplyConfiguration(new RoutesStopConfiguration());

        modelBuilder.ApplyConfiguration(new StopConfiguration());

        modelBuilder.ApplyConfiguration(new StreetTypeConfiguration());

        modelBuilder.ApplyConfiguration(new TransportConfiguration());

        modelBuilder.ApplyConfiguration(new TransportRequestConfiguration());

        modelBuilder.ApplyConfiguration(new TransportStatusConfiguration());

        modelBuilder.ApplyConfiguration(new TransportTypeConfiguration());



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
