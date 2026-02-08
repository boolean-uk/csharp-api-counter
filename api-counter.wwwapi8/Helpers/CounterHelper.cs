

using api_counter.wwwapi8.Models;

namespace api_counter.wwwapi8.Helpers
{
    public static class CounterHelper
    {
        private static List<Counter> _counters = new List<Counter>();
        public static void Initialize()
        {
            if (_counters.Count == 0)
            {
                _counters.Add(new Counter() { Id = 1, Name = "Books", Value = 5 });
                _counters.Add(new Counter() { Id = 2, Name = "Toys", Value = 2 });
                _counters.Add(new Counter() { Id = 3, Name = "Videogames", Value = 8 });
                _counters.Add(new Counter() { Id = 4, Name = "Pencils", Value = 3 });
                _counters.Add(new Counter() { Id = 5, Name = "Notepads", Value = 7 });
            }
        }

        public static List<Counter> GetCounters()
        {
            return _counters;
        }

        public static Counter? GetACounter(int id)
        {
            return _counters.FirstOrDefault(c => c.Id == id);
        }

        public static List<Counter> GetGreaterThan(int number)
        {
            return _counters.Where(c => c.Value > number).ToList();
        }

        public static List<Counter> GetLesserThan(int number)
        {
            return _counters.Where(c => c.Value < number).ToList();
        }
    }
}
