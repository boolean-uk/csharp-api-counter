using api_counter.wwwapi9.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

CounterHelper.Initialize();

var counters = app.MapGroup("/counters");

//TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
counters.MapGet(
    "/",
    () =>
    {
        return TypedResults.Ok(CounterHelper.Counters);
    }
);

//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
counters.MapGet(
    "/{id}",
    (int id) =>
    {
        return TypedResults.Ok(CounterHelper.Counters.Find(c => c.Id == id));
    }
);

//TODO: 3.  write another method that returns counters that have a value greater than the {number} passed in.
counters.MapGet(
    "/greaterthan/{number}",
    (int number) =>
    {
        return TypedResults.Ok(CounterHelper.Counters.Where(c => c.Value > number));
    }
);

////TODO:4. write another method that returns counters that have a value less than the {number} passed in.
counters.MapGet(
    "/lessthan/{number}",
    (int number) =>
    {
        return TypedResults.Ok(CounterHelper.Counters.Where(c => c.Value < number));
    }
);

//Extension #1
//TODO:  1. Write a controller method that increments the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be increased from 5 to 6
//return the counter you have increased
counters.MapPost(
    "increment/{number}",
    (int id) =>
    {
        var counter = CounterHelper.Counters.Find(c => c.Id == id);
        counter.Value = counter.Value + 1;
        return TypedResults.Ok(counter);
    }
);

//Extension #2
//TODO: 2. Write a controller method that decrements the Value property of a counter of any given Id.
//e.g.  with an Id=1  the Books counter Value should be decreased from 5 to 4
//return the counter you have decreased
counters.MapPost(
    "decrement/{number}",
    (int id) =>
    {
        var counter = CounterHelper.Counters.Find(c => c.Id == id);
        counter.Value = counter.Value - 1;
        return TypedResults.Ok(counter);
    }
);

//Super Optional Extension #1 - Refactor the code!
// - move the EndPoints into their own class and ensure they are mapped correctly
// - add a repository layer: interface & concrete class, inject this into the endpoint using the builder.Service


app.Run();
