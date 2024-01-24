using api_counter.wwwapi8.Data;
using api_counter.wwwapi8.Models;

namespace api_counter.wwwapi8.Repository
{
    public class CounterRepository : ICounterRepository
    {
        private CounterCollection _counters;

        public CounterRepository(CounterCollection counters)
        {
            _counters = counters;
        }

        public List<Counter> GetAllCounters()
        {
            return _counters.Counters;
        }

        public List<Counter> GetGreaterCounters(int val)
        {
            return _counters.GetGreaterCounters(val);
        }

        public List<Counter> GetLesserCounters(int val)
        {
            return _counters.GetLesserCounters(val);
        }

        public Counter Increment(int val) 
        {
            return _counters.Increment(val);
        }

        public Counter Decrement(int val)
        {
            return _counters.Decrement(val);
        }

        public Counter AddCounter(int value, string name)
        {
            return _counters.AddCounter( name, value );
        }

        public Counter? GetCounter(int id)
        {
            return _counters.GetCounter( id );
        }

        public Counter? RemoveCounter(int id)
        {
            return _counters.RemoveCounter(id);
        }

        public Counter? UpdateCounter(int id, CounterUpdatePayload data) 
        {
            var c = _counters.GetCounter( id );

            if (c == null)
            {
                return null;
            }

            bool hasval = false;
            bool hasname = false;

            if(data.value >= 0)
            {
                c.Value = (int)data.value;
                hasval = true;
            }

            if(data.name.Length > 0)
            {
                c.Name = (string)data.name;
                hasname = true;
            }

            if (!hasname || !hasval)
            {
                throw new Exception("data missing!");
            }
            return c;
        }
    }
}
