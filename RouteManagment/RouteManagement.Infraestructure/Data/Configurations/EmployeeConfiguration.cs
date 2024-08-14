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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.DocumentNumber).HasName("PRIMARY");

            builder.ToTable("employees");

            builder.HasIndex(e => e.AddressId, "AddressId");

            builder.HasIndex(e => e.CompanyId, "CompanyId");

            builder.HasIndex(e => e.DocumentTypeId, "DocumentTypeId");

            builder.HasIndex(e => e.RolId, "RolId");

            builder.HasIndex(e => e.TransportPlate, "TransportPlate");

            builder.Property(e => e.DocumentNumber).HasColumnType("int(11)");
            builder.Property(e => e.AddressId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            builder.Property(e => e.CompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            builder.Property(e => e.DocumentTypeId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(100);
            builder.Property(e => e.Phone).HasColumnType("int(11)");
            builder.Property(e => e.RolId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            builder.Property(e => e.TransportPlate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            builder.HasOne(d => d.Address).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employees_ibfk_1");

            builder.HasOne(d => d.Company).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employees_ibfk_4");

            builder.HasOne(d => d.DocumentType).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employees_ibfk_2");

            builder.HasOne(d => d.Rol).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employees_ibfk_3");

            builder.HasOne(d => d.TransportPlateNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.TransportPlate)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employees_ibfk_5");
        }
    }
}
