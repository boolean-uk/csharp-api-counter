using api_counter.wwwapi8;
using api_counter.wwwapi8.Helpers;
using api_counter.wwwapi8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
    var counters = CounterHelper.Counters;
    return TypedResults.Ok(counters);
})
    .WithName("GetWeatherForecast")
.WithOpenApi();


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet("/{id}", (int id) =>
{    
    var counter = CounterHelper.Counters.FirstOrDefault(x => x.Id == id);
    return counter != null ? TypedResults.Ok(counter) : Results.NotFound($"could not find item with id: {id}");    
});

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{
    var counters = CounterHelper.Counters.Where(c => c.Value > number);
    return TypedResults.Ok(counters);
});

////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
counters.MapGet("/lessthan/{number}", (int number) =>
{
    var counters = CounterHelper.Counters.Where(c => c.Value < number);
    return TypedResults.Ok(counters);
});


//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased
counters.MapPut("/increasevalue/{id}", (int id) =>
{
    Counter? counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
    if (counter != null)
    {
        counter.Value++;                    
        return TypedResults.Ok(counter);
    }
    return Results.NotFound($"could not find item with id: {id}");
});

//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased

counters.MapPut("/decreasevalue/{id}", (int id) =>
{
    Counter? counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
    if (counter != null)
    {
        counter.Value--;        
        return TypedResults.Ok(counter);
    }
    return Results.NotFound($"could not find item with id: {id}");
});

app.Run();

