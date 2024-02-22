namespace OlhoVivo.Models
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Model { get;  set; }
        public Line Line { get;  set; }

        public IList<VehiclePositions> VehiclePositions { get; set; }
    }
}
