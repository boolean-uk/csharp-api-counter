using api_counter.wwwapi8;
using api_counter.wwwapi8.Helpers;
using api_counter.wwwapi8.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);       //Configurate HTTP pipeline

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

// Calling for the Helper: Initializer
CounterHelper.Initialize();

var counters = app.MapGroup("/counters");
//TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
// Endpoint 1: "GetAllCounters
app.MapGet("GetAllCounters", () =>
{
    return TypedResults.Ok(CounterHelper.Counters);
});


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
app.MapGet("GetACounter/{id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == id);
    //return TypedResults.Ok(id);
    return counter != null ? TypedResults.Ok(counter) : Results.NotFound();
});

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{
    var counters = CounterHelper.Counters.Where(counter => counter.Value > number).ToList();
    return counters != null ? TypedResults.Ok(counters) : Results.NotFound();
});

////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
app.MapGet("Lessthan/{number}", (int number) =>

{
    var counters = CounterHelper.Counters.Where(counter => counter.Value < number).ToList();
    return counters != null ? TypedResults.Ok(counters) : Results.NotFound();
});


//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased
app.MapPost("Increase by 1", (int id) => {
    var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == id);
    if (counter != null ) {
        //counter.Value += 1;
        counter.Value++;

        return TypedResults.Ok(counter);
    }

    return Results.NotFound($"Counter with Id {id} not found");
});

//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased
app.MapPost("Decrease by 1", (int id) => {
    var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == id);
    if (counter != null)
    {
        //counter.Value += 1;
        counter.Value--;

        return TypedResults.Ok(counter);
    }

    return Results.NotFound($"Counter with Id {id} not found");
});















