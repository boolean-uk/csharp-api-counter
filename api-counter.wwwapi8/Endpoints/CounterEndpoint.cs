using api_counter.wwwapi8.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi8.Endpoints
{
    public static class CounterEndpoint
    {
        public static void ConfigureCounterEndpoint(this WebApplication app)
        {
            CounterHelper.Initialize();
            var counters = app.MapGroup("counters");
            counters.MapGet("/", GetAllCounters);
            counters.MapGet("/{id}", GetACounter);
            counters.MapGet("greaterThan/{number}", GetCountersGreaterThan);
            counters.MapGet("lesserThan/{number}", GetCountersLesserThan);
            counters.MapGet("icrementByOne/{id}", IncrementByOne);
            counters.MapGet("decrementByOne/{id}", DecrementByOne);
        }

        //TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllCounters()
        {
            return TypedResults.Ok(CounterHelper.GetCounters());
        }

        //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetACounter(int id)
        {
            var counter = CounterHelper.GetACounter(id);
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound("Counter not found");
        }

        //TODO: 3.  write another method that returns counters that have a value greater than the {number} passed in.        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetCountersGreaterThan(int number)
        {
            var counters = CounterHelper.GetGreaterThan(number);
            return counters.Count > 0 ? TypedResults.Ok(counters) : TypedResults.NotFound($"No counters greater than {number} found");
        }

        ////TODO:4. write another method that returns counters that have a value less than the {number} passed in.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetCountersLesserThan(int number)
        {
            var counters = CounterHelper.GetLesserThan(number);
            return counters.Count() > 0 ? TypedResults.Ok(counters) : TypedResults.NotFound($"No counters lesser than {number} found");
        }

        //Extension #1
        //TODO:  1. Write a method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult IncrementByOne(int id)
        {
            var counter = CounterHelper.GetACounter(id);

            if (counter is null)
            {
                return TypedResults.NotFound();
            }

            counter.Value++;

            return TypedResults.Ok(counter);
        }

        //Extension #2
        //TODO: 2. Write a method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult DecrementByOne(int id)
        {
            var counter = CounterHelper.GetACounter(id);

            if (counter is null)
            {
                return TypedResults.NotFound();
            }
            else if (counter.Value <= 0)
            {
                return TypedResults.BadRequest($"Counter value is {counter.Value} and can't be decremented");
            }

            counter.Value--;

            return TypedResults.Ok(counter);
        }
    }
}
