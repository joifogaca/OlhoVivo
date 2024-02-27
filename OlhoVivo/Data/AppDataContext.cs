using Microsoft.EntityFrameworkCore;
using OlhoVivo.Data.Mappings;
using OlhoVivo.Models;

namespace OlhoVivo.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Line> Lines { get; set; }

        public DbSet<BusStop> BusStops { get; set; }

        public DbSet<VehiclePositions> VehiclePositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=OlhoVivo;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleMap());
            modelBuilder.ApplyConfiguration(new LineMap());
            modelBuilder.ApplyConfiguration(new BusStopMap());
            modelBuilder.ApplyConfiguration(new VehiclePositionMap());
        }

    }
}
