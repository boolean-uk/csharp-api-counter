using api_counter.wwwapi8.Data;
using api_counter.wwwapi8.Models;

namespace api_counter.wwwapi8.Repositories
{
    public class CounterRepository : ICounterRepository
    {

        private CounterCollection _counters;

        public CounterRepository(CounterCollection counter) {
            _counters = counter;
        }

        public Counter? DecreaseValueByOne(int _id)
        {
            return _counters.decreaseValueByOne(_id);
        }

        public List<Counter> getAllCounters()
        {
            return _counters.getAllCounters();
        }

        public List<Counter> getAllGreaterThan(int number)
        {
            return _counters.getAllGreaterThan(number);
        }

        public List<Counter> getAllLesserThan(int number)
        {
            return _counters.getAllLesserThan(number);
        }

        public Counter? getCounterById(int _id)
        {
            return _counters.getCounterById(_id);
        }

        public Counter IncreaseValueByOne(int _id)
        {
            return _counters.increaseValueByOne(_id);
        }
    }
}
