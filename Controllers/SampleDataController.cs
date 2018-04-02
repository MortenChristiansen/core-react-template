using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_react_template.Models;
using Microsoft.AspNetCore.Mvc;

namespace core_react_template.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet]
        public async Task<string> DatabaseTest()
        {
            var doc = await DocumentDBRepo<Item>.CreateItemAsync(new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Husk at game i dag!",
                Description = "Vigtigt for dit helbred.",
                Completed = false
            });

            return "Works!";
        }

        [HttpGet]
        public Task<IEnumerable<Item>> GetItems()
        {
            return DocumentDBRepo<Item>.GetItemsAsync();
        }

        [HttpPost]
        public async Task<IEnumerable<Item>> NewItem([FromBody]Item item)
        {
            var doc = await DocumentDBRepo<Item>.CreateItemAsync(item);
            return await DocumentDBRepo<Item>.GetItemsAsync();
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
