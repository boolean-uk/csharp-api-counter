using api_counter.wwwapi8.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_counter.wwwapi8.EndPoints
{
    public static class CounterEndpoints
    {
        public static void ConfigureCounterEndpoints(this WebApplication app)
        {
            var counters = app.MapGroup("/counters");
            counters.MapGet("/", GetAllCounters);
            counters.MapGet("/{id}", GetCounterById);
            counters.MapGet("/greatherthan/{number}", GetCounterValueGreatherThan);
            counters.MapGet("/smallerthan/{number}", GetCounterValueSmallerThan);
            counters.MapGet("/decrement/{id}", Decrement);
            counters.MapGet("/increment/{id}", Increment);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static IResult Increment(int id)
        {
            var counter = CounterHelper.Increment(id);

            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static IResult Decrement(int id)
        {
            var counter = CounterHelper.Decrement(id);

            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetCounterValueSmallerThan(int number)
        {
            var counter = CounterHelper.GetCounterValueSmallerThan(number);

            return TypedResults.Ok(counter);
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetCounterValueGreatherThan(int number)
        {
            var counter = CounterHelper.GetCounterValueGreatherThan(number);

            return TypedResults.Ok(counter);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static IResult GetCounterById(int id)
        {
            var counter = CounterHelper.GetCounterById(id);
            return counter != null? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllCounters()
        {
            return TypedResults.Ok(CounterHelper.Counters);
        }
    }
       
}
