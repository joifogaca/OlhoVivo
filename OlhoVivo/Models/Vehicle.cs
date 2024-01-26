namespace OlhoVivo.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            
        }

        public Vehicle(string name, 
            string model, Line line)
        {
            Name = name;
            Model = model;
            Line = line;
        }
        public long Id { get; set; }
        public string Name { get; private set; }
        public string Model { get;  private set; }
        public Line Line { get; private set; }

        public IList<VehiclePositions> VehiclePositions { get; private set; } = new List<VehiclePositions>();

        public void AlterLine(Line line)
        {
            Line = line;
        }
    }
}
