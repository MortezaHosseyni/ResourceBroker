using System.ComponentModel.DataAnnotations;

namespace ResourceBroker.Models
{
    public class Package : BaseModel
    {
        [MaxLength(225)] public string? Title { get; set; }
        [MaxLength(225)] public string? Description { get; set; }

        public double QosScore { get; set; }
        public bool IsQosCompliant { get; set; }

        public virtual ICollection<Resource>? Resources { get; set; }
    }
}
