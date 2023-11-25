using Google;
using LR12_1;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // Отримайте контекст зі служби
        var dbContext = services.GetRequiredService<AppDbContext>();

        dbContext.Users.Add(new User { FirstName = "John", LastName = "Doe", Age = 30 });
        dbContext.Users.Add(new User { FirstName = "Jane", LastName = "Doe", Age = 25 });
        dbContext.Users.Add(new User { FirstName = "Alice", LastName = "Johnson", Age = 22 });

        dbContext.SaveChanges();

        var users = dbContext.Users.ToList();
        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.FirstName} {user.LastName}, Age: {user.Age}");
        }
    }

    catch (Exception ex)
    {
        // Обробте помилки за допомогою журналів, логерів або інших механізмів
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while processing the request.");
    }
}

app.Run();
