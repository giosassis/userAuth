﻿namespace userRole.Data.Dtos
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
