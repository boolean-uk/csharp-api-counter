

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

        public static Counter? GetACounterById(int id)
        {
            return Counters.FirstOrDefault(c => c.Id == id);
        }

        public static List<Counter>? GetCounterValueGreaterThan(int number)
        {
            return Counters.FindAll(x => x.Value > number);
        }

        public static List<Counter>? GetCounterValueLessThan(int number)
        {
            return Counters.FindAll(x => x.Value < number);
        }

        public static Counter? IncrementCounterValue(int id)
        {
            var counter = Counters.FirstOrDefault(x => x.Id == id);
            counter.Value++;    
            return counter;
        }

        public static Counter? DecrementCounterValue(int id)
        {
            var counter = Counters.FirstOrDefault(x => x.Id == id);
            counter.Value--;
            return counter;
        }
    }

    }
