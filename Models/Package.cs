using System.ComponentModel.DataAnnotations;
using ResourceBroker.Enums;

namespace ResourceBroker.Models
{
    public class Package : BaseModel
    {
        [MaxLength(225)] public string? Title { get; set; }
        [MaxLength(225)] public string? Description { get; set; }

        public double QosScore { get; set; }
        public bool IsQosCompliant { get; set; }

        public double TakenTimeForCreation { get; set; }
        public double Efficiency { get; set; }
        public double Complexity { get; set; }

        public PackageAlgorithmType Algorithm { get; set; }

        public virtual ICollection<Resource>? Resources { get; set; }
    }
}
