using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fathcore.EntityFramework;
using Simantri.Core.Data.Domain;

namespace Simantri.Core.Data.Services
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

        public async Task<string> GetNamaInstansiAsync(CancellationToken cancellationToken = default)
        {
            var namaInstansi = await _configRepository.SelectAsync(p => p.Key.Equals(Constants.Config.NamaInstansi), cancellationToken);
            return namaInstansi.Value.ToUpper();
        }

    }
}
