using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public class Repository : IRepository
    {
        public IEnumerable<Counter> GetCounter()
        {
            return CounterHelper.Counters;
        }
    }
}
