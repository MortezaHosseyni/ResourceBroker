using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResourceBroker.Models
{
    public class Allocate : BaseModel
    {
        [Required] public required Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))] public virtual User? User { get; set; }

        [Required] public required Guid ResourceId { get; set; }
        [ForeignKey(nameof(ResourceId))] public virtual Resource? Resource { get; set; }
    }
}
