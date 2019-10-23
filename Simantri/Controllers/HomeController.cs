using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simantri.Core.Data.Services;
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
            ViewBag.NamaInstansi = await _configService.GetNamaInstansiAsync(cancellationToken);
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
