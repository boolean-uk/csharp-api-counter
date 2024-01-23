using api_counter.wwwapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi.Controllers
{
    [ApiController]
    [Route("counters")]
    public class CounterController : ControllerBase
    {
        public static List<Counter> Counters = new List<Counter>();


        public CounterController()
        {
            if (Counters.Count == 0)
            {
                Counters.Add(new Counter() { Id = 1, Name = "Books", Value = 5 });
                Counters.Add(new Counter() { Id = 2, Name = "Toys", Value = 2 });
                Counters.Add(new Counter() { Id = 3, Name = "Videogames", Value = 8 });
                Counters.Add(new Counter() { Id = 4, Name = "Pencils", Value = 3 });
                Counters.Add(new Counter() { Id = 5, Name = "Notepads", Value = 7 });
            }
        }


        // 1. write a method that returns all counters in the counters list.  use method below as a starting point
        [HttpGet]
        [Route("")]
        public async Task<IResult> GetAllCounters()
        {
            //change the number returned in the line below to counter list variable
            return TypedResults.Ok(Counters);
        }

        // 2. write a method to return a single counter based on the id being passed in.  complete method below
        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetACounter(int id)
        {
            //write code here replacing the string.Empty
            var counter = Counters.FirstOrDefault(c => c.Id == id);
           
            //leave return line the same
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        // 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> GetCounterGreaterThan(int number)
        {
            var counters = Counters.Where(c => c.Value > number);
            return counters.Any() ? TypedResults.Ok(counters) : TypedResults.NotFound();
        }

        // 4. write another controlller method that returns counters that have a value less than the {number} passed in.
        [HttpGet]
        [Route("lessthan/{number}")]
        public async Task<IResult> GetCounterLessThan(int number)
        {
            var counters = Counters.Where(c => c.Value < number);
            return counters.Any() ? TypedResults.Ok(counters) : TypedResults.NotFound();
        }


        //Extension #1
        // 1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased 
        [HttpPatch]
        [Route("increment/{id}")]
        public async Task<IResult> IncrementCounter(int id)
        {
            var counter = Counters.FirstOrDefault(x => x.Id == id);
            if (counter == null)
                return TypedResults.NotFound();

            counter.Value++;
            return TypedResults.Accepted($"https://localhost:7293/counters/{id}", counter);
        }

        //Extension #2
        // 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        [HttpPatch]
        [Route("decrement/{id}")]
        public async Task<IResult> DecrementCounter(int id)
        {
            var counter = Counters.FirstOrDefault(x => x.Id == id);
            if (counter == null)
                return TypedResults.NotFound();

            counter.Value--;
            return TypedResults.Accepted($"https://localhost:7293/counters/{id}", counter);
        }
    }
}