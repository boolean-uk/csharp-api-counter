using api_counter.wwwapi8.Models;

namespace api_counter.wwwapi8.Repository
{
    public interface ICounterRepository
    {
        public List<Counter> GetAllCounters();

        public Counter? GetCounter(int id);

        public Counter? RemoveCounter(int id);

        public Counter AddCounter(int value, string name);

        public Counter? UpdateCounter(int id, CounterUpdatePayload newData);

        public Counter? Increment(int id);

        public Counter? Decrement(int id);

        public List<Counter> GetGreaterCounters(int val);

        public List<Counter> GetLesserCounters(int val);
    }
}
