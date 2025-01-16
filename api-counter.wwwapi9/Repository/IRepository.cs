using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface IRepository
    {
        IEnumerable<Counter> GetCounters();
        Counter GetCounterById(int id);
        IEnumerable<Counter> GetCountersGreaterThan(int value);
        IEnumerable<Counter> GetCountersLessThan(int value);
        Counter IncrementCounterById(int id);
        Counter DecrementCounterById(int id);

    }
}
