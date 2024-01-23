namespace OlhoVivo.Models
{
    public class Line
    {
        public Line() 
        { }
        public Line(string name, IList<BusStop> paradas) 
        { 
            Name = name;
            BusStops = paradas;
        }

        public long Id { get; set; }
        public string Name { get; private set; }
        public IList<BusStop> BusStops { get; private set; } = new List<BusStop>();

        public void RemoveBusStop(BusStop busStop) {
        BusStops.Remove(busStop);
        }

        public void AddBusStop(BusStop busStop) {
            BusStops.Add(busStop);
        }
    }
}
