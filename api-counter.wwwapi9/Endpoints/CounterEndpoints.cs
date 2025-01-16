using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Repository;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi9.Endpoints
{
    public static class CounterEndpoints
    {
        public static void ConfigureCounterEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("counters");

            counters.MapGet("/", GetCounters);
            counters.MapGet("/{id}", GetCounterById);
            counters.MapGet("/greaterthan/{number}", GetCountersGreaterThan);
            counters.MapGet("/lessthan/{number}", GetCountersLessThan);
            counters.MapGet("/increment/{id}", IncrementCounterValue);
            counters.MapGet("/decrement/{id}", DecrementCounterValue);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounters(IRepository repository)
        {
            return TypedResults.Ok(repository.GetCounters());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounterById(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetCounterById(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCountersGreaterThan(IRepository repository, int number)
        {
            return TypedResults.Ok(repository.GetCountersGreaterThan(number));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCountersLessThan(IRepository repository, int number)
        {
            return TypedResults.Ok(repository.GetCountersLessThan(number));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> IncrementCounterValue(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.IncrementCounterValue(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DecrementCounterValue(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.DecrementCounterValue(id));
        }
    }
}
