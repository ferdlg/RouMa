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
    public class RoutesStopConfiguration : IEntityTypeConfiguration<RoutesStop>
    {
        public void Configure(EntityTypeBuilder<RoutesStop> builder)
        {
           builder.HasKey(e => e.Id).HasName("PRIMARY");

           builder.ToTable("routes_stops");

           builder.HasIndex(e => e.RouteId, "RouteId");

           builder.HasIndex(e => e.StopId, "StopId");

           builder.Property(e => e.Id)
                .HasColumnName("RouteStopId")
                .HasColumnType("int(11)");
           builder.Property(e => e.RouteId).HasColumnType("int(11)");
           builder.Property(e => e.StopId).HasColumnType("int(11)");

           builder.HasOne(d => d.Route).WithMany(p => p.RoutesStops)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("routes_stops_ibfk_1");

           builder.HasOne(d => d.Stop).WithMany(p => p.RoutesStops)
                .HasForeignKey(d => d.StopId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("routes_stops_ibfk_2");
        }
    }
}
