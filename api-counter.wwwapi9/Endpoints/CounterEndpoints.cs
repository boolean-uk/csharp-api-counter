using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using api_counter.wwwapi9.Data;

namespace api_counter.wwwapi9.Endpoints;

public static class CounterEndpoints
{
    public static void ConfigureCounter(this WebApplication app)
    {
        var counters = app.MapGroup("counter");

        counters.MapGet("/", GetCounters);
        counters.MapGet("/{id}", GetCounter);
        counters.MapGet("/greaterthan/{number}", GetCounterGreaterThan);
        counters.MapGet("/lesserthan/{number}", GetCounterLesserThan);

        counters.MapPut("/increment/{id}", IncrementCounter);
        counters.MapPut("/decrement/{id}", DecrementCounter);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static IResult GetCounters()
    {
        return TypedResults.Ok(CounterHelper.Counters);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult GetCounter(int id)
    {
        var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
        return counter == null ? TypedResults.NotFound() : TypedResults.Ok(counter);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static IResult GetCounterGreaterThan(int number)
    {
        return TypedResults.Ok(CounterHelper.Counters.Where(c => c.Value > number));
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static IResult GetCounterLesserThan(int number)
    {
        return TypedResults.Ok(CounterHelper.Counters.Where(c => c.Value < number));
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult IncrementCounter(int id)
    {
        var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
        if (counter == null) return TypedResults.NotFound();
        
        counter.Value++;
        return TypedResults.Ok(counter);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult DecrementCounter(int id)
    {
        var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
        if (counter == null) return TypedResults.NotFound();
        
        counter.Value--;
        return TypedResults.Ok(counter);
    }
}