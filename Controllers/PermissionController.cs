using Microsoft.AspNetCore.Mvc;
using userRole.Repository.Implementation;
using userRole.Repository.Interface;

namespace userRole.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        { 
            _permissionRepository = permissionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissions = await _permissionRepository.GetPermissionsAsync();
            return Ok(permissions);
        }
    }
}
