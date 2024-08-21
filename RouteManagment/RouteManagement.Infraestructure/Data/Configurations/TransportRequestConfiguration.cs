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
    public class TransportRequestConfiguration : IEntityTypeConfiguration<TransportRequest>
    {
        public void Configure(EntityTypeBuilder<TransportRequest> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("transport_requests");

            builder.HasIndex(e => e.AdministratorId, "AdministratorId");

            builder.HasIndex(e => e.CompanyId, "CompanyId");

            builder.HasIndex(e => e.TransportTypeId, "TransportTypeId");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.AdministratorId).HasColumnType("int(11)");
            builder.Property(e => e.CompanyId).HasColumnType("int(11)");
            builder.Property(e => e.Date).HasColumnType("datetime");
            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");
            builder.Property(e => e.TransportTypeId).HasColumnType("int(11)");

            builder.HasOne(d => d.Administrator).WithMany(p => p.TransportRequests)
                .HasForeignKey(d => d.AdministratorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("transport_requests_ibfk_3");

            builder.HasOne(d => d.Company).WithMany(p => p.TransportRequests)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("transport_requests_ibfk_2");

            builder.HasOne(d => d.TransportType).WithMany(p => p.TransportRequests)
                .HasForeignKey(d => d.TransportTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("transport_requests_ibfk_1");
        }
    }
}
