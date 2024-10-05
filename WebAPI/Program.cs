using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

await using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
// Console.WriteLine($"Database path: {db.DbPath}.");

// Read
// Console.WriteLine("Querying for blogs");

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

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

    app.MapGet("/blogs", () => {
        // var results =
        // from blog in db.Blogs //check the PR (pass query to IEnumerable)
        // where blog.BlogId == 1
        // select blog;

        // await foreach (var s in results.AsAsyncEnumerable())
        // {
        //     Console.WriteLine("Blog id: " + s.BlogId + "    Blog URL: " + s.Url);
        // } 
        return db.Blogs;
    })
    .WithName("GetBlogs")
    .WithOpenApi();
    app.Run();
// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();


// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
