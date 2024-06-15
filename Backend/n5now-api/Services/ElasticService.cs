using n5now_api.Data;
using Nest;
using System.Threading.Tasks;

namespace n5now_api.Services
{
    public class ElasticService : IElasticService
    {
        private readonly IElasticClient _elasticClient;

        public ElasticService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task IndexPermission(Permission permission)
        {
            await _elasticClient.IndexDocumentAsync(permission);
        }
    }

    public interface IElasticService
    {
        Task IndexPermission(Permission permission);
    }
}
