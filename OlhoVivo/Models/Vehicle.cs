namespace OlhoVivo.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            
        }

        public Vehicle(string name, 
            string model, long lineId)
        {
            Name = name;
            Model = model;
            LineId = lineId;
        }
        public long Id { get; set; }
        public string Name { get; private set; }
        public string Model { get;  private set; }
        public long LineId { get; private set; }

        public void AlterLine(long lineId)
        {
            LineId = lineId;
        }
    }
}
