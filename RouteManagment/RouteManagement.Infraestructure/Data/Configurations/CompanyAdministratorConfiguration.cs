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
    public class CompanyAdministratorConfiguration : IEntityTypeConfiguration<CompanyAdministrator>
    {
        public void Configure(EntityTypeBuilder<CompanyAdministrator> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");
            builder.ToTable("company_administrator");

            builder.HasIndex(e => e.DocumentNumber, "DocumentNumber");

            builder.Property(e => e.Id)
                .HasColumnName("CompanyAdminId")
                .HasColumnType("int(11)");

            builder.Property(e => e.DocumentNumber)
                .HasColumnType("int(11)");

            builder.Property(e => e.IsDelete)
                 .HasColumnName("IsDelete")
                 .HasColumnType("boolean")
                 .HasDefaultValue(false);

            builder.HasOne(d => d.DocumentNumberNavigation).WithMany(p => p.CompanyAdministrators)
                .HasForeignKey(d => d.DocumentNumber)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("company_administraitor_ibfk_1");

            builder.HasOne(d => d.CompanyIdNavigation).WithMany(c => c.CompanyAdministrators)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("company_administraitor_ibfk_2");
        }
    }
}
