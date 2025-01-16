using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Counterconfigure
{
    public static class ext
    {

        public static void Control(this WebApplication app)
        {
            var console = app.MapGroup("increase");
            console.MapGet("/{id}",inc);
            console.MapPost("/{id}/update", inc);

            var console2 = app.MapGroup("deacrease");
            console2.MapGet("/{id}", dec);
            console2.MapPost("/{id}/update", dec);


        }

        public static async Task<IResult>dec(int id)
        {
            var result = CounterHelper.Increase(id);
            return TypedResults.Ok(result);
        }

        public static async Task<IResult> inc(int id)
        {
            var result = CounterHelper.Increase(id);
            return TypedResults.Ok(result);
        }




    }
}
