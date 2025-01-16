using System.Runtime.CompilerServices;
using api_counter.wwwapi9.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi9.Endpoints
{
    public static class CounterEndpoint
    {
        public static void ConfigureCounterEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("counters");

            counters.MapGet("/", GetCounters);
            counters.MapGet("/{id}", GetCounter);
            counters.MapGet("/greaterthan/{value}", GetCountersGreaterThan);
            counters.MapGet("/lessthan/{value}", GetCountersLessThan);
            counters.MapGet("/increment/{id}", GetCounterIncrement);
            counters.MapGet("/decrement/{id}", GetCounterDecrement);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounters(IRepository repository)
        {
            return TypedResults.Ok(repository.GetCounters());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCounter(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(repository.GetCounter(id));
            } catch (InvalidOperationException)
            {
                return TypedResults.NotFound(new { Message = "Could not find a counter with that ID." });
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCountersGreaterThan(IRepository repository, int value)
        {
            return TypedResults.Ok(repository.GetCounters((counter) => counter.Value > value));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCountersLessThan(IRepository repository, int value)
        {
            return TypedResults.Ok(repository.GetCounters((counter) => counter.Value < value));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCounterIncrement(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(repository.IncrementCounter(id));
            } catch (InvalidOperationException)
            {
                return TypedResults.NotFound(new { Message = "Could not find a counter with that ID." });
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCounterDecrement(IRepository repository, int id)
        {
            try 
            {
                return TypedResults.Ok(repository.DecrementCounter(id));
            } catch (InvalidOperationException)
                {
                    return TypedResults.NotFound(new { Message = "Could not find a counter with that ID." });
                }
        }
    }
}
