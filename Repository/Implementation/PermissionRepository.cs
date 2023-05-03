using Microsoft.EntityFrameworkCore;
using userRole.Data;
using userRole.Models;
using userRole.Repository.Interface;

namespace userRole.Repository.Implementation
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DataContext _context;
        public PermissionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return await _context.Permission.ToListAsync();
        }
    }
}
