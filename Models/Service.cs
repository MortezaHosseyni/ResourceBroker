using System.ComponentModel.DataAnnotations;

namespace ResourceBroker.Models
{
    public class Service : BaseModel
    {
        [Required][MaxLength(255)] public required string Name { get; set; }
        [MaxLength(555)] public string? Description { get; set; }

        public float Download { get; set; }
        public float Upload { get; set; }
        public float Bandwidth { get; set; }

        public virtual ICollection<Resource>? Resources { get; set; }
    }
}
