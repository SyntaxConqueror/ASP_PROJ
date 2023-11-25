using ASP_MVC_PROJ.Filters;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddScoped<UniqueUsersFilter>();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.AddService<LogActionFilter>();
    options.Filters.AddService<UniqueUsersFilter>();
});

builder.Services.AddLogging(builder =>
{
    
    builder.AddConsole();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "/",
    pattern: "{controller=Product}/{action=DisplayProducts}/");

app.MapControllerRoute(
    name: "/weather",
    pattern: "{controller=Weather}/{action=Index}/");


app.Run();
