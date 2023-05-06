using System.ComponentModel.DataAnnotations;

namespace userRole.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? RegistrationNumber { get; set; }
    }
}
