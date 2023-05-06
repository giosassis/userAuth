using Microsoft.EntityFrameworkCore;
using userRole.Data;
using userRole.Models;
using userRole.Repository.Interface;

namespace userRole.Repository.Implementation
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly DataContext _context;

        public RolePermissionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<RolePermission>> GetAllAsync()
        {
            return await _context.RolePermission
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .ToListAsync();
        }

        public async Task<RolePermission> GetByIdAsync(int id)
        {
            return await _context.RolePermission
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .FirstOrDefaultAsync(rp => rp.Id == id);
        }

        public async Task<RolePermission> CreateAsync(RolePermission rolePermission)
        {
            _context.RolePermission.Add(rolePermission);
            await _context.SaveChangesAsync();
            return rolePermission;
        }

        public async Task<RolePermission> UpdateAsync(RolePermission rolePermission)
        {
            _context.Entry(rolePermission).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return rolePermission;
        }

        public async Task<RolePermission> DeleteAsync(int id)
        {
            var rolePermission = await GetByIdAsync(id);
            if (rolePermission != null)
            {
                _context.RolePermission.Remove(rolePermission);
                await _context.SaveChangesAsync();
            }
            return rolePermission;
        }
    }
}
