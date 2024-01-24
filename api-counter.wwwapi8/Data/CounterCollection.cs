using api_counter.wwwapi8.Models;

namespace api_counter.wwwapi8.Data
{
    public class CounterCollection
    {
        public List<Counter> Counters { get; set; }
        public int _id = 0;

        public CounterCollection()
        {
            Counters = new List<Counter>();
            AddCounter("Books", 5);
            AddCounter("Toys", 2);
            AddCounter("Videogames", 8);
            AddCounter("Pencils", 3);
            AddCounter("Notepads", 7);

        }

        public Counter AddCounter(string name, int value)
        {
            _id++;
            var newCounter = new Counter() { Id = _id, Name = name, Value = value };
            Counters.Add(newCounter);
            return newCounter;
        }

        public List<Counter> GetAllCounters()
        {
            return Counters;
        }

        public List<Counter> GetGreaterCounters(int val)
        {
            return Counters.FindAll(x => x.Value > val);
        }

        public List<Counter> GetLesserCounters(int val)
        {
            return Counters.FindAll(x => x.Value < val);
        }

        public Counter? GetCounter(int id)
        {
            return Counters.FirstOrDefault(c => c.Id == id);
        }

        public Counter? Increment(int id)
        {
            Counter c = Counters.FirstOrDefault(c => c.Id == id);
            if (c == null)
            {
                return c;
            }
            c.Value++;
            return c;

        }

        public Counter? Decrement(int id)
        {
            Counter c = Counters.FirstOrDefault(c => c.Id == id);
            if (c == null)
            {
                return c;
            }
            c.Value--;
            return c;

        }

        public Counter? RemoveCounter(int id)
        {
            Counter c = Counters.FirstOrDefault(c => c.Id == id);
            Counters.Remove(c);
            return c;
        }
    }
}
