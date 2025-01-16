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
            counters.MapGet("/greaterthan/{number}", GetCountersGreaterThan);
            counters.MapGet("/lessthan/{number}", GetCountersLessThan);
            counters.MapPost("/increment", PostCounterIncrement);
            counters.MapPost("/decrement", PostCounterDecrement);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounters(IRepository repository)
        {
            return TypedResults.Ok(repository.GetCounters());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounter(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetCounter(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCountersGreaterThan(IRepository repository, int value)
        {
            return TypedResults.Ok(repository.GetCounters((counter) => counter.Value > value));
        }

        public static async Task<IResult> GetCountersLessThan(IRepository repository, int value)
        {
            return TypedResults.Ok(repository.GetCounters((counter) => counter.Value < value));
        }

        public static async Task<IResult> PostCounterIncrement(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.IncrementCounter(id));
        }

        public static async Task<IResult> PostCounterDecrement(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.DecrementCounter(id));
        }
    }
}
