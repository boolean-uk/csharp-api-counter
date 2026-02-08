using api_counter.wwwapi.Models;
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


        //TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
        [HttpGet]
        [Route("")]
        public async Task<IResult> GetAllCounters()
        {
            //change the number returned in the line below to counter list variable
            if (!counters.Any()) return TypedResults.NoContent();
            return TypedResults.Ok(counters);
        }

        //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetACounter(int id)
        {
            //write code here replacing the string.Empty
            var counter = counters.Find(counter => counter.Id == id);

            //leave return line the same
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        //TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> Get(int number)
        {

            return TypedResults.Ok(counters.Where(counter => counter.Value > number));
        }

        ////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.

        [HttpGet]
        [Route("lessthan/{number}")]
        public async Task<IResult> GetLower(int number)
        {
            return TypedResults.Ok(counters.Where(counter => counter.Value < number));
        }



        //Extension #1
        //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased
        [HttpPatch]
        [Route("incrementCounterById/{id}")]
        public async Task<IResult> IncrementCounterById(int id)
        {
            var counter = counters.FirstOrDefault(c => c.Id == id);
            if (counter == default) { return TypedResults.NotFound($"Task {id} was not found"); }
            counter.Value++;

            return TypedResults.Ok(counters.Find(c => c.Id == id));
        }


        //Extension #2
        //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        [HttpPatch]
        [Route("decrementCounterById/{id}")]
        public async Task<IResult> DecrementCounterById(int id)
        {
            var counter = counters.FirstOrDefault(c => c.Id == id);
            if (counter == default) { return TypedResults.NotFound($"Task {id} was not found"); }
            if (counter.Value <= 0) return TypedResults.BadRequest($"Id: {id}, Value: {counter.Value}: value can't be negative");
            counter.Value--;

            return TypedResults.Ok(counters.Find(c => c.Id == id));
        }
    }
}