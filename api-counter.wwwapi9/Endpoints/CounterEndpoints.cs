using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_counter.wwwapi9.Endpoints
{
    public static class CounterEndpoints
    {
        public static void ConfigureCounterEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("counters");

            counters.MapGet("/", GetCounter);
            counters.MapGet("/{id}", GetCounterById);
            counters.MapGet("/greaterthan/{number}", GetCounterGreaterThan);
            counters.MapGet("/lessthan/{number}", GetCounterLessThan);
            counters.MapGet("/increment/{id}", IncrementCounter);
            counters.MapGet("/decrement/{id}", DecrementCounter);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounter(IRepository repository)

        {
            return TypedResults.Ok(repository.GetCounter());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounterById(int id, IRepository repository)

        {
            return TypedResults.Ok(repository.GetCounter().FirstOrDefault(i => i.Id == id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounterGreaterThan(int number, IRepository repository)

        {
            return TypedResults.Ok(repository.GetCounter().Where(i => i.Id > number));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounterLessThan(int number, IRepository repository)

        {
            return TypedResults.Ok(repository.GetCounter().Where(i => i.Id < number));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> IncrementCounter(int id, IRepository repository)

        {
            var index = CounterHelper.Counters.FindIndex(i => i.Id == id);
            CounterHelper.Counters[index].Value++;
            return TypedResults.Ok(repository.GetCounter().FirstOrDefault(i => i.Id == id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DecrementCounter(int id, IRepository repository)

        {
            var index = CounterHelper.Counters.FindIndex(i => i.Id == id);
            CounterHelper.Counters[index].Value--;
            return TypedResults.Ok(repository.GetCounter().FirstOrDefault(i => i.Id == id));
        }

    }
}
