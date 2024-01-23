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

//returns all counters in the counters list.
counters.MapGet("/", () =>
{
    return TypedResults.Ok(CounterHelper.Counters);
});


//return a single counter based on the id being passed in.
counters.MapGet("/{id}", IResult (int id) =>
{   
    var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == id);
    if (counter != null)
    {
        return TypedResults.Ok(counter);
    }
    return TypedResults.NotFound($"Id: {id} not found!");
});

//returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", IResult (int number) =>
{
    var highercounters = CounterHelper.Counters.Where(c => c.Value > number);
    if (highercounters != null)
    {
        return TypedResults.Ok(highercounters);
    }
    return TypedResults.NotFound($"Counters with a value higher than {number} not found!");
});

////returns counters that have a value less than the {number} passed in.
counters.MapGet("/lessthan/{number}", IResult (int number) =>
{
    var highercounters = CounterHelper.Counters.Where(c => c.Value < number);
    if (highercounters != null)
    {
        return TypedResults.Ok(highercounters);
    }
    return TypedResults.NotFound($"Counters with a value higher than {number} not found!");
});



//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased
counters.MapPut("/increment/{id}", IResult (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == id);
    if (counter != null)
    {
        counter.Value++;
        return TypedResults.Ok(counter);
    }
    return TypedResults.NotFound($"Id: {id} not found!");
});


//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased
counters.MapPut("/decrement/{id}", IResult (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == id);
    if (counter != null)
    {
        counter.Value--;
        return TypedResults.Ok(counter);
    }
    return TypedResults.NotFound($"Id: {id} not found!");
});


app.Run();

