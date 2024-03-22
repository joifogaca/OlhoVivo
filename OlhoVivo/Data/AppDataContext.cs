using Microsoft.EntityFrameworkCore;
using OlhoVivo.Data.Mappings;
using OlhoVivo.Models;

namespace OlhoVivo.Data
{
    public class AppDataContext : DbContext
    {

        public AppDataContext(DbContextOptions<AppDataContext> options) :base(options) 
        {
                
        }

        public AppDataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You don't actually ever need to call this
        }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Line> Lines { get; set; }

        public DbSet<BusStop> BusStops { get; set; }

        public DbSet<VehiclePositions> VehiclePositions { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new VehicleMap());
        //    modelBuilder.ApplyConfiguration(new LineMap());
        //    modelBuilder.ApplyConfiguration(new BusStopMap());
        //    modelBuilder.ApplyConfiguration(new VehiclePositionMap());
        //}

    }
}
