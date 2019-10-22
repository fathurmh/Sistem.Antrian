using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fathcore.EntityFramework;
using Simantri.Data.Domain;

namespace Simantri.Data.Services
{
    public class ConfigService
    {
        private readonly ICachedRepository<Config> _configRepository;

        public ConfigService(ICachedRepository<Config> configRepository)
        {
            _configRepository = configRepository;
        }

        public async Task<IEnumerable<Config>> GetConfigAsync(CancellationToken cancellationToken = default)
        {
            var configs = await _configRepository.SelectListAsync(cancellationToken);
            return configs;
        }
    }
}
