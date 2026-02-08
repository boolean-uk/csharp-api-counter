
using api_counter.wwwapi8;
using api_counter.wwwapi8.Data;
using api_counter.wwwapi8.Helpers;
using api_counter.wwwapi8.Models;
using api_counter.wwwapi8.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<CounterCollection>();
builder.Services.AddScoped<ICounterRepository, CounterRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var counters = app.MapGroup("/counters");

//TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
counters.MapGet("/", (ICounterRepository counter) =>
{
    return TypedResults.Ok(counter.getAllCounters());
});


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet("/{id}", (int id, ICounterRepository counter) =>
{
    Counter foundCounter = counter.getCounterById(id);
    if (foundCounter != null)
    {
        return TypedResults.Ok(foundCounter);
    } else
    {
        return Results.NotFound($"id: {id} could not be found");
    }
    
});

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number, ICounterRepository counter) =>
{
   return TypedResults.Ok(counter.getAllGreaterThan(number));
});

////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
counters.MapGet("/lowerthan/{number}", (int number, ICounterRepository counter) =>
{
   return TypedResults.Ok(counter.getAllLesserThan(number));
});


//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased
counters.MapPut("/increasevalue/{id}", (int id, ICounterRepository counter) =>
{
    return TypedResults.Created($"/counters/increasevalue/{id}",counter.IncreaseValueByOne(id));
});

//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased
counters.MapPut("/decreasevalue/{id}", (int id, ICounterRepository counter) =>
{
    return TypedResults.Created($"/counters/decreasevalue/{id}",counter.DecreaseValueByOne(id));
});

app.Run();

