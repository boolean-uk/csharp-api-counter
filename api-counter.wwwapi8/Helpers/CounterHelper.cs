

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

        public static Counter GetCounterByID(int id ) 
        {
            Counter counter = Counters.FirstOrDefault(x => x.Id == id);

            return counter;
        }

        public static List<Counter> CountersGreaterThan(int number)
        {
            List<Counter> list = (List<Counter>)Counters.Where(x => x.Value > number).ToList();
            return list;
        }

        public static List<Counter> LessThan(int number)
        {
            List<Counter> list = (List<Counter>)Counters.Where(x => x.Value < number).ToList();
            return list;
        }

        public static Counter Increment(int id)
        {
            Counter counter = GetCounterByID(id);
            counter.Value++;
            return counter;
        }

        public static Counter Decrement(int id)
        {
            Counter counter = GetCounterByID(id);
            counter.Value--;
            return counter;
        }
    }
}
