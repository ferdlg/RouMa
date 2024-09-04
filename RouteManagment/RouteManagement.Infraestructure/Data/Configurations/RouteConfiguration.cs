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
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("routes");

            builder.Property(e => e.Id)
                .HasColumnName("RouteId")
                .HasColumnType("int(11)");
            builder.Property(e => e.AddressOriginId).HasColumnType("int(11)");
            builder.Property(e => e.AddressHeadQuarterId).HasColumnType("int(11)");

            builder.HasOne(e => e.AddressIdNavigation).WithMany(r => r.Routes)
                .HasForeignKey(d => d.AddressOriginId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("routes_ibfk_1");

            builder.HasOne(e => e.HeadQuarterIdNavigation).WithMany(r => r.Routes)
                .HasForeignKey(d => d.AddressHeadQuarterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("routes_ibfk_2");

        }
    }
}
