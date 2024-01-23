
using api_counter.wwwapi8;
using api_counter.wwwapi8.Helpers;
using api_counter.wwwapi8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;

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
    List<Counter> counters = CounterHelper.Counters;
    return TypedResults.Ok(counters);
});


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet("/{id}", (int id) =>
{
    List<Counter> counters = CounterHelper.Counters;
    var tmp = counters.Find(x => x.Id == id);

    if (tmp == null)
    {
        return Results.BadRequest($"Counter with id: {id} can not be found");
    }
    return TypedResults.Ok(tmp);
});

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{
    List<Counter> counter = CounterHelper.Counters;
    List<Counter> countersGraterThanNumber = new List<Counter>();
    foreach (var item in counter)
    {
        if (item.Value > number)
        {
            countersGraterThanNumber.Add(item);
        }
    }

    return TypedResults.Ok(countersGraterThanNumber);
});

////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
counters.MapGet("/lowerthan/{number}", (int number) =>
{
    List<Counter> counter = CounterHelper.Counters;
    List<Counter> countersLowerThanNumber = new List<Counter>();

    foreach(var item in counter)
    {
        if (item.Value < number) {
            countersLowerThanNumber.Add(item);
        }
    }

    return TypedResults.Ok(countersLowerThanNumber);
});


//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased
counters.MapPut("/increasevalue/{id}", (int id) =>
{
    List<Counter> counters = CounterHelper.Counters;
    var tmp = counters.Find(x => x.Id == id);
    if (tmp != null)
    {
        tmp.Value++;
    } else
    {
        return Results.BadRequest($"Id: {id} not found");
    }

    return TypedResults.Ok(tmp);

});

//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased
counters.MapPut("/decreasevalue/{id}", (int id) =>
{
    List<Counter> counters = CounterHelper.Counters;
    var tmp = counters.Find(x => x.Id == id);
    if (tmp != null)
    {
        tmp.Value--;
    }
    else
    {
        return Results.BadRequest($"Id: {id} not found");
    }

    return TypedResults.Ok(tmp);

});

app.Run();

