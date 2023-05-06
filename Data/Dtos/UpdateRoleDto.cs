using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Xunit.Sdk;

namespace userRole.Data.Dtos
{
    public class UpdateRoleDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [AllowNull]
        public string? Description { get; set; }
    }
}
