using api_counter.wwwapi9.Models;
using api_counter.wwwapi9.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_counter.wwwapi9.Controller
{

    [ApiController]
    [Route("controller/counters")]
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
        public async Task<IResult> GetCounters(IRepository repository)
        {
            return TypedResults.Ok(repository.GetCounters());
        }
        [HttpGet]
        [Route("/{id}")]
        public async Task<IResult> GetCounterById(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetCounterById(id));
        }
        [HttpGet]
        [Route("/greaterthan/{number}")]
        public async Task<IResult> GetCountersGreaterThan(IRepository repository, int number)
        {
            return TypedResults.Ok(repository.GetCountersGreaterThan(number));
        }
        [HttpGet]
        [Route("/lessthan/{number}")]
        public async Task<IResult> GetCountersLessThan(IRepository repository, int value)
        {
            return TypedResults.Ok(repository.GetCountersLessThan(value));
        }
        [HttpPost]
        [Route("/increment/{id}")]
        public async Task<IResult> IncrementCounterByID(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.IncrementCounterByID(id));
        }
        [HttpPost]
        [Route("/decrement/{id}")]
        public async Task<IResult> DecrementCounterByID(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.DecrementCounterByID(id));
        }
    }
}
