namespace OlhoVivo.Models
{
    public class VehiclePositions
    {
        public VehiclePositions()
        {
                
        }

        public VehiclePositions(Vehicle vehicle, 
            double latitude, double longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Vehicle = vehicle;
        }
        public DateTime? DateTime { get; private set; } //DateTime no .NEt nunca inicia nulo, se quizer nulo colocar o ponto de ?
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public Vehicle Vehicle { get; private set; }
    }
}
