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
            builder.HasKey(e => e.RouteId).HasName("PRIMARY");

            builder.ToTable("routes");

            builder.Property(e => e.RouteId).HasColumnType("int(11)");
            builder.Property(e => e.AddressOriginId).HasColumnType("int(11)");
            builder.Property(e => e.AddressHeadQuarterId).HasColumnType("int(11)");

        }
    }
}
