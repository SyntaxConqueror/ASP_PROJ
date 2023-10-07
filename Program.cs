using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using ASP_PROJ;
using System.Text.Json.Serialization;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("config.json")
    .Build();


var myConfiguration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("me.json")
    .Build();

app.UseRouting();

app.MapGet("/", (HttpContext context) => "Hello, world!");

app.MapGet("/Library", (HttpContext context) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    return "Привіт, ви у бібліотеці!";
});

app.MapGet("/Library/Books", (HttpContext context) =>
{

    var booksConfig = configuration.GetSection($"Books").Get<List<BooksConfig>>();

    context.Response.ContentType = "application/json; charset=utf-8";

    string result = "Список книг наявних у бібліотеці: \n\n";
    for(int i = 0; i < booksConfig.Count(); i++)
    {
        result += $"\tНазва книги: {booksConfig[i].Title}\n\n";
    }
    return result;
});

app.MapGet("/Library/Profile/{id:int?}", (HttpContext context) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    if (context.Request.RouteValues.TryGetValue("id", out var idObj) && int.TryParse(idObj.ToString(), out var userId))
    {
        var userConfig = configuration.GetSection($"Users:{userId}").Get<UserConfig>();
        if (userId >= 0 && userId <= 5 && userConfig != null)
        {
             return $"Інформація про користувача з id={userId}: {userConfig.Name}, {userConfig.Email}";
        }
        
    }

    var myConfig = myConfiguration.Get<MyInfo>();
    return  $"Інформація про користувача: " +
            $"\nІм'я: {myConfig.Name}" +
            $"\nПрізвище: {myConfig.LastName}" +
            $"\nВік: {myConfig.Age}" +
            $"\nПокликання: {myConfig.Destination}";
});


app.Run();


public class UserConfig
{
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    public string Email { get; set; }
}

public class BooksConfig
{
    public string Title {  get; set; }
}