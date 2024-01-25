using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlhoVivo.Models;

namespace OlhoVivo.Data.Mappings
{
    public class PositionVehicleMap : IEntityTypeConfiguration<PositionVehicle>
    {
        public void Configure(EntityTypeBuilder<PositionVehicle> builder)
        {
            builder.HasIndex(x => x.Vehicle, "IX_POSITIONVEHICLE_VEHICLE")
               .IsUnique(); //GARANTE QUE O INDEX É UNICO
        }
    }
}
