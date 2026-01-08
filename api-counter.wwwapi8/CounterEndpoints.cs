using api_counter.wwwapi8.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi8
{
    public static class CounterEndpoints
    {

        public static void ConfigureCounterEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("/counters");
            counters.MapGet("/", GetAllCounters);
            counters.MapGet("/{id}", GetACounterById);
            counters.MapGet("/greaterthan/{number}", GetCounterValueGreaterThan);
            counters.MapGet("/lessthan/{number}", GetCounterValueLessThan);
            counters.MapGet("increment/{id}", IncrementCounterValue);
            counters.MapGet("decrement/{id}", DecrementCounterValue);
        }

        //TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllCounters()
        {
             return TypedResults.Ok(CounterHelper.Counters);
        }


        //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetACounterById(int id)
        {
            var counter = CounterHelper.GetACounterById(id);
        
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        //TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetCounterValueGreaterThan(int number)
        {
            var result = CounterHelper.GetCounterValueGreaterThan(number);
        
            return TypedResults.Ok(result);
        }

        ////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetCounterValueLessThan(int number)
        {
            var result = CounterHelper.GetCounterValueLessThan(number);

            return TypedResults.Ok(result);
        }


        //Extension #1
        //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult IncrementCounterValue(int id)
        {
            var counter = CounterHelper.GetACounterById(id);
            if (counter == null)
            {
                return TypedResults.NotFound();
            }

            CounterHelper.IncrementCounterValue(counter.Id);

            return TypedResults.Ok(counter);   
        }


        //Extension #2
        //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult DecrementCounterValue(int id)
        {
            var counter = CounterHelper.GetACounterById(id);
            if (counter == null)
            {
                return TypedResults.NotFound();
            }

            CounterHelper.DecrementCounterValue(counter.Id);

            return TypedResults.Ok(counter);
        }
    }
}
