

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

        public static Counter? GetCounterById(int id)
        {
            return Counters.FirstOrDefault(x => x.Id == id);
        }

        public static List<Counter> GetCounterValueGreatherThan(int number)
        {
            return Counters.FindAll(x => x.Id > number);
        }

        public static List<Counter> GetCounterValueSmallerThan(int number)
        {
            return Counters.FindAll(x => x.Id < number);
        }

        public static Counter? Decrement(int id)
        {
            var counter = Counters.FirstOrDefault(x => x.Id == id);
            counter.Value--;
            return counter;
        }

        public static Counter? Increment(int id)
        {
            var counter = Counters.FirstOrDefault(x => x.Id == id);
            counter.Value++;
            return counter;
        }

        public static List<Counter> Counters { get; set; } = new List<Counter>();

    }
}
