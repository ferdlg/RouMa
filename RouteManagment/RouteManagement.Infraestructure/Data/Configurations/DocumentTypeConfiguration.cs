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
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("document_types");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");
            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
