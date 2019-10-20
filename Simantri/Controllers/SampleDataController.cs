using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simantri.Data;

namespace Simantri.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly WeatherForecastService ForecastService;

        public SampleDataController(WeatherForecastService forecastService)
        {
            this.ForecastService = forecastService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecast>> WeatherForecasts()
        {
            return await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}
