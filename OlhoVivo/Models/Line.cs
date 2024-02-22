namespace OlhoVivo.Models
{
    public class Line
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
        public List<BusStop> BusStops { get; private set; }

    }
}
