using api_counter.wwwapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            
            return TypedResults.Ok(counters);
        }

        //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetACounter(int id)
        {
            //write code here replacing the string.Empty
            Counter? counter = counters.Find(x => x.Id == id);

            //leave return line the same
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        //TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> GetGreaterCounters(int number)
        {

            List<Counter> counter = new List<Counter>();

            foreach (Counter count in counters)
            {
                if (count.Value > number)
                {
                    counter.Add(count);
                }
            }

            return TypedResults.Ok(counter);

        }

        ////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.

        [HttpGet]
        [Route("lesserthan/{number}")]
        public async Task<IResult> GetLesserCounters(int number)
        {
            List<Counter> counter = new List<Counter>();

            foreach (Counter count in counters)
            {
                if (count.Value < number)
                {
                    counter.Add(count);
                }
            }
            return TypedResults.Ok(counter);
        }
        //Extension #1
        //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased
        [HttpPut]
        [Route("incrementval/{id}")]
        public async Task<IResult> GetIncrementId(int id)
        {
            Counter? counter = counters.Find(x => x.Id == id);

            if (counter == null)
            {
                return Results.NotFound("Task " + id + " not found.");
            }

            counter.Value += 1;

            return TypedResults.Ok(counter);
        }

        //Extension #2
        //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        [HttpPut]
        [Route("decrementval/{id}")]
        public async Task<IResult> GetDecrementId(int id)
        {
            Counter? counter = counters.Find(x => x.Id == id);

            if (counter == null)
            {
                return Results.NotFound("Task " + id + " not found.");
            }

            counter.Value -= 1;

            return TypedResults.Ok(counter);
        }
    }
}