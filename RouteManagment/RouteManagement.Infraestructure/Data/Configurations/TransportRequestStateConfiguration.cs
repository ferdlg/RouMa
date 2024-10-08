using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteManagment.Core.Entities;

namespace RouteManagement.Infraestructure.Data.Configurations
{
    public class TransportRequestStateConfiguration : IEntityTypeConfiguration<TransportRequestState>
    {
        public void Configure(EntityTypeBuilder<TransportRequestState> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("transport_request_states");

            builder.Property(e => e.Id)
                .HasColumnName("StateId")
                .HasColumnType("int(11)");
            builder.Property(e => e.State).HasMaxLength(50);

            builder.Property(e => e.IsDelete)
                 .HasColumnName("IsDelete")
                 .HasColumnType("boolean")
                 .HasDefaultValue(false);
        }
    }
}
