using System.Runtime.CompilerServices;
using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;
using api_counter.wwwapi9.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi9.NewFolder
{
    public static class CounterEndpoint
    {
        public static void ConfigureCounterEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("/counters");

            counters.MapGet("/", GetCounter);
            counters.MapGet("/{id}", GetCounterId);
            counters.MapGet("/greaterthan/{number}", GreaterThan);
            counters.MapGet("/lessthan/{number}", LessThan);
            counters.MapGet("{number}/increment", IncrementCounter);
            counters.MapGet("{number}/decrease", DecreaseCounter);

        }

        public static async Task<IResult> GetCounter(IRepository repository)
        {
            return TypedResults.Ok(repository.GetCounters());
        }

        
        public static async Task<IResult> GetCounterId(IRepository repository, [FromRoute]int id)
        {
            
            return TypedResults.Ok(repository.GetCounterId(id));
        }

        public static async Task<IResult> GreaterThan(IRepository repository, [FromRoute]int number)
        {
            return TypedResults.Ok(repository.GreaterThan(number));
        }

        public static async Task<IResult> LessThan(IRepository repository, [FromRoute] int number)
        {
            return TypedResults.Ok(repository.LessThan(number));
        }

        public static async Task<IResult> IncrementCounter(IRepository repository, [FromRoute] int number)
        { 
            return TypedResults.Ok(repository.IncrementCounter(number));
        }

        public static async Task<IResult> DecreaseCounter(IRepository repository, [FromRoute] int number)
        {
            return TypedResults.Ok(repository.DecreaseCounter(number));
        }

    }
}
