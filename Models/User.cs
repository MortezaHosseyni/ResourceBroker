using System.ComponentModel.DataAnnotations;

namespace ResourceBroker.Models
{
    public class User : BaseModel
    {
        [Required][MaxLength(70)] public required string FirstName { get; set; }
        [Required][MaxLength(80)] public required string LastName { get; set; }
        [Required][Phone] public required string PhoneNumber { get; set; }
        [Required][EmailAddress] public required string Email { get; set; }

        public virtual ICollection<Request>? Requests { get; set; }
        public virtual ICollection<Allocate>? Allocates { get; set; }
    }
}
