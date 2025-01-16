using api_counter.wwwapi9.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
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

        public static Counter getCounter(int id)
        {
            foreach (Counter c in Counters)
            {
                if (c.Id == id)
                {
                    return c;
                
                }
            
            }

            return null;
        }

        public static List<Counter> GreaterThan(int number)
        {
            List<Counter> Clist = new List<Counter>();
            foreach (Counter c in Counters)
            {
                if (c.Value > number)
                {
                    Clist.Add(c);

                }

            }

            return Clist;

        }

        public static List<Counter> LowerThan(int number)
        {
            List<Counter> Clist = new List<Counter>();
            foreach (Counter c in Counters)
            {
                if (c.Value < number)
                {
                    Clist.Add(c);

                }

            }

            return Clist;

        }

        public static Counter Increase(int id)
        {
            Counter counter = CounterHelper.getCounter(id);
            counter.Value += 1;
            return counter;

        }
        public static Counter Decrease(int id)
        {
            Counter counter = CounterHelper.getCounter(id);
            counter.Value -= 1;
            return counter;

        }

    }
}
