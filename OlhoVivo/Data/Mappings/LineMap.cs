using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlhoVivo.Models;

namespace OlhoVivo.Data.Mappings
{
    public class LineMap : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // IDENTITY(1,1)

            builder.Property(x => x.Name)
                .IsRequired() //gera o NOT NULL
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.HasIndex(x => x.Name, "IX_lINE_NAME")
               .IsUnique(); //GARANTE QUE O INDEX É UNICO

            builder.HasMany(x => x.BusStops)
                .WithMany(x => x.Lines)
                .UsingEntity<Dictionary<string, object>>(
                "Lines_BusStop",
                line => line.HasOne<BusStop>()
                .WithMany()
                .HasForeignKey("BusStopId")
                .HasConstraintName("FK_BusStopLine_BusStopId")
                .OnDelete(DeleteBehavior.Cascade),
                busStop => busStop.HasOne<Line>()
                .WithMany()
                .HasForeignKey("FK_BusStopLine_LineId")
                .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
