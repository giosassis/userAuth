using Microsoft.EntityFrameworkCore;
using userRole.Models;

namespace userRole.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Permission> Permission { get; set; }
    }
}
