using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface ICounterRepository
    {
        IEnumerable<Counter> GetCounters();
        Counter? GetCounter(int id);
        Counter? Increment(int id);
        Counter? Decrement(int id);
    }
}
