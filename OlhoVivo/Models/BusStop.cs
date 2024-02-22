namespace OlhoVivo.Models
{
    public class BusStop
    {
        public long Id { get;  set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public IList<Line> Lines { get; set;}
    }
}
