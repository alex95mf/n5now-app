using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace n5now_api.Data
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Permission> AddPermission(Permission permission)
        {
            await _context.Permissions.AddAsync(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<Permission> UpdatePermission(Permission permission)
        {
            var existingPermission = await _context.Permissions.FindAsync(permission.Id);
            if (existingPermission != null)
            {
                _context.Entry(existingPermission).CurrentValues.SetValues(permission);
                await _context.SaveChangesAsync();
            }
            return existingPermission;
        }

        public async Task<List<PermissionDetail>> GetAllPermissionsIncludingType()
        {
            var permissions = await _context.Permissions
               .ToListAsync();

            var permisoAdmin = new PermissionType() { Id = 1, Description = "Administrador" };
            var permisoUser = new PermissionType() { Id = 2, Description = "Usuario" };

            var permissionsDetail = permissions.Select(p => new PermissionDetail
            {
                Id = p.Id,
                NombreEmpleado = p.NombreEmpleado,
                ApellidoEmpleado = p.ApellidoEmpleado,
                TipoPermiso = p.TipoPermiso,
                FechaPermiso = p.FechaPermiso,
                TipoPermisoDetalle = p.TipoPermiso == 1 ? permisoAdmin : permisoUser

            }).ToList();

            return permissionsDetail;
        }

    }

    public interface IPermissionRepository
    {
        Task<Permission> AddPermission(Permission permission);
        Task<Permission> UpdatePermission(Permission permission);
        Task<List<PermissionDetail>> GetAllPermissionsIncludingType();
    }
}
