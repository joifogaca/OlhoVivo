namespace OlhoVivo.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            VehiclePositions = new List<VehiclePositions>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Model { get;  set; }
        public long LineId { get; set; }

        public bool IsActive { get; set; }
        public Line Line { get;  set; }

        public IList<VehiclePositions>? VehiclePositions { get; set; }
    }
}
