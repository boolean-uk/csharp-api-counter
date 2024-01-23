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
            //change the number returned in the line below to counter list variable
            var allCounters = counters;
            return Results.Ok(allCounters);
        }

        //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetACounter(int id)
        {
            var counter = counters.Find(c => c.Id == id);

            if (counter != null)
            {
                return TypedResults.Ok(counter);
            }
            else
            {
                return Results.NotFound($"Counter with Id {id} not found");
            }
        }

        //TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> GetGreaterThan(int number)
        {
            List<Counter> greaterCounters = new List<Counter>();


            foreach(var counter in counters)
            {
                if (counter.Value > number)
                { 
                    greaterCounters.Add(counter); 
                }
                //counters.Add(c => c.Value > number);
            }
           
           

            if (greaterCounters != null)
            {
                return TypedResults.Ok(greaterCounters);
            }
            else
            {
                return Results.NotFound($"Counter with value greater than {number} not found");
            }
        }

        ////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.

        [HttpGet]
        [Route("lessthan/{number}")]
        public async Task<IResult> GetLessThan(int number)
        {

            List<Counter> lessThanCounters = new List<Counter>();


            foreach (var counter in counters)
            {
                if (counter.Value < number)
                {
                    lessThanCounters.Add(counter);
                }
                //counters.Add(c => c.Value > number);
            }



            if (lessThanCounters != null)
            {
                return TypedResults.Ok(lessThanCounters);
            }
            else
            {
                return Results.NotFound($"Counter with value less than {number} not found");
            }
        }



        //Extension #1
        //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased
        [HttpPut]
        [Route("{id}")]
        public async Task<IResult> incrementsValue(int id, int number)
        {
            var counter = counters.Find(c => c.Id == id);
            counter.Value += number; 

            if (counter != null)
            {
                return TypedResults.Ok(counter);
            }
            else
            {
                return Results.NotFound($"Counter with Id {id} not found");
            }
        }


        //Extension #2
        //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        [HttpPut]
        [Route("{id}")]
        public async Task<IResult> decrementsValue(int id, int number)
        {
            var counter = counters.Find(c => c.Id == id);
            counter.Value -= number;

            if (counter != null)
            {
                return TypedResults.Ok(counter);
            }
            else
            {
                return Results.NotFound($"Counter with Id {id} not found");
            }
        }

    }
}