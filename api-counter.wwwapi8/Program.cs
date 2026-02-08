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
    //Initialize list
    List<Counter> countList = CounterHelper.Counters;
    return TypedResults.Ok(countList);
});


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet("/{id}", (int id) =>
{
    //initialize list
    List<Counter> countList = CounterHelper.Counters;

    //Loop through the list
    var counter = countList.FirstOrDefault(c => c.Id == id);

    //if ID found, return object, otherwise badREquest
    if (counter != null)
    {
        return TypedResults.Ok(counter);
    }
    return Results.BadRequest();

});

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{
    //Initialize list
    List<Counter> countList = CounterHelper.Counters;

    //New empty list to return
    List<Counter> returnList = new List<Counter>();

    //loop through the list and add all object with value greater than number
    foreach (var counter in countList)
    {
        if (counter.Value > number) 
        {
            returnList.Add(counter);
        }
    }

    //return
    return TypedResults.Ok(returnList);
});

////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
counters.MapGet("/smallerthan/{number}", (int number) =>
{
    //Initialize list
    List<Counter> countList = CounterHelper.Counters;

    //New empty list to return
    List<Counter> returnList = new List<Counter>();

    //loop through the list and add all object with value smaller than number
    foreach (var counter in countList)
    {
        if (counter.Value < number)
        {
            returnList.Add(counter);
        }
    }

    //return
    return TypedResults.Ok(returnList);
});



//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased

counters.MapGet("/increasevalue/{number}", (int id) =>
{
    //Initialize list
    List<Counter> countList = CounterHelper.Counters;

    //New empty list to return
    List<Counter> returnList = new List<Counter>();

    //find where ID equals ID
    var counter = countList.FirstOrDefault(c => c.Id == id);

    //if ID found, increase value by ID, annd return object, otherwise badREquest
    if (counter != null)
    {
        counter.Value += id;
        return TypedResults.Ok(counter);
    }
    return Results.BadRequest();

});


//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased

counters.MapGet("/decreasevalue/{number}", (int id) =>
{
    //Initialize list
    List<Counter> countList = CounterHelper.Counters;

    //New empty list to return
    List<Counter> returnList = new List<Counter>();

    //find where ID equals ID
    var counter = countList.FirstOrDefault(c => c.Id == id);

    //if ID found, decrease value by ID, annd return object, otherwise badREquest
    if (counter != null)
    {
        counter.Value -= id;
        return TypedResults.Ok(counter);
    }
    return Results.BadRequest();

});

app.Run();

