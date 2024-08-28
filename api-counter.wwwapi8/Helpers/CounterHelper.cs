

using api_counter.wwwapi8.Models;

namespace api_counter.wwwapi8.Helpers
{
    public static class CounterHelper
    {

        public static void Initialize()
        {
            if (Counters.Count == 0)
            {
                Counters.Add(new Counter() { Id = 1, Name = "Books", Value = 5 });
                Counters.Add(new Counter() { Id = 2, Name = "Toys", Value = 2 });
                Counters.Add(new Counter() { Id = 3, Name = "Videogames", Value = 8 });
                Counters.Add(new Counter() { Id = 4, Name = "Pencils", Value = 3 });
                Counters.Add(new Counter() { Id = 5, Name = "Notepads", Value = 7 });
            }
        }
        public static List<Counter> Counters { get; set; } = new List<Counter>();

        public static List<Counter> GetCounters()
        {
            return Counters;
        }

        public static IResult GetACounter(int id)
        {
            var counter = Counters.FirstOrDefault(x => x.Id == id);
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        public static IResult GetGreaterThanCounter(int number)
        {
            var counter = Counters.Where(x => x.Value > number);
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        public static IResult GetLessThanCounter(int number)
        {
            var counter = Counters.Where(x => x.Value < number);
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        public static IResult GetIncreasedCounter(int id)
        {
            var counter = Counters.FirstOrDefault(x => x.Id == id);
            if (counter != null)
            {
                counter.Value++;
                return TypedResults.Ok(counter);
            }
            return TypedResults.NotFound();
        }

        public static object GetDecreasedCounter(int id)
        {
            var counter = Counters.FirstOrDefault(x => x.Id == id);
            if (counter != null)
            {
                counter.Value--;
                return TypedResults.Ok(counter);
            }
            return TypedResults.NotFound();
        }
    }
}
