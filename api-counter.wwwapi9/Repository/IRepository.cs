using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface IRepository
    {
        IEnumerable<Counter> GetCounters();
        Counter GetCounterById(int id);
        IEnumerable<Counter> GetCountersGreaterThan(int number);
        IEnumerable<Counter> GetCountersLessThan(int number);
        Counter IncrementCounterValue(int id);
        Counter DecrementCounterValue(int id);
    }
}
