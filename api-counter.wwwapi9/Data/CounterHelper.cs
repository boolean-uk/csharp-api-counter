using api_counter.wwwapi9.Models;
using System.Diagnostics.Metrics;

namespace api_counter.wwwapi9.Data
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

        public static Counter GetCounterById(int id)
        {
            return Counters.FirstOrDefault(c => c.Id == id);
        }

        public static List<Counter> GetCountersGreaterThan(int number)
        {
            return Counters.Where(c => c.Value > number).ToList();
        }

        public static List<Counter> GetCountersLessThan(int number)
        {
            return Counters.Where(c => c.Value < number).ToList();
        }

        public static Counter IncrementCounterById(int id)
        {
            var counter = GetCounterById(id);
            if (counter != null)
            {
                counter.Value++;
            }
            return counter;
        }

        public static Counter DecrementCounterById(int id)
        {
            var counter = GetCounterById(id);
            if (counter != null)
            {
                counter.Value--;
            }
            return counter;
        }
    }
}
