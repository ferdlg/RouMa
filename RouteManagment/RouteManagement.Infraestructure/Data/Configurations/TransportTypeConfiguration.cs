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
    public class TransportTypeConfiguration : IEntityTypeConfiguration<TransportType>
    {
        public void Configure(EntityTypeBuilder<TransportType> builder)
        {
            builder.HasKey(e => e.TransportTypeId).HasName("PRIMARY");

            builder.ToTable("transport_types");

            builder.Property(e => e.TransportTypeId).HasColumnType("int(11)");
            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
        }
    }
}
