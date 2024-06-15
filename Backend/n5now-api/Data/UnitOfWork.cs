using n5now_api.Services;
using n5now_api.Data;

namespace n5now_api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public UnitOfWork(AppDbContext context, IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            _context = context;
            _permissionRepository = permissionRepository;
            _permissionTypeRepository = permissionTypeRepository;
        }

        public IPermissionRepository PermissionRepository => _permissionRepository;

        public IPermissionTypeRepository PermissionTypeRepository => _permissionTypeRepository;

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
