using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteManagment.Core.Entities;

namespace RouteManagement.Infraestructure.Data.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PRIMARY");

            builder.ToTable("drivers");

            builder.HasIndex(e => e.DocumentNumber, "DocumentNumber");

            builder.Property(e => e.Id)
                .HasColumnName("DriverId")
                .HasColumnType("int(11)");
            builder.Property(e => e.DocumentNumber).HasColumnType("int(11)");

            builder.HasOne(d => d.DocumentNumberNavigation).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.DocumentNumber)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("drivers_ibfk_1");
        }
    }
}
