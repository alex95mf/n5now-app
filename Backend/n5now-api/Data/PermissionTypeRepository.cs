using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace n5now_api.Data
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly AppDbContext _context;

        public PermissionTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PermissionType>> GetAllAsync()
        {
            return await _context.PermissionsTypes.ToListAsync();
        }
    }

    public interface IPermissionTypeRepository
    {
        Task<IEnumerable<PermissionType>> GetAllAsync();
    }
}
