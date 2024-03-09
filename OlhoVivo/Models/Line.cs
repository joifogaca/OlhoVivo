namespace OlhoVivo.Models
{
    public class Line
    {

        public Line() {
            Vehicles = new List<Vehicle>();
            BusStops = new List<BusStop>();
        }   
        public long Id { get; set; }
        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
        public List<BusStop> BusStops { get; set; }

    }
}
