using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlhoVivo.Models;

namespace OlhoVivo.Data.Mappings
{
    public class PositionVehicleMap : IEntityTypeConfiguration<PositionVehicle>
    {
        public void Configure(EntityTypeBuilder<PositionVehicle> builder)
        {
            
        }
    }
}
