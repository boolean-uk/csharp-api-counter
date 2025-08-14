using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface IRepository
    {
        List<Counter> GetCounters();
        CounterHelper GetCounter(int id);
        CounterHelper GreaterThan(int value);
        CounterHelper LessThan(int value);
        CounterHelper Increment(int id);
        CounterHelper Decrement(int id);
    }
}
