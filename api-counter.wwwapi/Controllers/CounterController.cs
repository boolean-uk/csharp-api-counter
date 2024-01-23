﻿using api_counter.wwwapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi.Controllers
{
    [ApiController]
    [Route("counters")]
    public class CounterController : ControllerBase
    {
        public static List<Counter> counters = new List<Counter>();


        public CounterController()
        {
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
        [HttpGet]
        [Route("")]
        public async Task<IResult> GetAllCounters()
        {
            //change the number returned in the line below to counter list variable
            return TypedResults.Ok(counters);
        }

        //TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetACounter(int id)
        {
            //write code here replacing the string.Empty
            var counter = counters.FirstOrDefault(counter => counter.Id == id);
           
            //leave return line the same
            return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
        }

        //TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> GetGreater(int number)
        {
            var counter = counters.Where(counter => counter.Value > number);
            return TypedResults.Ok();
        }

        ////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
        [HttpGet]
        [Route("greaterthan/{number}")]
        public async Task<IResult> GetLess(int number)
        {
            var counter = counters.Where(counter => counter.Value < number);
            return TypedResults.Ok();
        }


        //Extension #1
        //TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
        //return the counter you have increased
        [HttpGet]
        [Route("increment/{id}")]
        public async Task<IResult> Increment(int id)
        {
            var idToIncrement = counters.FirstOrDefault(idToIncrement => idToIncrement.Id == id);
            if (idToIncrement == null)
            {
                return Results.NotFound($"Id: {id} not found!");
            }
            idToIncrement.Value++;
            return TypedResults.Ok(idToIncrement);
        }

        //Extension #2
        //TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
        //e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
        //return the counter you have decreased
        [HttpGet]
        [Route("increment/{id}")]
        public async Task<IResult> Decrement(int id)
        {
            var idToIncrement = counters.FirstOrDefault(idToIncrement => idToIncrement.Id == id);
            if (idToIncrement == null)
            {
                return Results.NotFound($"Id: {id} not found!");
            }
            idToIncrement.Value--;
            return TypedResults.Ok(idToIncrement);
        }
    }
}