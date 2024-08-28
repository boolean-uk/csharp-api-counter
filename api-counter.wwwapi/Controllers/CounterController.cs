using api_counter.wwwapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi.Controllers
{
    [ApiController]
    [Route("counters")]
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


        // 1. write a method that returns all counters in the counters list.  use method below as a starting point
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetAllCounters()
        {
            return TypedResults.Ok(counters);
        }

        // 2. write a method to return a single counter based on the id being passed in.  complete method below
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> GetACounter(int id)
        {
            var counter = counters.FirstOrDefault(c => c.Id.Equals(id));
            return counter is not null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        // 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
        [HttpGet]
        [Route("greaterthan/{number}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetGreater(int number)
        {
            var c = counters.Where(c => c.Value > number);
            return TypedResults.Ok(c);
        }

        // 4. write another controlller method that returns counters that have a value less than the {number} passed in.
        [HttpGet]
        [Route("lessthan/{number}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetLess(int number)
        {
            var c = counters.Where(c => c.Value < number);
            return TypedResults.Ok(c);
        }
      
        //Extension #1
        // 1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased
        [HttpGet]
        [Route("inc/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> IncrementACounter(int id)
        {
            var counter = counters.FirstOrDefault(c => c.Id.Equals(id));
            if (counter is not null) counter.Value++;
            return counter is not null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }
        
        //Extension #2
        // 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        [HttpGet]
        [Route("dec/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> DecrementACounter(int id)
        {
            var counter = counters.FirstOrDefault(c => c.Id.Equals(id));
            if (counter is not null) counter.Value--;
            return counter is not null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }
    }
}