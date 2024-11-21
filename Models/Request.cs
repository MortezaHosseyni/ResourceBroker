using ResourceBroker.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResourceBroker.Models
{
    public class Request : BaseModel
    {
        public RequestStatus Status { get; set; }

        public ResourceType Type { get; set; }

        public int Count { get; set; }
        public int Capacity { get; set; }

        [Required] public required Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))] public virtual User? User { get; set; }
    }
}
