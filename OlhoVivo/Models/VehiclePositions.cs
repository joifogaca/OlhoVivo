namespace OlhoVivo.Models
{
    public class VehiclePositions
    {
        public   long Id { get; set; }
        public DateTime? DateTime { get; set; } //DateTime no .NEt nunca inicia nulo, se quizer nulo colocar o ponto de ?
        public double Latitude { get; set; }
        public double Longitude { get;  set; }
        public Vehicle Vehicle { get;  set; }

        public long? VehicleId { get;  set;}
    }
}
