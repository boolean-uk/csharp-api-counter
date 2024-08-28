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
counters.MapGet("/", () => TypedResults.Ok(CounterHelper.Counters));

// 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet("/{id}", (int id) =>
{    
    var c = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
    return c is not null ? Results.Ok(c) : Results.NotFound();
});

// 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{
    var c = CounterHelper.Counters.Where(c => c.Value > number);
    return TypedResults.Ok(c);
});

// 4. write another controlller method that returns counters that have a value less than the {number} passed in.
counters.MapGet("/lessthan/{number}", (int number) =>
{
    var c = CounterHelper.Counters.Where(c => c.Value < number);
    return TypedResults.Ok(c);
});

//Extension #1
// 1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased
counters.MapGet("/inc/{id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id.Equals(id));
    if (counter is not null) counter.Value++;
    return counter is not null ? Results.Ok(counter) : TypedResults.NotFound();
});

//Extension #2
// 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased

counters.MapGet("/dec/{id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id.Equals(id));
    if (counter is not null) counter.Value--;
    return counter is not null ? Results.Ok(counter) : TypedResults.NotFound();
});

app.Run();

