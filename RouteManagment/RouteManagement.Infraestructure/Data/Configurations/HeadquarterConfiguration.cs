using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteManagment.Core.Entities;

namespace RouteManagement.Infraestructure.Data.Configurations
{
    public class HeadquarterConfiguration : IEntityTypeConfiguration<Headquarter>
    {
        public void Configure(EntityTypeBuilder<Headquarter> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("headquarters");

            builder.Property(e => e.Id)
                .HasColumnName("HeadQuarterId")
                .HasColumnType("int(11)");
            builder.Property(e => e.AddressId).HasColumnType("int(11)");
            builder.Property(e => e.CompanyId).HasColumnType("int(11)");

            builder.Property(e => e.IsDelete)
                 .HasColumnName("IsDelete")
                 .HasColumnType("boolean")
                 .HasDefaultValue(false);

        }
    }
}
