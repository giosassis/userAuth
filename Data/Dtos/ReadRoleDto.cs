namespace userRole.Data.Dtos
{
    public class ReadRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ReadPermissionDto> Permissions { get; set; }
    }
}
