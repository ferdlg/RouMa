﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagement.Infraestructure.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("roles");

            builder.Property(e => e.Id)
                .HasColumnName("RolId")
                .HasColumnType("int(11)");
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.Property(e => e.IsDelete)
                 .HasColumnName("IsDelete")
                 .HasColumnType("boolean")
                 .HasDefaultValue(false);
        }
    }
}
