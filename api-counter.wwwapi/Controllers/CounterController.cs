using api_counter.wwwapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi.Controllers
{
    // KK: [ApiController] and [Route("[controller]")]
    //are attributes that help define the base route for your controller.

    [Route("[controller]")]
    [ApiController]
    [Route("counters")]
    public class CounterController : ControllerBase
    {
        // KK: This is the same as in 8 -> static variable to get counters objects.
        public static List<Counter> counters = new List<Counter>();


        public CounterController()
        {
            // Kanthee: This is basically just initilizing.
            if (counters.Count == 0)
            {
                counters.Add(new Counter() { Id = 1, Name = "Books", Value = 5 });
                counters.Add(new Counter() { Id = 2, Name = "Toys", Value = 2 });
                counters.Add(new Counter() { Id = 3, Name = "Videogames", Value = 8 });
                counters.Add(new Counter() { Id = 4, Name = "Pencils", Value = 3 });
                counters.Add(new Counter() { Id = 5, Name = "Notepads", Value = 7 });
            }
        }


        //TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
        [HttpGet] // KK: This is just naming?
        // KK: Wiuth async method -> can perform other tasks while waiting. (Can use "await" to indicate that program should
        // wait for the completion of a specific asynchronous operation)
        public async Task<IResult> GetAllCounters()
        {
            var allCounters = CounterController.counters;

            //return TypedResults.Ok(counters);

            return TypedResults.Ok(allCounters);  //  KK: returns a successful response (HTTP 200 OK) with the list of counters.  

        }

        //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
        [HttpGet]           //KK: Attribute to specify that should respond to HTTP GET request.
        [Route("{id}")]     //KK: This attribute is used to define a route template for the associated action method. The route template specifies the UR
        public async Task<IResult> GetACounter(int id)  //KK: this parameter id will be user's input.
        {
            //write code here replacing the string.Empty
            var counter = counters.FirstOrDefault(counter => counter.Id == id);

            //leave return line the same
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }


        //TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> GetCountersGreatThat(int number)
        {
            var filteredCounters = counters.Where(counter => counter.Value > number);
            return filteredCounters != null ? TypedResults.Ok(filteredCounters) : TypedResults.NotFound();
        }

        ////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.

        [HttpGet]
        [Route("LessThan/{number}")]
        public async Task<IResult> GetCounterLessThan(int number)
        {
            var filteredCounters = counters.Where(counter => counter.Value < number);
            return filteredCounters != null ? TypedResults.Ok(filteredCounters) : TypedResults.NotFound();
        }




        //Extension #1
        //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased
        [HttpPost]
        [Route("IncreaseBy1/{id}")]
        public async Task<IResult> IncreasementCounter(int id) 
        {
            var counter = counters.FirstOrDefault(x => x.Id == id);
           
            if (counter != null)
            {
            counter.Value++;
                return TypedResults.Ok(counter);
            }
            return TypedResults.NotFound($"Counter with Id {id} not found");
        }


        //Extension #2
        //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        [HttpPost]
        [Route("DecreaseBy1/{id}")]
        public async Task<IResult> DecreasementCounter(int id)
        {
            var counter = counters.FirstOrDefault(x => x.Id == id);
            if (counter != null)
            {
                counter.Value--;
                return TypedResults.Ok(counter);
            }
            return TypedResults.NotFound($"Counter with Id {id} not found");
        }

    }
}