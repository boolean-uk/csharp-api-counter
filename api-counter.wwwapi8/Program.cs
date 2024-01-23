using api_counter.wwwapi8;
using api_counter.wwwapi8.Helpers;
using api_counter.wwwapi8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

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
counters.MapGet("/{Id}", (int id) =>
{   var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == id);
    if (counter== null)
    {
        return Results.NotFound($"Id: {id} not found!");
    }
    return TypedResults.Ok(counter);
});


//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{
    var counter = CounterHelper.Counters.Where(counter=> counter.Value > number);
    return TypedResults.Ok(counter);
});


////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
counters.MapGet("/less/{number}", (int number) =>
{
    var counter = CounterHelper.Counters.Where(counter => counter.Value < number);
    return TypedResults.Ok(counter);
});



//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased


counters.MapPost("/increment/{Id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id ==id);

    if (counter != null)
    { 
        counter.Value++;
        return TypedResults.Ok(counter);
    }
    else
    {
        return Results.NotFound();
    };
    
});


//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased
counters.MapPost("/decrement/{Id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(counter => counter.Id == id);

    if (counter != null)
    {
        counter.Value--;
        return TypedResults.Ok(counter);
    }
    else
    {
        return Results.NotFound();
    };

});


app.Run();

