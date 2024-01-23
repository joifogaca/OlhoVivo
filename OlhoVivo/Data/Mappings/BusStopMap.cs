using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlhoVivo.Models;

namespace OlhoVivo.Data.Mappings
{
    public class BusStopMap : IEntityTypeConfiguration<BusStop>
    {
        public void Configure(EntityTypeBuilder<BusStop> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // IDENTITY(1,1)

            builder.Property(x => x.Name)
                .IsRequired() //gera o NOT NULL
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

        }
    }
}
