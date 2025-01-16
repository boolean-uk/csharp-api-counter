# C# API Counter

## Learning Objectives
- Use ASP.NET to build a simple Minimal API

## Instructions

1. Fork this repository
2. Clone your fork to your machine
3. Open the project in Visual Studio
4. In the `Program.cs`, implement the TODO / Extension comments
5. Run this project and use the following endpoints for help when running:
	1. [Swagger](http://localhost:5167/swagger/index.html)
	2. [Scalar](http://localhost:5167/scalar/v1)
	3. [API Definition](http://localhost:5167/openapi/v1.json)

## Core / Extension Requirements

You're going to add some code to the endpoint methods to get the counter API working in the api-counter.wwwapi9 project. The Counter object is a model to represent an item (using Name property) and how many of those items (Value property) you may have.  It has Id, Name and Value properties.  

The List<Counter> counters is the collection you will use within the controller to store counters.  

Follow the tasks with the `//TODO` comments.   You can use the Task List pane if you wish to view all.  

I would encourage you to attempt the Core and Extensions in this exercise.

## Further work

- Explore the documentation of the ASP.NET framework as much as you are able, you'll be using it for almost everything going forward. We'll be introducing new components of the framework in future exercises.
- Examine the other projects that are included in this repository but have been removed from the solution.  Be aware of the main differences between different versions of API's. I would recommend at some point in the future looking into Controller based API's (version 7.0) as these are heavily used within the industry.
