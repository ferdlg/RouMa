
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteManagment.Core.Entities;

namespace RouteManagement.Infraestructure.Data.Configuraions
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>

    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("addresses");

            builder.HasIndex(e => e.StreetTypeId, "StreetTypeId");

            builder.Property(e => e.Id)
                .HasColumnName("AddressId")
                .HasColumnType("int(11)");
            builder.Property(e => e.Plate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            builder.Property(e => e.Prefix)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
            builder.Property(e => e.Quadrant)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
            builder.Property(e => e.StreetName)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
            builder.Property(e => e.StreetNumber)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            builder.Property(e => e.StreetTypeId).HasColumnType("int(11)");

            builder.HasOne(d => d.StreetType).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StreetTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("addresses_ibfk_1");
        }
    }
}