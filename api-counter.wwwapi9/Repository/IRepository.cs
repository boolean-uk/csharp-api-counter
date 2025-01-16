using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface IRepository
    {
        IEnumerable<Counter> GetCounter();
    }
}
