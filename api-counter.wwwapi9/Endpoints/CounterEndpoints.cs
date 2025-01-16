using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Endpoints
{
    public static class CounterEndpoints
    {

        public static void CounterConfiguration(this WebApplication app)
        {
            //Tested with Scalar, works
            var applicationincrease = app.MapGroup("countersincrease");
            applicationincrease.MapGet("/{id}", (int id) => GetCounter(id));
            applicationincrease.MapPost("/{id}", (int id) => IncreasedCounter(id));

            var applicationdecrease = app.MapGroup("countersdecrease");
            applicationdecrease.MapGet("/{id}", (int id) => GetCounter(id));
            applicationdecrease.MapPost("/{id}", (int id) => DecreasedCounter(id));
            
        }

        public static async Task<IResult> GetCounter(int id)
        {
            var result = CounterHelper.GetCounterById(id);
            return TypedResults.Ok(result);
        }

        public static async Task<IResult> IncreasedCounter(int id)
        {
            var result = CounterHelper.GetCounterIncrease(id);
            return TypedResults.Ok(result);
        }

        public static async Task<IResult> DecreasedCounter(int id)
        {
            var result = CounterHelper.GetCounterDecrease(id);
            return TypedResults.Ok(result);
        }
    }
}
