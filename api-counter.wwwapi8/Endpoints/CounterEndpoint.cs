using api_counter.wwwapi8.Helpers;

namespace api_counter.wwwapi8.Endpoints
{
    public static class CounterEndpoint
    {
        public static void CofigureCounterEndpoint(this WebApplication app)
        {

            CounterHelper.Initialize();

            var counters = app.MapGroup("/counters");
            //TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
            counters.MapGet("/", () =>
            {
                return TypedResults.Ok(CounterHelper.Counters);
            });



            //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
            counters.MapGet("/{id}", (int id) =>
            {
                var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == id);
                return TypedResults.Ok(counter);
            });

            //TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
            counters.MapGet("/greaterthan/{number}", (int number) =>
            {
                var counter = CounterHelper.Counters.Where(counter => counter.Value > number).ToList();
                return TypedResults.Ok(counter);
            });

            ////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
            counters.MapGet("/lessthan/{number}", (int number) =>
            {
                var counter = CounterHelper.Counters.Where(counter => counter.Value < number).ToList();
                return TypedResults.Ok(counter);


            });


            //Extension #1
            //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
            //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
            //return the counter you have increased
            counters.MapGet("/increment/{number}", (int number) =>
            {
                var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == number);
                counter.Value += 1;
                return TypedResults.Ok(counter);

            });



            //Extension #2
            //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
            //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
            //return the counter you have decreased

            counters.MapGet("/decrement/{number}", (int number) =>
            {
                var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == number);
                counter.Value -= 1;
                return TypedResults.Ok(counter);
            });
        }
    }
}
