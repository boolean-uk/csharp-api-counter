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


        //TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
        [HttpGet]
        [Route("")]
        public async Task<IResult> GetAllCounters()
        {
            //change the number returned in the line below to counter list variable
            return TypedResults.Ok(counters);
        }

        //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetACounter(int id)
        {
            // Find the counter with the specified ID
            var counter = counters.FirstOrDefault(c => c.Id == id);

            //leave return line the same, Return the counter if found, otherwise return NotFound

            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }


        //TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> GetCountersGreaterThan(int number)
        {
            // Filter counters based on the value condition
            var filteredCounters = counters.Where(c => c.Value > number).ToList();

            // Return the filtered counters
            return TypedResults.Ok(filteredCounters);
        }

        ////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> GetCounterslesserThan(int number)
        {
            // Filter counters based on the value condition
            var filteredCounters = counters.Where(c => c.Value > number).ToList();

            // Return the filtered counters
            return TypedResults.Ok(filteredCounters);
        }




        //Extension #1
        //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased
        [HttpPost]
        [Route("increment/{id}")]
        public async Task<IResult> IncrementCounterValue(int id)
        {
            // Find the counter with the specified ID
            var counter = counters.FirstOrDefault(c => c.Id == id);

            if (counter != null)
            {
                // Increment the counter's value and return the updated counter
                counter.Value++;
                return TypedResults.Ok(counter);
            }
            else
            {
                // Return a 404 Not Found response if the counter is not found
                return TypedResults.NotFound();
            }
        }


        //Extension #2
        //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        [HttpPost]
        [Route("decrement/{id}")]
        public async Task<IResult> DecrementCounterValue(int id)
        {
            // Find the counter with the specified ID
            var counter = counters.FirstOrDefault(c => c.Id == id);

            if (counter != null)
            {
                // Decrement the counter's value and return the updated counter
                counter.Value--;
                return TypedResults.Ok(counter);
            }
            else
            {
                // Return a 404 Not Found response if the counter is not found
                return TypedResults.NotFound();
            }

        }
    }
}