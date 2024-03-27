using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;


namespace chu_core_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // GET api/weatherforecast/additem
        [HttpGet]
        [Route("additem")]
        public IEnumerable<char> AddItem()
        {
            var letter = new List<char> { 'a', 'b' };
            letter.Add('c');
            letter.Add('d');
            letter.Remove('c');
            return letter; // a, b, d
        }

        // GET api/weatherforecast/additems
        [HttpGet]
        [Route("additems")]
        public string AddItems()
        {
            var letters = new char[10];
            for (int i = 0; i < letters.Length; i++)
                letters[i] = (char)('a' + i);
  
            return String.Concat(letters); // 'abcdefghij'
        }

        // GET api/weatherforecast/getall
        [HttpGet]
        [Route("getall")]
        public IEnumerable<string> GetAll()
        {
            return Summaries;
        }

        // GET api/weatherforecast/5
        [HttpGet]
        [Route("{id}")]
        public string Get([FromRoute] int id)
        {
            return Summaries[id];
        }

        // POST api/weatherforecast
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Summaries.Append(value).ToArray();
            
        }

        // PUT api/weatherforecast/5
        [HttpPut]
        [Route("{id}")]
        public void Put([FromRoute] int id, [FromBody] string value)
        {
            Summaries[id] = value;
        }

        // DELETE api/weatherforecast/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete([FromRoute] int id)
        {
            Summaries.Take(id).ToArray();
        }
    }
}
