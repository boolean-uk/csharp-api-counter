using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;
using api_counter.wwwapi9.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi9.Endpoints
{
    public static class CounterHelperEndPoints
    {
        public static void ConfigureCounterHelperEndPoints(this WebApplication app)
        {

            var counters = app.MapGroup("/counters");
            //TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
            counters.MapGet("/", getAllCounters);


            //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
            counters.MapGet("/{id}", getCounter);

            //TODO: 3.  write another method that returns counters that have a value greater than the {number} passed in.        
            counters.MapGet("/greaterthan/{number}", getGreaterThan);

            ////TODO:4. write another method that returns counters that have a value less than the {number} passed in.
            counters.MapGet("/lessthan/{number}", getLessThan);

            //Extension #1
            //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
            //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
            //return the counter you have increased
            counters.MapGet("/increment/{id}", increment);

            //Extension #2
            //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
            //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
            //return the counter you have decreased
            counters.MapGet("/decrement/{id}", decrement);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> decrement(ICounterRepository repo,int id)
        {
            var r = repo.Decrement(id); 
            if (r == null)
                return TypedResults.NotFound(id);
            return TypedResults.Ok(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> increment(ICounterRepository repo, int id)
        {
            var r = repo.Increment(id);
            if (r == null)
                return TypedResults.NotFound(id);
            return TypedResults.Ok(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> getLessThan(ICounterRepository repo, int number)
        {
            List<Counter> res = repo.GetCounters().ToList().Where(x => x.Value < number).ToList();
            return TypedResults.Ok(res);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> getGreaterThan(ICounterRepository repo, int number)
        {
            List<Counter> res = repo.GetCounters().ToList().Where(x => x.Value > number).ToList();
            return TypedResults.Ok(res);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> getCounter(ICounterRepository repo, int id)
        {    
            Counter? res = repo.GetCounter(id);
            if (res != null)
                return TypedResults.Ok(res);

            return TypedResults.NotFound(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> getAllCounters(ICounterRepository repo)
        {
            return TypedResults.Ok(repo.GetCounters());
        }


    }
}
