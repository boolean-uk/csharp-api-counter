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
counters.MapGet("/", () =>
{
    return TypedResults.Ok(CounterHelper.Counters);
});

counters.MapGet("/{id}", (int id) =>
{    var counter = CounterHelper.Counters.FirstOrDefault(x => x.Id == id);
    return TypedResults.Ok(counter);
});

      
counters.MapGet("/greaterthan/{number}", (int number) =>
{
List<Counter> countersSort = CounterHelper.Counters.Where(c => c.Value > number).ToList();

    return TypedResults.Ok(countersSort);
});

counters.MapGet("/lessthan/{number}", (int number) =>
{
    List<Counter> countersSort = CounterHelper.Counters.Where(c => c.Value < number).ToList();

    return TypedResults.Ok(countersSort);
});

//Extension #1

counters.MapGet("/increment/{id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(x => x.Id == id);
    if (counter != null) { counter.Value++ ; }

    return TypedResults.Ok(counter);
});

//Extension #2

counters.MapGet("/decrement/{id}", (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(x => x.Id == id);
    if (counter != null) { counter.Value--; }

    return TypedResults.Ok(counter);
});

app.Run();

