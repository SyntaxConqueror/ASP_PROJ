var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "/",
    pattern: "{controller=User}/{action=Index}/");

app.MapControllerRoute(
    name: "/order",
    pattern: "{controller=Order}/{action=OrderProducts}/");

app.MapControllerRoute(
    name: "/order/placeOrder",
    pattern: "{controller=Order}/{action=PlaceOrder}/");



app.Run();
