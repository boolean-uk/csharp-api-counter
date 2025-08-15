using System;
using System.Diagnostics.Metrics;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository;

public interface ICounterRepository
{
    List<Counter> Get();
    Counter GetById(int id);
    Counter Delete(int id);
    Counter Update(int id, Counter model);
}
