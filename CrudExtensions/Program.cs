using CrudExtensions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

PostHelper.Initialize();

// /posts/{postId}/comments

var posts = app.MapGroup("/posts");


// GET All Comments of a post
posts.MapGet("/{postId}/comments", (int id) =>
{
    Post post = PostHelper.Posts.Find(x => x.Id == id);

    if (post == null)
    {
        return Results.NotFound("Post not found");
    }

    List<Comment> res = post.Comments;

    return TypedResults.Ok(res);

});


// GET One comment of a post by ID
posts.MapGet("/{id}/comments/{commentId}", (int id, int commentId) =>
{
    Post post = PostHelper.Posts.Find(x => x.Id == id);

    if (post == null)
    {
        return Results.NotFound("Post not found");
    }

    Comment res = post.Comments.Find(x => x.Id == commentId);

    if (res == null)
    {
        return Results.NotFound("Comment not found");
    }

    return TypedResults.Ok(res);
});


// Filter posts by condition        
posts.MapGet("/{id}/comments/likes/{number}", (int id, int number) =>
{
    Post post = PostHelper.Posts.Find(x => x.Id == id);

    if (post == null)
    {
        return Results.NotFound("Post not found");
    }

    List<Comment> res = post.Comments.FindAll(x => x.Likes >= number);

    return TypedResults.Ok(res);

});


// Create new post
posts.MapPost("/{id}/comments", (int id, Comment c) =>
{
    Post post = PostHelper.Posts.Find(x => x.Id == id);

    if (post == null)
    {
        return Results.NotFound("Post not found");
    }

    c.PostId = post.Id;
    c.Id = post.Comments.Count() + 1;

    post.Comments.Add(c);

    return Results.Created($"/{id}/comments/{c.Id}", c);
});

/// DELETE comment
posts.MapDelete("/{id}/comments/{commentId}", (int id, int commentId) =>
{

    Post post = PostHelper.Posts.Find(x => x.Id == id);

    if (post == null)
    {
        return Results.NotFound("Post not found");
    }


    if (post.Comments.Exists(x => x.Id == commentId))
    {
        post.Comments = post.Comments.FindAll(x => x.Id != commentId);

        return Results.NoContent();
    }

    return Results.NotFound("Comment not found!");
});


/// UPDATE comment
posts.MapPut("/{id}/comments/{commentId}", (int id, int commentId, string text) =>
{

    Post post = PostHelper.Posts.Find(x => x.Id == id);

    if (post == null)
    {
        return Results.NotFound("Post not found");
    }


    if (post.Comments.Exists(x => x.Id == commentId))
    {
        Comment c = post.Comments.Find(x => x.Id == commentId);

        c.Text = text;

        return Results.NoContent();
    }

    return Results.NotFound("Comment not found!");
});
/**






/// DELETE
counters.MapDelete("/{id}", (int id) =>
{
    if (!CounterHelper.Counters.Exists(x => x.Id == id))
    {
        return Results.NotFound($"Counter {id} not found");
    }
    List<Counter> res = CounterHelper.Counters.FindAll(x => x.Id != id);

    return TypedResults.Ok(res);

});
**/

app.Run();