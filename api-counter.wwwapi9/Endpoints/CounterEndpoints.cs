using api_counter.wwwapi9.Repositories;

namespace api_counter.wwwapi9.Endpoints
{
    public static class CounterEndpoints
    {
        public static void ConfigureCarEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("counters");
            counters.MapGet("/", GetCounters);
            counters.MapGet("/{id}", GetCounterById);
            counters.MapGet("/greaterthan/{number}", GetCountersGreaterThan);
            counters.MapGet("/lessthan/", GetCountersLessThan);
            counters.MapPost("/increment/{id}", IncrementCounterByID);
            counters.MapPost("/decrement/{id}", DecrementCounterByID);

        }

        public static async Task<IResult> GetCounters(IRepository repository)
        {
            return TypedResults.Ok(repository.GetCounters());
        }
        public static async Task<IResult> GetCounterById(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetCounterById(id));
        }
        public static async Task<IResult> GetCountersGreaterThan(IRepository repository, int value)
        {
            return TypedResults.Ok(repository.GetCountersGreaterThan(value));
        }
        public static async Task<IResult> GetCountersLessThan(IRepository repository, int value)
        {
            return TypedResults.Ok(repository.GetCountersLessThan(value));
        }
        public static async Task<IResult> IncrementCounterByID(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.IncrementCounterByID(id));
        }
        public static async Task<IResult> DecrementCounterByID(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.DecrementCounterByID(id));
        }
    }
}
