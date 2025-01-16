using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;
using api_counter.wwwapi9.Repository;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace api_counter.wwwapi9.Endpoints
{
    public static class CounterEndpoints
    {
        
        public static void CounterConfiguration(this WebApplication app)
        {

           
            //Tested with Scalar, works
            var applicationincrease = app.MapGroup("countersincrease");
            applicationincrease.MapGet("/{id}", IncreasedCounter);
            applicationincrease.MapPost("/{id}", IncreasedCounter);

            var applicationdecrease = app.MapGroup("countersdecrease");
            applicationdecrease.MapGet("/{id}",DecreasedCounter);
            applicationdecrease.MapPost("/{id}", DecreasedCounter);

            var counters = app.MapGroup("/counters");
            counters.MapGet("/", () =>
            {
                IEnumerable<Counter> counters = CounterHelper.Counters;
                return TypedResults.Ok(counters);
            });


            //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
            counters.MapGet("/{id}", GetCounter);

            //TODO: 3.  write another method that returns counters that have a value greater than the {number} passed in.        
            counters.MapGet("/greaterthan/{number}", CountersGreaterThanValue);

            counters.MapGet("/lowerthan/{number}", CountersLowerThanValue);
            ////TODO:4. write another method that returns counters that have a value less than the {number} passed in.

          
        }

        public static async Task<IResult> CountersGreaterThanValue(IRepository repository, int number)
        {
            var result = repository.CountersGreaterThanValue(number);
            return TypedResults.Ok(result);
        }

        public static async Task<IResult> CountersLowerThanValue(IRepository repository, int number)
        {
            var result = repository.CountersLowerThanValue(number);
            return TypedResults.Ok(result);
        }


        public static async Task<IResult> GetCounter(IRepository repository, int id)
        {
            var result = repository.GetCounterById(id);
            return TypedResults.Ok(result);
        }

        public static async Task<IResult> IncreasedCounter(IRepository repository, int id)
        {
            
            var result = repository.GetCounterIncrease(id);
            return TypedResults.Ok(result);
        }

        public static async Task<IResult> DecreasedCounter(IRepository repository, int id)
        {
            var result = repository.GetCounterDecrease(id);
            return TypedResults.Ok(result);
        }

       
        //TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
        
    }
}
