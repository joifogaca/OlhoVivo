namespace OlhoVivo.Models
{
    public class Vehicle : BaseModel
    {
        public Vehicle()
        {
            VehiclePositions = new List<VehiclePositions>();
        }
        public string Name { get; set; }
        public string Model { get;  set; }
        public long LineId { get; set; }

        public bool IsActive { get; set; }
        public Line Line { get;  set; }

        public IList<VehiclePositions>? VehiclePositions { get; set; }
    }
}
