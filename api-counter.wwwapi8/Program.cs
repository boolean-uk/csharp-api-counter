using api_counter.wwwapi8;
using api_counter.wwwapi8.Helpers;
using api_counter.wwwapi8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

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
    return TypedResults.Ok(CounterHelper.Counters);
});


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
async Task<IResult> GetACounter(int id)
{
    var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
    return counter != null ? TypedResults.Ok(counter) : TypedResults.NotFound();
}

counters.MapGet("/{id}", GetACounter);

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.

async Task<IResult> GetGreaterThan(int number)
{
    var countersGreaterThan = CounterHelper.Counters.Where(c => c.Value > number);
    return TypedResults.Ok(countersGreaterThan);
}

counters.MapGet("/greaterthan/{number}", GetGreaterThan);

////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
async Task<IResult> GetLesserThan(int number)
{
    var countersLesserThan = CounterHelper.Counters.Where(c => c.Value < number);
    return TypedResults.Ok(countersLesserThan);
}

counters.MapGet("/lesserthan/{number}", GetLesserThan);

//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased

async Task<IResult> PatchIncrementValue(int id)
{
    var counterToIncrement = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
    if (counterToIncrement == null)
    {
        return TypedResults.NotFound();
    }

    counterToIncrement.Value += 1;
    return TypedResults.Ok(counterToIncrement.Value);
}

counters.MapPatch("increment/{id}", PatchIncrementValue);


//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased

async Task<IResult> PatchDecreaseValue(int id)
{
    var counterToDecrease = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
    if (counterToDecrease == null)
    {
        return TypedResults.NotFound();
    }

    counterToDecrease.Value += 1;
    return TypedResults.Ok(counterToDecrease.Value);
}

counters.MapPatch("decrease/{id}", PatchDecreaseValue);

app.Run();

