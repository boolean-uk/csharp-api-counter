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

List<Counter> countersData = CounterHelper.Counters;

var counters = app.MapGroup("/counters");
//TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
counters.MapGet("/", () =>
{
    return TypedResults.Ok(countersData);
});


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet("/{id}", (int id) =>
{
    Counter counter = GetCounterById(id);
    if(counter == null) { return Results.NotFound($"Counter with {id} not found."); }

    return TypedResults.Ok(counter);
    
});

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{

    List<Counter> counters = countersData.Where(c => c.Value > number).ToList();
    if (counters.Count<1) { return Results.NotFound($"No counter with a value greater than {number} exists."); }
    return TypedResults.Ok(counters);
});

////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.

counters.MapGet("/lessthan/{number}", (int number) =>
{
    List<Counter> counters = countersData.Where(c => c.Value < number).ToList();
    if (counters.Count < 1) { return Results.NotFound($"No counter with a value less than {number} exists."); }
    return TypedResults.Ok(counters);
}

    );


//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased

counters.MapPut("/increment/{id}", (int id) =>
{
    Counter counter = GetCounterById(id);
    if (counter == null) { return Results.NotFound($"Counter with id {id} not found."); }
    counter.Value++;

    return TypedResults.Ok(counter);

});

//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased

counters.MapPut("/decrement/{id}", (int id) =>
{
    Counter counter = GetCounterById(id);
    if (counter == null) { return Results.NotFound($"Counter with id {id} not found."); }
    counter.Value--;

    return TypedResults.Ok(counter);

});

app.Run();

Counter GetCounterById(int id) { return countersData.FirstOrDefault(c => c.Id == id); }
