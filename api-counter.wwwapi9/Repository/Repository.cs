using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public class Repository : IRepository
    {

        public Counter GetCounter(int id)
        {
            return GetCounterById(id);
        }

        public IEnumerable<Counter> GetCounters()
        {
            return CounterHelper.Counters;
        }

        public IEnumerable<Counter> GetCounters(Func<Counter, bool> condition)
        {
            return CounterHelper.Counters.Where(condition);
        }

        public Counter IncrementCounter(int id)
        {
            Counter counter = GetCounterById(id);
            counter.Value++;
            return counter;
        }
        public Counter DecrementCounter(int id)
        {
            Counter counter = GetCounterById(id);
            counter.Value--;
            return counter;
        }

        private Counter GetCounterById(int id) 
        {
            return CounterHelper.Counters.Where(x => x.Id == id).First();
        }
    }
}
