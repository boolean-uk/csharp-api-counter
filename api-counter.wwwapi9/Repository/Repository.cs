using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public class Repository : IRepository
    {
       

        public Counter GetCounterById(int id)
        {
            return CounterHelper.Counters.FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<Counter> GetCounters()
        {
            return CounterHelper.Counters;
        }

        public IEnumerable<Counter> GetCountersGreaterThan(int value)
        {
            return CounterHelper.Counters.Where(x => x.Value > value);
        }

        public IEnumerable<Counter> GetCountersLessThan(int value)
        {
            return CounterHelper.Counters.Where(x => x.Value < value);
        }

        public Counter IncrementCounterById(int id)
        {
            Counter counter = GetCounterById(id);
            if (counter != null) 
            {
                counter.Value++;
                return counter;
            }
            return null;
        }

        public Counter DecrementCounterById(int id)
        {
            Counter counter = GetCounterById(id);
            if (counter != null)
            {
                counter.Value--;
                return counter;
            }
            return null;
        }
    }
}
