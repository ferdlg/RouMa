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
    public class EfmigrationshistoryConfiguration : IEntityTypeConfiguration<Efmigrationshistory>
    {
        public void Configure(EntityTypeBuilder<Efmigrationshistory> builder)
        {
            builder.HasKey(e => e.MigrationId).HasName("PRIMARY");

            builder.ToTable("__efmigrationshistory");

            builder.Property(e => e.MigrationId).HasMaxLength(150);
            builder.Property(e => e.ProductVersion).HasMaxLength(32);
        }
    }
}
