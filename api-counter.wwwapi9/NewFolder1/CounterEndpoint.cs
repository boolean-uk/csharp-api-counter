using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi9.NewFolder1
{
    public static class CounterEndpoint
    {
        public static void ConfigureCounterEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("counters");
            counters.MapPost("/increment", IncrementCounter);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> IncrementCounter(int id)
        {
            Counter? counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == id);
            counter.Value++;
            return TypedResults.Ok(counter);
        }
        
    }
}
