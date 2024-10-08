using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagement.Infraestructure.Data.Configurations
{
    public class StopConfiguration : IEntityTypeConfiguration<Stop>
    {
        public void Configure(EntityTypeBuilder<Stop> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("stops");

            builder.HasIndex(e => e.AddressId, "AddressId");

            builder.Property(e => e.Id)
                .HasColumnName("StopId")
                .HasColumnType("int(11)");
            builder.Property(e => e.AddressId).HasColumnType("int(11)");

            builder.HasOne(d => d.Address).WithMany(p => p.Stops)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("stops_ibfk_1");

            builder.Property(e => e.IsDelete)
                 .HasColumnName("IsDelete")
                 .HasColumnType("boolean")
                 .HasDefaultValue(false);
        }
    }
}
