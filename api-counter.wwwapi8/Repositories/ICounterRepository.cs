
using api_counter.wwwapi8.Models;
using api_counter.wwwapi8.Data;

namespace api_counter.wwwapi8.Repositories
{
    public interface ICounterRepository
    {
        public List<Counter> getAllCounters();
        public Counter getCounterById(int _id);
        public List<Counter> getAllGreaterThan(int number);
        public List<Counter> getAllLesserThan(int number);
        public Counter IncreaseValueByOne(int _id);
        public Counter DecreaseValueByOne(int _id);
    }
}
