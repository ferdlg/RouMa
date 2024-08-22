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
    public class StreetTypeConfiguration : IEntityTypeConfiguration<StreetType>
    {
        public void Configure(EntityTypeBuilder<StreetType> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("street_types");

            builder.Property(e => e.Id)
                .HasColumnName("StreetTypeId")
                .HasColumnType("int(11)");
            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
