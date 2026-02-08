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
    return TypedResults.Ok(CounterHelper.Counters) ;
});


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet("/{id}", (int id) =>
{
    Counter? result = CounterHelper.Counters.Find(x => x.Id == id);
    if (result is null) return Results.NotFound($"Counter {id} doesn't exist");
    return TypedResults.Ok(result);
});

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{
    List<Counter> result = CounterHelper.Counters.FindAll(x => x.Value > number);
    return TypedResults.Ok(result);
});

////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
counters.MapGet("/lesserthan/{number}", (int number) =>
{
    List<Counter> result = CounterHelper.Counters.FindAll(x => x.Value < number);
    return TypedResults.Ok(result);
});

//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased

counters.MapPut("/increase/{id}", (int id) =>
{
    Counter? counter = CounterHelper.Counters.Find(x => x.Id == id);
    if (counter is null) return Results.NotFound($"Counter {id} doesn't exist");
    counter.Value++;
    return TypedResults.Ok(counter);
});




//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased
counters.MapPut("/decrease/{id}", (int id) =>
{
    Counter? counter = CounterHelper.Counters.Find(x => x.Id == id);
    if (counter is null) return Results.NotFound($"Counter {id} doesn't exist");
    if (counter.Value > 0) counter.Value--;
    return TypedResults.Ok(counter);
});

app.Run();

