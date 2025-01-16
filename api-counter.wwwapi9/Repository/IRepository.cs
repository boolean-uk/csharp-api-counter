using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface IRepository
    {
        Counter GetCounter(int id);
        int IncrementCounter(int id);
        int DecrementCounter(int id);

        IEnumerable<Counter> GetCounters();
        IEnumerable<Counter> GetCounters(Func<Counter, bool> condition);
    }
}
