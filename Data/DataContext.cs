using Microsoft.EntityFrameworkCore;
using userRole.Models;

namespace userRole.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

    }
}
