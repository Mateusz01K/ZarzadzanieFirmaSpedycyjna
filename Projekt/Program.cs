using Microsoft.EntityFrameworkCore;
using Projekt.Context;
using Projekt.Models;
using Projekt.Services.Truck;
using Projekt.Services.AssignmentTruck;
using Projekt.Services.User;
using Projekt.Services.Trailer;
using Projekt.Services.AssignTrailerToTruck;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TruckContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TruckContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITruckService, TruckService>();
builder.Services.AddScoped<ITrailerService, TrailerService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IAssignTrailerToTruckService, AssignTrailerToTruckService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
