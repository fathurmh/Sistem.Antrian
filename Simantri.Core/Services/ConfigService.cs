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

        public async Task<string> GetConfigAsync(string configKey, CancellationToken cancellationToken = default)
        {
            var config = await _configRepository.SelectAsync(p => p.Key.Equals(configKey), cancellationToken);
            return config.Value;
        }

        public async Task<string> GetNamaInstansiAsync(CancellationToken cancellationToken = default)
        {
            var namaInstansi = await _configRepository.SelectAsync(p => p.Key.Equals(Constants.Config.NamaInstansi), cancellationToken);
            return namaInstansi.Value;
        }
    }
}
