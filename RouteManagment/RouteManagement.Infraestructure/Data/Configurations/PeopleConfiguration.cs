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
    public class PeopleConfiguration : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("people");

            builder.Property(e => e.Id)
                .HasColumnName("DocumentNumber")
                .HasColumnType("bigint");

            builder.HasIndex(e => e.AddressId, "AddressId");

            builder.HasIndex(e => e.DocumentTypeId, "DocumentTypeId");

            builder.HasIndex(e => e.RolId, "RolId");


            builder.Property(e => e.AddressId)
                .HasColumnType("int(11)");

            builder.Property(e => e.DocumentTypeId)
                .HasColumnType("int(11)");
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(100);
            builder.Property(e => e.Phone).HasColumnType("int(11)");
            builder.Property(e => e.RolId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            builder.HasOne(d => d.Address).WithMany(p => p.People)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("people_ibfk_1");


            builder.HasOne(d => d.DocumentType).WithMany(p => p.People)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("people_ibfk_2");

            builder.HasOne(d => d.Rol).WithMany(p => p.People)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("people_ibfk_3");

            builder.Property(e => e.IsDelete)
                 .HasColumnName("IsDelete")
                 .HasColumnType("boolean")
                 .HasDefaultValue(false);
        }
    }
}
