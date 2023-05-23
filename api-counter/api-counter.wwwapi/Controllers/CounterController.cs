using api_counter.wwwapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        public static List<Counter> counters = new List<Counter>();


        public CounterController()
        {
            if (counters.Count == 0)
            {
                counters.Add(new Counter() { Id = 1, Name = "Books", Value = 5 });
                counters.Add(new Counter() { Id = 2, Name = "Toys", Value = 2 });
                counters.Add(new Counter() { Id = 3, Name = "Videogames", Value = 8 });
                counters.Add(new Counter() { Id = 4, Name = "Pencils", Value = 3 });
                counters.Add(new Counter() { Id = 5, Name = "Notepads", Value = 7 });
            }
        }

        [HttpGet]
        public async Task<IResult> GetAllCounters()
        {
            return Results.Ok(counters);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetACounter(int id)
        {
            var counter = counters.Where(x => x.Id == id).FirstOrDefault();
            return counter != null ? Results.Ok(counter) : Results.NotFound();
        }

        [HttpGet]
        [Route("greaterthan{number}")]
        public async Task<IResult> GetGreaterThan(int number)
        {
            var greaterThanCounters = counters.Where(x => x.Value > number).ToList();
            return Results.Ok(greaterThanCounters);
        }

        [HttpGet]
        [Route("lessthan{number}")]
        public async Task<IResult> GetLessThan(int number)
        {
            var lessThanCounters = counters.Where(x => x.Value < number).ToList();
            return Results.Ok(lessThanCounters);
        }

        [HttpGet]
        [Route("increasevalue{id}")]
        public async Task<IResult> IncreaseValue(int id)
        {
            var counter = counters.Where(x => x.Id == id).FirstOrDefault();
            if (counter != null)
            {
                counter.Value += 1;
            }

            return Results.Ok(counter);
        }

        [HttpGet]
        [Route("decreasevalue{id}")]
        public async Task<IResult> DecreaseValue(int id)
        {
            var counter = counters.Where(x => x.Id == id).FirstOrDefault();
            if (counter != null)
            {
                counter.Value -= 1;
            }
            return Results.Ok(counter);
        }
    }
}