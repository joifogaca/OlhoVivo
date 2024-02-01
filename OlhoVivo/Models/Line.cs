namespace OlhoVivo.Models
{
    public class Line
    {
        public Line() 
        { }

        public Line(string name)
        {
            Name = name;
        }

        public Line(string name, IList<BusStop> busStops) 
        { 
            Name = name;
            BusStops = busStops;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }

        public IList<Vehicle> Vehicles { get; set; }
        public IList<BusStop> BusStops { get; private set; }

        public void SetName(string name) 
        {
            Name = name;
        }

        public void RemoveBusStop(BusStop busStop) {
        BusStops.Remove(busStop);
        }

        public void AddBusStop(BusStop busStop) {
            BusStops.Add(busStop);
        }
    }
}
