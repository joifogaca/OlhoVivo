using System.ComponentModel.DataAnnotations;

namespace OlhoVivo.ModelViews.VehiclePosition
{
    public class CreateVehiclePositionViewModel
    {
        [Required(ErrorMessage = "DateTime é um campo Obrigátorio")]
        public DateTime? DateTime { get; set; }

        [Required(ErrorMessage = "Latitude é um campo Obrigátorio")]
        public double Latitude { get; private set; }

        [Required(ErrorMessage = "Longitude é um campo Obrigátorio")]
        public double Longitude { get; private set; }
    }
}
