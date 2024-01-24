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


        [HttpGet]
        [Route("")]
        public async Task<IResult> GetAllCounters()
        {
            return TypedResults.Ok(counters);
        }

         [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetACounter(int id)
        {
                var counter = counters.FirstOrDefault(x => x.Id == id);
       
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> GetHighValues(int number)
        {
            List<Counter> countersSort = counters.Where(c => c.Value > number).ToList();
         
            return TypedResults.Ok(countersSort);
        }

       
        [HttpGet]
        [Route("lessthan/{number}")]
        public async Task<IResult> GetLowValues(int number)
        {
            List<Counter> countersSort = counters.Where(c => c.Value < number).ToList();
            
            return TypedResults.Ok(countersSort);
        }



        //Extension #1
        [HttpGet]
        [Route("increment/{id}")]
        public async Task<IResult> IncrementCounter(int id)
        {
            var counter = counters.FirstOrDefault(x => x.Id == id);
            if (counter != null) { counter.Value++; }
           
            return TypedResults.Ok(counter);
        }



        //Extension #2
        [HttpGet]
        [Route("decrement/{id}")]
        public async Task<IResult> DecrementCounter(int id)
        {
            var counter = counters.FirstOrDefault(x => x.Id == id);
            if (counter != null) { counter.Value--; }

            return TypedResults.Ok(counter);
        }
    }
}