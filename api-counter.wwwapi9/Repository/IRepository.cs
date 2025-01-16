using System.Diagnostics.Metrics;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface IRepository
    {
        IEnumerable<Counter> GetCounters();
        Counter GetCounterId(int id);

        Counter GreaterThan(int number);
        Counter LessThan(int number);
        Counter IncrementCounter(int number);
        Counter DecreaseCounter(int number);
    }
}
