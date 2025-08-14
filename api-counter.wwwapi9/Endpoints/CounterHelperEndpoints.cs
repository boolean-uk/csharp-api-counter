using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi9.Endpoints
{
    public static class CounterHelperEndpoints
    {
        public static void ConfigureCounterHelper(this WebApplication app)
        {
            var bands = app.MapGroup("Counter");

            bands.MapGet("/", GetCounters);
            bands.MapGet("/{id}", GetCounter);
            bands.MapGet("/greaterthan/{number}", GreaterThan);
            bands.MapGet("/lessthan/{number}", LessThan);
            bands.MapPut("/increment/{id}", Increment);
            bands.MapPut("/decrement/{id}", Decrement);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounters()
        {
            return TypedResults.Ok(CounterHelper.Counters);
        }


        //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
        public static async Task<IResult> GetCounter(int id)
        {
            List<Counter> counters = CounterHelper.Counters.Where(counter => counter.Id == id).ToList();
            return TypedResults.Ok(counters.First());
        }

        //TODO: 3.  write another method that returns counters that have a value greater than the {number} passed in.        
        public static async Task<IResult> GreaterThan(int number)
        {
            return TypedResults.Ok(CounterHelper.Counters.Where(counter => counter.Value > number));
        }

        ////TODO:4. write another method that returns counters that have a value less than the {number} passed in.
        public static async Task<IResult> LessThan(int number)
        {
            return TypedResults.Ok(CounterHelper.Counters.Where(counter => counter.Value < number));
        }

        //Extension #1
        //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased
        public static async Task<IResult> Increment(int id)
        {
            CounterHelper.Increment(id);
            return TypedResults.Ok(CounterHelper.Counters.Where(counter => counter.Id == id));
        }


        //Extension #2
        //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        public static async Task<IResult> Decrement(int id)
        {
            CounterHelper.Decrement(id);
            return TypedResults.Ok(CounterHelper.Counters.Where(counter => counter.Id == id));
        }



    }
}
