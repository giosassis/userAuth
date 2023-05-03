using System.ComponentModel.DataAnnotations;

namespace userRole.Models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
