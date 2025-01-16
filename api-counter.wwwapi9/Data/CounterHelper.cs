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


        public static List<Counter> GetAllCounters()
        {
            return Counters;
        }

        public static int GetId(Counter counter)
        {
            return counter.Id;
        }

        public static Counter GetCounterById(int id)
        {
            foreach(Counter counter in Counters)
            {
                if (id == GetId(counter))
                {
                    return counter;
                }
            }
            return null;
        }

        public static int GetCounterValue(Counter counter)
        {
            return counter.Value;
        }

        public static List<Counter> CountersGreaterThanValue(int value)
        {
            List<Counter> counters = new List<Counter>();
            foreach(Counter counter in Counters)
            {
                if (GetCounterValue(counter) > value)
                {
                    counters.Add(counter);
                }
            }

            return counters;
        }

        public static List<Counter> CountersLowerThanValue(int value)
        {
            List<Counter> counters = new List<Counter>();
            foreach (Counter counter in Counters)
            {
                if (GetCounterValue(counter) < value)
                {
                    counters.Add(counter);
                }
            }

            return counters;
        }

        public static Counter GetCounterIncrease(int id)
        {
            Counter counter = CounterHelper.GetCounterById(id);
            counter.Value += 1;
            return counter;
        }
        
        public static Counter GetCounterDecrease(int id)
        {
            Counter counter = CounterHelper.GetCounterById(id);
            counter.Value -= 1;
            return counter;
        }
    }
}
