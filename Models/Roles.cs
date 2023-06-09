﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace userRole.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [AllowNull]
        public string? Description { get; set; }
    }
}
