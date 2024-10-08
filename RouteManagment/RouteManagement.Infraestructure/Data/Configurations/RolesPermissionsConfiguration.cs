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
    internal class RolesPermissionsConfiguration : IEntityTypeConfiguration<RolesPermission>
    {
        public void Configure(EntityTypeBuilder<RolesPermission> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("roles_permissions");

            builder.HasIndex(e => e.PermissionId, "PermissionId");

            builder.HasIndex(e => e.RolId, "RolId");

            builder.Property(e => e.Id)
                .HasColumnName("RolPermissionId")
                .HasColumnType("int(11)");
            builder.Property(e => e.PermissionId).HasColumnType("int(11)");
            builder.Property(e => e.RolId).HasColumnType("int(11)");

            builder.HasOne(d => d.Permission).WithMany(p => p.RolesPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("roles_permissions_ibfk_1");

            builder.HasOne(d => d.Rol).WithMany(p => p.RolesPermissions)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("roles_permissions_ibfk_2");

            builder.Property(e => e.IsDelete)
                 .HasColumnName("IsDelete")
                 .HasColumnType("boolean")
                 .HasDefaultValue(false);
        }
    }
}
