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
    public class TransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.HasKey(e => e.Plate).HasName("PRIMARY");

            builder.ToTable("transports");

            builder.HasIndex(e => e.RouteId, "RouteId");

            builder.HasIndex(e => e.StateId, "StateId");

            builder.HasIndex(e => e.TransportTypeId, "TransportTypeId");

            builder.Property(e => e.Plate).HasColumnType("varchar(50)");
            builder.Property(e => e.Capacity).HasColumnType("int(11)");
            builder.Property(e => e.RouteId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            builder.Property(e => e.StateId).HasColumnType("int(11)");
            builder.Property(e => e.TransportTypeId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            builder.HasOne(d => d.Route).WithMany(p => p.Transports)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("transports_ibfk_2");

            builder.HasOne(d => d.State).WithMany(p => p.Transports)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("transports_ibfk_1");

            builder.HasOne(d => d.TransportType).WithMany(p => p.Transports)
                .HasForeignKey(d => d.TransportTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("transports_ibfk_3");
        }
    }
}
