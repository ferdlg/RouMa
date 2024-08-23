using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteManagment.Core.Entities;

namespace RouteManagement.Infraestructure.Data.Configurations
{
    public class TransportRequestStateConfiguration : IEntityTypeConfiguration<TransportState>
    {
        public void Configure(EntityTypeBuilder<TransportState> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("transport_Request_States");

            builder.Property(e => e.Id)
                .HasColumnName("StateId")
                .HasColumnType("int(11)");
            builder.Property(e => e.State).HasMaxLength(50);
        }
    }
}
