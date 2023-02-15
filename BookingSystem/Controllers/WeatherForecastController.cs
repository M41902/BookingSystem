using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingSystemController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<BookingSystemController> _logger;

        public BookingSystemController(ILogger<BookingSystemController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBookings")]
        public IEnumerable<BookingSystem> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new BookingSystem
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}