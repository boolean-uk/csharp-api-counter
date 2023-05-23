using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_counter.Controllers
{
    // Object representing a counter. Based on the requirements

    [ApiController]
    [Route("[controller]")]
    public class CounterController : ControllerBase
    {
        // @TODO We need to create an object holding our counter object. The name of the object variable needs to be counter
        public Counter counter;

        // @EXTENSIONS @TODO We need to create a list holding Counter objects. The variable needs to be called counters
        public List<Counter> counters;
        public CounterController()
        {
            // @TODO create a new counter on class construction
            counter = new Counter(0);
            // @EXTENSIONS @TODO make sure you initialize the List of counters
            counters = new List<Counter>();
        }

        // @TODO Write your decorators & function here that will be called when accessing the specific endpoints.

        [HttpGet(Name = "GetCounter")]
        public Counter Get()
        {
            return counter;
        }

        [HttpGet("increment", Name = "IncrementCounter")]
        public Counter Increment()
        {
            counter.Value++;
            return counter;
        }

        [HttpGet("decrement", Name = "DecrementCounter")]
        public Counter Decrement()
        {
            counter.Value--;
            return counter;
        }

        [HttpGet("double", Name = "DoubleCounter")]
        public Counter Double()
        {
            counter.Value *= 2;
            return counter;
        }

        [HttpGet("custom/counters", Name = "Counter")]
        public List<Counter> GetCounters()
        {
            return counters;
        }

        [HttpGet("custom/{name}", Name = "Custom")]
        public Counter Custom(string name)
        {
            foreach (var item in counters)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            Counter c = new Counter(0, name);
            counters.Add(c);
            return c;
        }


        [HttpGet("custom/{name}/increment", Name = "CustomInrement")]
        public Counter CustomIncrement(string name)
        {
            foreach (var item in counters)
            {
                if (item.Name == name)
                {
                    item.Value++;
                    return item;
                }
            }
            Counter c = new Counter(1, name);
            counters.Add(c);
            return c;
        }

        [HttpGet("custom/{name}/decrement", Name = "CustomDerement")]
        public Counter CustomDecrement(string name)
        {
            foreach (Counter item in counters)
            {
                if (item.Name == name)
                {
                    item.Value--;
                    return item;
                }
            }
            Counter c = new Counter(-1, name);
            counters.Add(c);
            return c;
        }


    }
}
