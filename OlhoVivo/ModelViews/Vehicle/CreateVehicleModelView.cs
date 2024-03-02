using System.ComponentModel.DataAnnotations;

namespace OlhoVivo.ModelViews.Vehicle
{
    public class CreateVehicleModelView
    {
        [Required(ErrorMessage = "Name é um campo Obrigátorio")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Este campo deve conter entre 6 e 40 caracteres)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Modelo é um campo Obrigátorio")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Este campo deve conter entre 6 e 40 caracteres)")]
        public string Model { get; set; }
    }
}
