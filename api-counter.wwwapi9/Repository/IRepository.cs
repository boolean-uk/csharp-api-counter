using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface IRepository
    {
        Counter GetCounter(int id);
        Counter IncrementCounter(int id);
        Counter DecrementCounter(int id);

        IEnumerable<Counter> GetCounters();
        IEnumerable<Counter> GetCounters(Func<Counter, bool> condition);
    }
}
