using System.Diagnostics.Metrics;
using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public class Repository : IRepository
    {
        public IEnumerable<Counter> GetCounters()
        {
            return CounterHelper.Counters;
        }

        public Counter GetCounterById(int id)
        {
            Counter counterValue = null;
            foreach (Counter cnt in CounterHelper.Counters)
                if (cnt.Id == id)
                {
                    counterValue = cnt;
                    break;
                }

            return counterValue;
        }

        public IEnumerable<Counter> GetCountersGreaterThan(int number)
        {       
            return CounterHelper.Counters.Where(cnt => cnt.Value > number);
        }

        public IEnumerable<Counter> GetCountersLessThan(int number)
        {
            return CounterHelper.Counters.Where(cnt => cnt.Value < number);
        }

        public Counter IncrementCounterValue(int id)
        {

            Counter selectedCounter = CounterHelper.Counters.First(cnt => cnt.Id == id);

            selectedCounter.Value += 1;

            return selectedCounter;
        }

        public Counter DecrementCounterValue(int id)
        {

            Counter selectedCounter = CounterHelper.Counters.First(cnt => cnt.Id == id);

            selectedCounter.Value -= 1;

            return selectedCounter;
        }
    }
}
