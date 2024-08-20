using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteManagment.Core.Entities;

namespace RouteManagement.Infraestructure.Data.Configurations
{
    public class DrivingLicenseTypeConfiguration : IEntityTypeConfiguration<DrivingLicenseType>
    {
        public void Configure(EntityTypeBuilder<DrivingLicenseType> builder)
        {
            builder.HasKey(e => e.TypeLicenseId).HasName("PRIMARY");

            builder.ToTable("drivinglicensetype");

            builder.Property(e => e.TypeLicenseId).HasColumnType("int(11)");
            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
