using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public class CounterRepository : ICounterRepository
    {
        public Counter? Decrement(int id)
        {
            Counter? res = CounterHelper.Counters.Find(x => x.Id == id);
            if (res != null)
            {
                res.Value--;
                return res;
            }
            return null;
        }

        public Counter? GetCounter(int id)
        {
            return CounterHelper.Counters.Find(x => x.Id == id);
        }

        public IEnumerable<Counter> GetCounters()
        {
            return CounterHelper.Counters;
        }

        public Counter? Increment(int id)
        {
            Counter? res = CounterHelper.Counters.Find(x => x.Id == id);
            if (res != null)
                res.Value++;

            return res;
        }
    }
}
