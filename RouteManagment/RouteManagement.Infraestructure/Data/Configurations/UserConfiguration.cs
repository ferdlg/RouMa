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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("users");

            builder.Property(e => e.Id)
                .HasColumnName("UserId")
                .HasColumnType("int(11)");
            builder.Property(e => e.DocumentNumber)
                .HasMaxLength(50);
            builder.Property(e => e.Password)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");

            builder.HasOne(d => d.DocumentNumberNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.DocumentNumber)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("drivers_ibfk_1");
        }
    }
}
