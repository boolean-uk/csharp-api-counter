using System;
using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository;

public class CounterRepository : ICounterRepository
{
    public Counter Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Counter> Get()
    {
        return CounterHelper.Counters;
    }

    public Counter GetById(int id)
    {
        return CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
    }

    public Counter Update(int id, Counter model)
    {
        throw new NotImplementedException();
    }
}
