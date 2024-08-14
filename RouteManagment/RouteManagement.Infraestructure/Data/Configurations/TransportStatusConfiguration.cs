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
    public class TransportStatusConfiguration : IEntityTypeConfiguration<TransportStatus>
    {
        public void Configure(EntityTypeBuilder<TransportStatus> builder)
        {
            builder.HasKey(e => e.StatusId).HasName("PRIMARY");

            builder.ToTable("transport_statuses");

            builder.Property(e => e.StatusId).HasColumnType("int(11)");
            builder.Property(e => e.Status).HasMaxLength(50);
        }
    }
}
