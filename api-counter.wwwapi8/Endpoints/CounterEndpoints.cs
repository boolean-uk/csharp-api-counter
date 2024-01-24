using api_counter.wwwapi8.Models;
using api_counter.wwwapi8.Repository;
using static System.Reflection.Metadata.BlobBuilder;

namespace api_counter.wwwapi8.Endpoints
{
    public static class CounterEndpoints
    {
        public static void ConfigureEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("counters");
            group.MapGet("/", GetAllCounters);
            group.MapGet("/greaterthan/{val}", GetGreaterCounters);
            group.MapGet("/lesserthan/{val}", GetLesserCounters);
            group.MapPost("/", CreateCounter);
            group.MapGet("/{id}", GetCounter);
            group.MapPut("/{id}", UpdateCounter);
            group.MapPut("/increment/{id}", IncrementCounter);
            group.MapPut("/decrement/{id}", DecrementCounter);
            group.MapDelete("/{id}", DeleteCounter);
        }
        public static IResult GetAllCounters(ICounterRepository counters)
        {
            return TypedResults.Ok(counters.GetAllCounters());
        }

        public static IResult GetGreaterCounters(ICounterRepository counters, int val)
        {
            return TypedResults.Ok(counters.GetGreaterCounters(val));
        }

        public static IResult GetLesserCounters(ICounterRepository counters, int val)
        {
            return TypedResults.Ok(counters.GetLesserCounters(val));
        }

        public static IResult GetCounter(ICounterRepository counters, int id)
        {
            try
            {
                Counter c = counters.GetCounter(id);
                if (c == null)
                {
                    return Results.NotFound($"Counter with id {id} not found.");
                }
                return Results.Ok(c);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static IResult DeleteCounter(ICounterRepository counters, int id)
        {
            try
            {
                Counter c = counters.RemoveCounter(id);
                if (c == null)
                {
                    return Results.NotFound($"Counter with id {id} not found.");
                }
                return Results.Ok(c);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static IResult CreateCounter(ICounterRepository counters, CounterPostPayload newData)
        {
            if (newData.name.Length == 0 || newData.value < 0 )
            {
                return Results.NotFound($"Counter needs all the fields provided to be created!");
            }

            Counter c = counters.AddCounter(newData.value, newData.name);
            return TypedResults.Created($"/tasks{c.Id}", c);
        }

        public static IResult UpdateCounter(ICounterRepository counters, int id, CounterUpdatePayload updateData)
        {
            try
            {
                Counter? c = counters.UpdateCounter(id, updateData);
                if (c == null)
                {
                    return Results.NotFound($"Counter with id {id} not found.");
                }
                return Results.Ok(c);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static IResult IncrementCounter(ICounterRepository counters, int id)
        {
            try
            {
                Counter? c = counters.Increment(id);
                if (c == null)
                {
                    return Results.NotFound($"Counter with id {id} not found.");
                }
                return Results.Ok(c);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static IResult DecrementCounter(ICounterRepository counters, int id)
        {
            try
            {
                Counter? c = counters.Decrement(id);
                if (c == null)
                {
                    return Results.NotFound($"Counter with id {id} not found.");
                }
                return Results.Ok(c);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }
    }
}
