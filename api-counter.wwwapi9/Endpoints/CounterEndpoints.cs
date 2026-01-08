using api_counter.wwwapi9.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi9.Endpoints
{
    public static class CounterEndpoints
    {
        public static void ConfigureCounterEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("/counters");

            counters.MapGet("/", GetCounters);
            counters.MapGet("/{id}", GetCounterById);
            counters.MapGet("/greaterthan/{value}", GetCountersGreaterThan);
            counters.MapGet("/lessthan/{value}", GetCountersLessThan);
            counters.MapPut("/increment/{id}", IncrementCounterById);
            counters.MapPut("/decrement/{id}", DecrementCounterById);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounters(IRepository repository)
        {
            return TypedResults.Ok(repository.GetCounters());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCounterById(int id, IRepository repository)
        {
            var counter = repository.GetCounterById(id);
            if (counter == null)
            {
                return TypedResults.NotFound($"Counter {id} not found.");
            }
            return TypedResults.Ok(counter);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCountersGreaterThan(int value, IRepository repository)
        {
            var counters = repository.GetCountersGreaterThan(value);
            if (counters == null || !counters.Any())
            {
                return TypedResults.NotFound($"No counters found with value greater than {value}.");
            }
            return TypedResults.Ok(counters);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCountersLessThan(int value, IRepository repository)
        {
            var counters = repository.GetCountersLessThan(value);
             if (counters == null || !counters.Any())
            {
                return TypedResults.NotFound($"No counters found with value less than {value}.");
            }
            return TypedResults.Ok(counters);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> IncrementCounterById(int id, IRepository repository)
        {
            var counter = repository.IncrementCounterById(id);
            if (counter == null)
            {
                return TypedResults.NotFound($"No counter with ID {id} found.");
            }
            return TypedResults.Ok(counter);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DecrementCounterById(int id, IRepository repository)
        {
            var counter = repository.DecrementCounterById(id);
            if (counter == null)
            {
                return TypedResults.NotFound($"No counter with ID {id} found.");
            }
            return TypedResults.Ok(counter);
        }
    }
}
