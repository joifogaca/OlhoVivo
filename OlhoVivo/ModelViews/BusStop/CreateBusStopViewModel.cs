using System.ComponentModel.DataAnnotations;

namespace OlhoVivo.ModelViews.BusStop
{
    public class CreateBusStopViewModel
    {
        [Required(ErrorMessage = "Name é um campo Obrigátorio")]
        [StringLength(40, MinimumLength =6, ErrorMessage ="Este campo deve conter entre 6 e 40 caracteres)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Latitude é um campo Obrigátorio")]
        public double Latitude { get; private set; }

        [Required(ErrorMessage = "Longitude é um campo Obrigátorio")]
        public double Longitude { get; private set; }
    }
}
