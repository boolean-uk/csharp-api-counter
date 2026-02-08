using api_counter.wwwapi9.Models;
using System.Data;
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

        public static List<Counter> GetCounters()
        {
            return Counters;
        }

        public static Counter GetCounter(int id)
        {
            var counter = Counters.FirstOrDefault(c => c.Id == id);

            if (counter == null)
            {
                throw new InvalidOperationException($"Counter with Id {id} not found.");
            }

            return counter;
        }

        public static List<Counter> GetCountersGreaterThan(int number)
        {
            var countersGreater = Counters.Where(c => c.Value > number).ToList();

            if (countersGreater.Count == 0)
            {
                throw new InvalidOperationException($"No counters found with a value greater than {number}.");
            }

            return countersGreater;
        }

        public static List<Counter> GetCountersLessThan(int number)
        {
            var countersLess = Counters.Where(c => c.Value < number).ToList();

            if (countersLess.Count == 0)
            {
                throw new InvalidOperationException($"No counters found with a value less than {number}.");
            }

            return countersLess;
        }

        public static Counter IncrementCounter(int id)
        {
            var counter = Counters.FirstOrDefault(c => c.Id == id);

            if (counter == null)
            {
                throw new InvalidOperationException($"Counter with Id {id} not found. Could not increment");
            }
            counter.Value++;

            return counter;
        } 

        public static Counter DecrementCounter(int id)
        {
            var counter = Counters.FirstOrDefault(c => c.Id == id);

            if (counter == null)
            {
                throw new InvalidOperationException($"Counter with Id {id} not found. Could not decrement");
            }
            counter.Value--;

            return counter;
        } 
    }
}
