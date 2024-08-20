
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

    public virtual DbSet<DrivingLicenseType> DrivingLicenseTypes { get; set; }

    public virtual DbSet<Headquarter> Headquarters { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Person> People{ get; set; }

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

    public virtual DbSet<TransportRequestState> TransportRequestStates { get; set; }

    public virtual DbSet<TransportState> TransportStates { get; set; }

    public virtual DbSet<TransportType> TransportTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfiguration());

        modelBuilder.ApplyConfiguration(new AdministratorConfiguration());


        modelBuilder.ApplyConfiguration(new CompanyConfiguration());

        modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());

        modelBuilder.ApplyConfiguration(new DriverConfiguration());

        modelBuilder.ApplyConfiguration(new DrivingLicenseTypeConfiguration());

        modelBuilder.ApplyConfiguration(new HeadquarterConfiguration());

        modelBuilder.ApplyConfiguration(new EfmigrationshistoryConfiguration());

        modelBuilder.ApplyConfiguration(new PersonConfiguration());

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

        modelBuilder.ApplyConfiguration(new TransportRequestStateConfiguration());

        modelBuilder.ApplyConfiguration(new TransportStateConfiguration());

        modelBuilder.ApplyConfiguration(new TransportTypeConfiguration());
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
