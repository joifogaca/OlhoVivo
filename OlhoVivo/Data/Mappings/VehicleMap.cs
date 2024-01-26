using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlhoVivo.Models;

namespace OlhoVivo.Data.Mappings
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                  .UseIdentityColumn(); // IDENTITY(1,1)

            builder.Property(x => x.Name)
             .IsRequired() //gera o NOT NULL
             .HasColumnType("NVARCHAR")
             .HasMaxLength(80);

            builder.Property(x => x.Model)
             .IsRequired() //gera o NOT NULL
             .HasColumnType("NVARCHAR")
             .HasMaxLength(80);

            builder.HasIndex(x => x.Name, "IX_VEHICLE_NAME")
               .IsUnique(); //GARANTE QUE O INDEX É UNICO

            builder.HasOne(x => x.Line)
                .WithMany(x => x.Vehicles) //Gera uma constraint
                .HasConstraintName("FK_VEHICLE_LINE")
                .OnDelete(DeleteBehavior.Cascade);  //deleta todos os relacionados

        }
    }
}
