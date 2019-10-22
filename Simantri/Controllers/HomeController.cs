using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simantri.Data.Services;
using Simantri.Models;

namespace Simantri.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConfigService _configService;

        public HomeController(ConfigService configService)
        {
            _configService = configService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var configs = await _configService.GetConfigAsync(cancellationToken);
            string namaInstansi = configs.FirstOrDefault(p => p.Key.Equals("NamaInstansi")).Value;
            ViewBag.NamaInstansi = namaInstansi;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
