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
counters.MapGet("/", () => TypedResults.Ok(CounterHelper.Counters));


counters.MapGet("/{id}", IResult (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);

    // Just for correctness, I'll return the correct status code on non-existent counters
    if (counter == null)
    {
        return TypedResults.NoContent();
    }

    return TypedResults.Ok(counter);
});

counters.MapGet("/greaterthan/{number}", IResult (int number) =>
{
    var counterList = CounterHelper.Counters.FindAll(c => c.Value > number);
    return TypedResults.Ok(counterList);
});

counters.MapGet("/lessthan/{number}", IResult (int number) =>
{
    var counterList = CounterHelper.Counters.FindAll(c => c.Value < number);
    return TypedResults.Ok(counterList);
});

//Extension #1
counters.MapPut("/{id}/increment", IResult (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);

    if (counter == null)
    {
        return TypedResults.BadRequest();
    }

    counter.Value++;
    
    return TypedResults.Ok(counter);
});

//Extension #2
counters.MapPut("/{id}/decrement", IResult (int id) =>
{
    var counter = CounterHelper.Counters.FirstOrDefault(c => c.Id == id);

    if (counter == null)
    {
        return TypedResults.BadRequest();
    }

    counter.Value--;
    
    return TypedResults.Ok(counter);
});

//Super Optional Extension #1 - Refactor the code!
// - move the EndPoints into their own class and ensure they are mapped correctly
// - add a repository layer: interface & concrete class, inject this into the endpoint using the builder.Service


app.Run();
