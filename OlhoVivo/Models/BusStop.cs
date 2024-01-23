namespace OlhoVivo.Models
{
    public class BusStop
    {
        public BusStop()
        {
            
        }

        public BusStop(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
        public long Id { get; private set; }
        public string Name { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
