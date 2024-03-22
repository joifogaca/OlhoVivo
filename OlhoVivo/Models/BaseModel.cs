using System.ComponentModel.DataAnnotations;

namespace OlhoVivo.Models
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }
        public bool Active { get; set; }
    }
}
