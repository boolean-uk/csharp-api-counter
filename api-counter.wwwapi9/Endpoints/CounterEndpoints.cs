using api_counter.wwwapi9.Data;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_counter.wwwapi9.Endpoints
{
    public static class CounterEndpoints
    {

        public static void ConfigureCounter(this WebApplication app)
        {
            var counters = app.MapGroup("counters");

            counters.MapGet("/", GetAllCounters);
            counters.MapGet("/{id}", GetCounter);
            counters.MapGet("/greaterthan/{number}", GetGreaterThan);
            counters.MapGet("/lessthan/{number}", GetLessThan);
            counters.MapPut("/increment/{id}", IncrementCounter);
            counters.MapPut("/decrement/{id}", DecrementCounter);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllCounters()
        {
            return TypedResults.Ok(CounterHelper.Counters);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCounter(int id)
        {
            var counter = CounterHelper.Counters.Where(counter => counter.Id == id).FirstOrDefault();

            if (counter is null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(counter);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetGreaterThan(int number)
        {
            var counters = CounterHelper.Counters.Where(counter => counter.Value > number);

            return TypedResults.Ok(counters);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLessThan(int number)
        {
            var counters = CounterHelper.Counters.Where(counter => counter.Value < number);

            return TypedResults.Ok(counters);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> IncrementCounter(int id)
        {
            var counter = CounterHelper.Counters.Where(count => count.Id == id).FirstOrDefault();

            if (counter is null) { return TypedResults.NotFound(); }
            counter.Value += 1;
            return TypedResults.Ok(counter);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DecrementCounter(int id)
        {
            var counter = CounterHelper.Counters.Where(count => count.Id == id).FirstOrDefault();

            if (counter is null) { return TypedResults.NotFound(); }
            counter.Value -= 1;
            return TypedResults.Ok(counter);
        }
    }
}
