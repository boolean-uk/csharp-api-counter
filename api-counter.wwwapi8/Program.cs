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

// 1. write a method that returns all counters in the counters list.  use method below as a starting point
counters.MapGet("/", () =>
{
    return TypedResults.Ok(CounterHelper.Counters);
});


// 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet("/{id}", (int id) => {
    var counter = CounterHelper.Counters.FirstOrDefault(x => x.Id == id);
    return counter != null ? TypedResults.Ok(counter) : Results.NotFound();
});

// 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{ 
    var greaterCounters = CounterHelper.Counters.Where(x => x.Value > number).ToList();
    return greaterCounters.Any() ? TypedResults.Ok(greaterCounters) : Results.NotFound();
});

// 4. write another controlller method that returns counters that have a value less than the {number} passed in.
counters.MapGet("/lessthan/{number}", (int number) =>
{
    var lessCounters = CounterHelper.Counters.Where(x => x.Value < number).ToList();
    return lessCounters.Any() ? TypedResults.Ok(lessCounters) : Results.NotFound();
});


//Extension #1
//  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased
counters.MapPatch("/increment/{id}", (int id) =>
{
    Counter counter = CounterHelper.Counters.FirstOrDefault(x => x.Id == id);
    if (counter == null)
        return Results.NotFound();

    counter.Value++;
    return TypedResults.Accepted($"https://localhost:7293/counters/{id}", counter);
});




//Extension #2
// 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased
counters.MapPatch("/decrement/{id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(x => x.Id == id);
    if (counter == null)
        return Results.NotFound();

    counter.Value--;
    return TypedResults.Accepted($"https://localhost:7293/counters/{id}", counter);
});

app.Run();

