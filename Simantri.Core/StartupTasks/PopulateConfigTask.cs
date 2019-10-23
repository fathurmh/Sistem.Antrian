using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Fathcore.EntityFramework;
using Fathcore.Infrastructure.StartupTask;
using Microsoft.Extensions.DependencyInjection;
using Simantri.Core.Data.Domain;

namespace Simantri.Core.StartupTasks
{
    public class PopulateConfigTask : IAsyncStartupTask
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IRepository<Config> _configRepository;

        public PopulateConfigTask(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Config> configFromDb = new List<Config>();
            var configFromConstant = new List<Config>();

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                _configRepository = scope.ServiceProvider.GetRequiredService<IRepository<Config>>();
                configFromDb = await _configRepository.SelectListAsync();

                Type constantConfigType = typeof(Constants.Config);
                FieldInfo[] fields = constantConfigType.GetFields(BindingFlags.Static | BindingFlags.Public);
                foreach (FieldInfo field in fields)
                {
                    var config = new Config(field.Name, field.GetValue(null).ToString());
                    configFromConstant.Add(config);
                }

                var willDeleted = configFromDb.Where(p => !configFromConstant.Any(q => p.Key == q.Key));
                var willInserted = configFromConstant.Where(p => !configFromDb.Any(q => p.Key == q.Key));

                if (willDeleted.Any())
                {
                    await _configRepository.DeleteAsync(willDeleted, cancellationToken);
                }

                if (willInserted.Any())
                {
                    await _configRepository.InsertAsync(willInserted, cancellationToken);
                }

                await _configRepository.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
