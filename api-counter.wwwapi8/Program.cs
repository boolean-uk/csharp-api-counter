using api_counter.wwwapi8;
using api_counter.wwwapi8.Helpers;
using api_counter.wwwapi8.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

CounterHelper.Initialize();

var counters = app.MapGroup("/counters");
//TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
counters.MapGet("/", () =>
{
    var allCounters = CounterHelper.Counters;
    return Results.Ok(allCounters);
});


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet("/{id}", (int id) =>
{
    var counter = CounterHelper.Counters.Find(c => c.Id == id);

    if (counter != null)
    {
        return TypedResults.Ok(counter);
    }
    else
    {
        return Results.NotFound($"Counter with Id {id} not found");
    }
});

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{

    List<Counter> lessThanCounters = new List<Counter>();


    foreach (var counter in CounterHelper.Counters)
    {
        if (counter.Value > number)
        {
            lessThanCounters.Add(counter);
        }
        //counters.Add(c => c.Value > number);
    }



    if (lessThanCounters != null)
    {
        return TypedResults.Ok(lessThanCounters);
    }
    else
    {
        return Results.NotFound($"Counter with value less than {number} not found");
    }
});

////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
counters.MapGet("/lessthan/{number}", (int number) =>
{


    List<Counter> lessThanCounters = new List<Counter>();


    foreach (var counter in CounterHelper.Counters)
    {
        if (counter.Value < number)
        {
            lessThanCounters.Add(counter);
        }
        //counters.Add(c => c.Value > number);
    }



    if (lessThanCounters != null)
    {
        return TypedResults.Ok(lessThanCounters);
    }
    else
    {
        return Results.NotFound($"Counter with value less than {number} not found");
    }
  
});



//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased
counters.MapPut("/incrementsValue/{number}", (int id, int number) =>
{



   
    var counter = CounterHelper.Counters.Find(c => c.Id == id);
    counter.Value += number;

    if (counter != null)
    {
        return TypedResults.Ok(counter);
    }
    else
    {
        return Results.NotFound($"Counter with id {id} not found");
    }
});

//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased

counters.MapPut("/decrementsValue/{number}", (int id, int number) =>
{
    var counter = CounterHelper.Counters.Find(c => c.Id == id);
    counter.Value -= number;

    if (counter != null)
    {
        return TypedResults.Ok(counter);
    }
    else
    {
        return Results.NotFound($"Counter with id {id} not found");
    }
});

app.Run();

