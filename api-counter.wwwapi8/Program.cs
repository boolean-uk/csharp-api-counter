using api_counter.wwwapi8.Helpers;
using api_counter.wwwapi8.Models;

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
    if (counters.Count() == 0) { return Results.NoContent(); }

    return TypedResults.Ok(CounterHelper.Counters);
});


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet("/{id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
    return counter != default ? TypedResults.Ok(counter) : Results.NotFound($"Task {id} was not found");
});

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
counters.MapGet("/greaterthan/{number}", (int number) =>
{
    return TypedResults.Ok(CounterHelper.Counters.Where(c => c.Value > number));
});

////TODO:4. write another controlller method that returns counters that have a value less than the {number} passed in.
counters.MapGet("/lessthan/{number}", (int number) =>
{
    return TypedResults.Ok(CounterHelper.Counters.Where(c => c.Value < number));
});


//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased
counters.MapPatch("/incrementById/{id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
    if (counter == default) { return Results.NotFound($"Task {id} was not found"); }
    counter.Value++;
    return TypedResults.Ok(counter);
});


//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased

counters.MapPatch("/decrementById/{id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);
    if (counter == default) { return Results.NotFound($"Task {id} was not found"); }
    if (counter.Value <= 0) return TypedResults.BadRequest($"Id: {id}, Value: {counter.Value}: value can't be negative");
    counter.Value--;
    return TypedResults.Ok(counter);
});

app.Run();

