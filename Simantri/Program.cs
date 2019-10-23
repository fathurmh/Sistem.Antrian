using System.Threading.Tasks;
using Fathcore.Extensions.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Simantri
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IWebHost hosting = CreateWebHostBuilder(args).Build();
            await hosting.RunWithTasksAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
