using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BeAn.Data;
using Newtonsoft.Json;

namespace BeAn.Controllers
{

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ApplicationDbContext _context;

        public SampleDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<InnerWeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            
            Models.Forms form = new Models.Forms();
            form.StudentId = "student1";
            form.LastUpdated = DateTime.Now;
            form.ProgramId = "program1";
            form.ProgramDescription = "description";

            IList<string> DataPoints = new List<string>();
            DataPoints.Add("Datapoint1");
            DataPoints.Add("Datapoint2");
            DataPoints.Add("Datapoint3");

            form.DataPointsJson = JsonConvert.SerializeObject(DataPoints);

            _context.Forms.Add(form);
            _context.SaveChanges();

            return Enumerable.Range(1, 5).Select(index => new InnerWeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class InnerWeatherForecast
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
