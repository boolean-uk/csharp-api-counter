
using api_counter.wwwapi8.Models;

namespace api_counter.wwwapi8.Data
{
    public class CounterCollection
    {

        private List<Counter> _counters;
        private int _id = 0;


        public CounterCollection() {

            _counters = new List<Counter>()
            {
                new Counter() { Id = getNextId(), Name = "Books", Value = 5 },
                new Counter() { Id = getNextId(), Name = "Toys", Value = 2 },
                new Counter() { Id = getNextId(), Name = "Videogames", Value = 8 },
                new Counter() { Id = getNextId(), Name = "Pencils", Value = 3 },
                new Counter() { Id = getNextId(), Name = "Notepads", Value = 7 }
            };
        }

        private int getNextId()
        {
            return _id++;
        }

        public List<Counter> getAllCounters()
        {
            return _counters;
        }

        public Counter? getCounterById(int _id)
        {
            return _counters.Find(c => c.Id == _id);
        }

        public List<Counter> getAllGreaterThan(int number)
        {
            List<Counter> result = new List<Counter>();
            foreach (Counter counter in _counters)
            {
                if (counter.Value > number)
                {
                    result.Add(counter);
                }
            }
            return result;
        }

        public List<Counter> getAllLesserThan(int number)
        {
            List<Counter> result = new List<Counter>();
            foreach(Counter counter in _counters)
            {
                if (counter.Value < number)
                {
                    result.Add(counter);
                }
            }
            return result;
        }

        public Counter? increaseValueByOne(int _id)
        {
            Counter? counter = getCounterById(_id);
            if (counter != null)
            {
                counter.Value++;
                return counter;
            } else
            {
                throw new InvalidOperationException($"id: {_id} is not found");
            }
        }

        public Counter? decreaseValueByOne(int _id)
        {
            Counter? counter = getCounterById(_id); 
            if (counter != null) {
                counter.Value--;
                return counter;
            } else
            {
                throw new Exception($"id: {_id} is not found");
            }
        }
        
    }
}
