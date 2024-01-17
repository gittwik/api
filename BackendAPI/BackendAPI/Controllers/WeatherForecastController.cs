using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {

            if (index < 0 || index >= Summaries.Count)
                return BadRequest("¬ведЄн некорректный индекс");

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("¬ведЄн некорректный индекс");

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public string Out(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return ("¬ведЄн некорректный индекс");

            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int FindByName(string name)
        {
            int count = 0;
            foreach (var item in Summaries)
            {
                if (name == item)
                {
                    count++;
                }
            }
            return count;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int? sortStrategy)
        {
            switch (sortStrategy)
            {
                case null:
                    Get(); 
                    return Ok();
                case 1:
                    Summaries.Sort();
                    return Ok();
                case -1:
                    Summaries.Sort();
                    Summaries.Reverse(); 
                    return Ok();
                default:
                    return BadRequest("¬ведЄн некорректный индекс");
            }

        }
    }
}