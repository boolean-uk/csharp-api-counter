using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repositories
{
    public class CounterRepository : IRepository
    {
       

        public Counter GetCounterById(int id)
        {
            return CounterHelper.GetCounterById(id);
        }

        public List<Counter> GetCounters()
        {
            return CounterHelper.Counters;
        }

        public List<Counter> GetCountersGreaterThan(int value)
        {
            return CounterHelper.GetCountersGreaterThan(value);
        }

        public List<Counter> GetCountersLessThan(int value)
        {
            return CounterHelper.GetCountersLessThan(value);
        }

        public Counter IncrementCounterByID(int id)
        {
            return CounterHelper.IncrementCounterById(id);
        }
        public Counter DecrementCounterByID(int id)
        {
            return CounterHelper.DecrementCounterById(id);
        }
    }
}
