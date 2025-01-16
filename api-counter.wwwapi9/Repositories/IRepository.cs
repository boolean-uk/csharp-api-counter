using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repositories
{
    public interface IRepository
    {
        Counter GetCounterById(int id);
        List<Counter> GetCounters();
        List<Counter> GetCountersGreaterThan(int value);
        List<Counter> GetCountersLessThan(int value);
        Counter IncrementCounterByID(int id);
        Counter DecrementCounterByID(int id);

    }
}
