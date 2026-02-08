using System.Diagnostics.Metrics;
using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public class Repository : IRepository
    {
        

        public int GetId(Counter counter)
        {
            return counter.Id;
        }

        public Counter GetCounterById(int id)
        {
            foreach (Counter counter in CounterHelper.Counters)
            {
                if (id == counter.Id)
                {
                    return counter;
                }
            }
            return null;
        }

        public int GetCounterValue(Counter counter)
        {
            return counter.Value;
        }

        public List<Counter> CountersGreaterThanValue(int value)
        {
            List<Counter> counters = new List<Counter>();
            foreach (Counter counter in CounterHelper.Counters)
            {
                if (GetCounterValue(counter) > value)
                {
                    counters.Add(counter);
                }
            }

            return counters;
        }

        public List<Counter> CountersLowerThanValue(int value)
        {
            List<Counter> counters = new List<Counter>();
            foreach (Counter counter in CounterHelper.Counters)
            {
                if (GetCounterValue(counter) < value)
                {
                    counters.Add(counter);
                }
            }

            return counters;
        }

        public Counter GetCounterIncrease(int id)
        {
            Counter counter = GetCounterById(id);
            counter.Value += 1;
            return counter;
        }

        public Counter GetCounterDecrease(int id)
        {
            Counter counter = GetCounterById(id);
            counter.Value -= 1;
            return counter;
        }

        public void AddCounter(Counter counter)
        {
            CounterHelper.Counters.Add(counter);
        }
    }
}
