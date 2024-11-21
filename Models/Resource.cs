using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ResourceBroker.Enums;

namespace ResourceBroker.Models
{
    public class Resource : BaseModel
    {
        [Required][MaxLength(255)] public required string Name { get; set; }
        [MaxLength(555)] public string? Description { get; set; }

        public ResourceType Type { get; set; }

        public int Count { get; set; }
        public int Capacity { get; set; }

        [Required] public required Guid ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))] public virtual Service? Service { get; set; }

        public virtual ICollection<Allocate>? Allocates { get; set; }
    }
}
