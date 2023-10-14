using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

app.UseRouting();

app.UseStaticFiles();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature.Error;

        Log.Error(exception, "An unhandled exception occurred");

        await context.Response.WriteAsync("An error occurred. Please check the log for details.");
    });
});

app.MapGet("/", (HttpContext context) =>
{
    return context.Response.SendFileAsync("index.html");
});


app.MapGet("/sendToCookies", (HttpContext context) =>
{
    string inputValue = context.Request.Query["inputValue"];
    string dateTimeValue = context.Request.Query["dateTimeValue"];
    DateTime exp = DateTime.Parse(dateTimeValue);

    // Set cookies with expiration
    context.Response.Cookies.Append("InputValue", inputValue, new CookieOptions { Expires = exp });
    context.Response.Cookies.Append("DateTimeValue", dateTimeValue, new CookieOptions { Expires = exp });

    // Construct an HTML response
    string htmlResponse = 
    $"<html>" +
    $"<body>" +
        $"<span>Data has been stored in cookies.</span><br>" +
        $"<span>InputValue: {context.Request.Cookies["InputValue"]}</span><br>" +
        $"<span>DateTimeValue: {context.Request.Cookies["DateTimeValue"]}</span>" +
    $"</body>" +
    $"</html>";

    // Set the content type to HTML
    context.Response.Headers.Add("Content-Type", "text/html");

    // Write the HTML response to the output
    return context.Response.WriteAsync(htmlResponse);
});


app.Run();