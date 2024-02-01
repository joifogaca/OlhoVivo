using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlhoVivo.Models;

namespace OlhoVivo.Data.Mappings
{
    public class VehiclePositionMap : IEntityTypeConfiguration<VehiclePositions>
    {
        public void Configure(EntityTypeBuilder<VehiclePositions> builder)
        {
            builder.HasKey(x => new { x.DateTime, x.VehicleId});
           
            //builder.HasIndex(x =>new { x.Vehicle.Id, x.DateTime })
            //.IsUnique(); //GARANTE QUE O INDEX É UNICO

            builder.Property(x => x.Latitude)
                .IsRequired();

            builder.Property(x => x.Longitude)
                .IsRequired();

            builder.Property(x => x.DateTime)
                .IsRequired()
                .HasColumnType("SMALLDATETIME")
               // .HasDefaultValueSql("GETDATE()") //Chamando a função do SQL
               .HasDefaultValue(DateTime.Now.ToUniversalTime()); //Ele gera aqui no .NET antes de fazer o Insert

            builder.HasOne(x => x.Vehicle)
               .WithMany(x => x.VehiclePositions)
               //.HasForeignKey("")//Gera uma constraint
               .HasConstraintName("FK_VEHICLE_POSITIONS")
               .OnDelete(DeleteBehavior.Cascade);  //deleta todos os relacionados

        }
    }
}
