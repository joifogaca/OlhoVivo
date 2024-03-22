namespace OlhoVivo.Models
{
    public class BusStop :  BaseModel
    {
        public BusStop()
        {
            Lines = new List<Line>();
        }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public IList<Line> Lines { get; set;}
    }
}
