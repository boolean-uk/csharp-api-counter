using api_counter.wwwapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        public static List<Counter> _counters = new List<Counter>();


        public CounterController()
        {
            if (_counters.Count == 0)
            {
                _counters.Add(new Counter() { Id = 1, Name = "Books", Value = 5 });
                _counters.Add(new Counter() { Id = 2, Name = "Toys", Value = 2 });
                _counters.Add(new Counter() { Id = 3, Name = "Videogames", Value = 8 });
                _counters.Add(new Counter() { Id = 4, Name = "Pencils", Value = 3 });
                _counters.Add(new Counter() { Id = 5, Name = "Notepads", Value = 7 });
            }
        }


        //TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetAllCounters()
        {
            //change the number returned in the line below to counter list variable
            return Results.Ok(_counters);
        }

        //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{id}")]
        public async Task<IResult> GetACounter(int id)
        {
            //write code here replacing the string.Empty
            var counter = _counters.Where(c => c.Id == id).FirstOrDefault();
           
            //leave return line the same
            return counter != null ? Results.Ok(counter) : Results.NotFound();
        }

        //TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.
        // use method below as starting point
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("greaterthan{number}")]
        public async Task<IResult> GetGreatherThan(int number)
        {
            var results = _counters.Where(c => c.Value >= number).ToList();

            return results.Count>0 ? Results.Ok(results) : Results.NotFound();
        }

        ////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.





        //Extension #1
        //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased


        //Extension #2
        //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
    }
}