using System.Diagnostics.Metrics;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface IRepository
    { 
        void AddCounter(Counter counter);
        Counter GetCounterById(int id);
        int GetCounterValue(Counter counter);

        List<Counter> CountersGreaterThanValue(int value);
        List<Counter> CountersLowerThanValue(int value);
        Counter GetCounterIncrease(int id);
        Counter GetCounterDecrease(int id);
        


    }
}
