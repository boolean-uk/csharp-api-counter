using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public class Repository : IRepository
    {
        public CounterHelper Decrement(int id)
        {
            throw new NotImplementedException();
        }

        public CounterHelper GetCounter(int id)
        {
            throw new NotImplementedException();
        }

        public List<Counter> GetCounters()
        {
            throw new NotImplementedException();
        }

        public CounterHelper GreaterThan(int value)
        {
            throw new NotImplementedException();
        }

        public CounterHelper Increment(int id)
        {
            throw new NotImplementedException();
        }

        public CounterHelper LessThan(int value)
        {
            throw new NotImplementedException();
        }
    }
}
