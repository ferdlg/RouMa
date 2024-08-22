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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("companies");

            builder.HasIndex(e => e.AddressId, "AddressId");

            builder.Property(e => e.Id)
                .HasColumnName("CompanyId")
                .HasColumnType("int(11)");
            builder.Property(e => e.AddressId).HasColumnType("int(11)");
            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.Address).WithMany(p => p.Companies)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("companies_ibfk_1");
        }
    }
}
