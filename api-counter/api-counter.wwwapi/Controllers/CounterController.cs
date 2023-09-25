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

        // TODO #1

        // write a method that returns all counters in the counters list. use method below as a starting point.

        [HttpGet]
        public async Task<IResult> GetAllCounters()
        {
            return Results.Ok(counters);
        }

        //TODO #2

        // write a method to return a single counter based on the id being passed in. complete method below.

        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetACounter(int id)
        {
            var counter = counters.FirstOrDefault(c => c.Id == id);

            return counter != null ? Results.Ok(counter) : Results.NotFound();
        }

        // TODO #3

        // write another controlller method that returns counters that have a value greater than the {number} passed in. use method below as starting point.

        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> GetCountersGreaterThan(int number)
        {
            var filteredCounters = counters.Where(c => c.Value > number).ToList();
            return Results.Ok(filteredCounters);
        }

        // TODO #4 

        // write another controlller method that returns counters that have a value less than the {number} passed in.

        [HttpGet]
        [Route("lessthan/{number}")]
        public async Task<IResult> GetCountersLessThan(int number)
        {
            var filteredCounters = counters.Where(c => c.Value < number).ToList();
            return Results.Ok(filteredCounters);
        }

        //Extension #1

        // write a controller method that increments the Value property of a counter of any given Id.
        // e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6.
        // return the counter you have increased.

        [HttpPut]
        [Route("increment/{id}")]
        public async Task<IResult> IncrementCounterValue(int id)
        {
            var counter = counters.FirstOrDefault(c => c.Id == id);

            if (counter != null)
            {
                counter.Value++;
                return Results.Ok(counter);
            }
            else
            {
                return Results.NotFound();
            }
        }

        //Extension #2

        // write a controller method that decrements the Value property of a counter of any given Id.
        // e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4.
        // return the counter you have decreased.

        [HttpPut]
        [Route("decrement/{id}")]
        public async Task<IResult> DecrementCounterValue(int id)
        {
            var counter = counters.FirstOrDefault(c => c.Id == id);

            if (counter != null)
            {
                if (counter.Value > 0)
                {
                    counter.Value--;
                }
                return Results.Ok(counter);
            }
            else
            {
                return Results.NotFound();
            }
        }
    }
}