using n5now_api.Data;

namespace n5now_api.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticService _elasticService;

        public PermissionService(IUnitOfWork unitOfWork, IElasticService elasticService)
        {
            _unitOfWork = unitOfWork;
            _elasticService = elasticService;
        }

        public async Task<Permission> RequestPermission(Permission permission)
        {
            var newPermission = await _unitOfWork.PermissionRepository.AddPermission(permission);
            await _elasticService.IndexPermission(newPermission);
            return newPermission;
        }

        public async Task<Permission> ModifyPermission(Permission permission)
        {
            var updatedPermission = await _unitOfWork.PermissionRepository.UpdatePermission(permission);
            if (updatedPermission != null)
            {
                await _elasticService.IndexPermission(updatedPermission);
            }
            return updatedPermission;
        }

        public async Task<List<PermissionDetail>> GetPermissionsIncludingType()
        {
            return await _unitOfWork.PermissionRepository.GetAllPermissionsIncludingType();
        }
    }

    public interface IUnitOfWork
    {
        IPermissionRepository PermissionRepository { get; }
        IPermissionTypeRepository PermissionTypeRepository { get; }
        Task<int> CompleteAsync();
    }

    public interface IPermissionService
    {
        Task<Permission> RequestPermission(Permission permission);
        Task<Permission> ModifyPermission(Permission permission);
        Task<List<PermissionDetail>> GetPermissionsIncludingType();
    }
}
