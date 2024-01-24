using api_counter.wwwapi8;
using api_counter.wwwapi8.Data;
using api_counter.wwwapi8.Endpoints;
using api_counter.wwwapi8.Models;
using api_counter.wwwapi8.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

app.ConfigureEndpoints();

app.Run();