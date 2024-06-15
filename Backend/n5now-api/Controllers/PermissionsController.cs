using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using n5now_api.Data;
using n5now_api.Services;

namespace n5now_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpPost]
        public async Task<IActionResult> RequestPermission([FromBody] Permission permission)
        {
            var result = await _permissionService.RequestPermission(permission);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyPermission(int id, [FromBody] Permission permission)
        {
            if (id != permission.Id)
            {
                return BadRequest("No existe un Permiso con el ID especificado.");
            }

            var result = await _permissionService.ModifyPermission(permission);
            if (result == null)
            {
                return NotFound("No se ha encontrado el permiso a modificar.");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var result = await _permissionService.GetPermissions();
            return Ok(result);
        }
    }
}
