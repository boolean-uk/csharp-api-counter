using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public class Repository : IRepository
    {
        public Counter GetCounterId(int id)
        {
            return CounterHelper.Counters[id - 1];
        }

        public IEnumerable<Counter> GetCounters()
        {
            return CounterHelper.Counters;
        }

        public Counter GreaterThan(int number)
        {
            return CounterHelper.Counters.First(x => x.Value > number);
        }

        public Counter LessThan(int number)
        {
            return CounterHelper.Counters.First(x => x.Value < number);
        }

        public Counter IncrementCounter(int number)
        {
            Counter c = CounterHelper.Counters.First(x => x.Id == number);
            c.Value++;
            return c;
        }

        public Counter DecreaseCounter(int number)
        {
            Counter c = CounterHelper.Counters.First(x => x.Id == number);
            c.Value--;
            return c;
        }
    }
}
