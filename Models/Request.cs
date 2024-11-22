using ResourceBroker.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResourceBroker.Models
{
    public class Request : BaseModel
    {
        public RequestStatus Status { get; set; }

        [Required] public required Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))] public virtual User? User { get; set; }

        [Required] public required Guid ResourceId { get; set; }
        [ForeignKey(nameof(ResourceId))] public virtual Resource? Resource { get; set; }
    }
}
