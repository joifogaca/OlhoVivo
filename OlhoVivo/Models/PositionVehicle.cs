namespace OlhoVivo.Models
{
    public class PositionVehicle
    {
        public PositionVehicle()
        {
                
        }

        public PositionVehicle(Vehicle vehicle, 
            double latitude, double longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Vehicle = vehicle;
            DateTime = DateTime.Now;
        }
        public DateTime DateTime { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public Vehicle Vehicle { get; private set; }
    }
}
