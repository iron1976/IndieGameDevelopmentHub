using IndieGameDevelopmentHub.Components;
using IndieGameDevelopmentHub.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<IndieGameDevelopmentHubContext>(options =>
    options.UseSqlServer("Server=localhost;Database=IndieGameDevelopmentHub;Trusted_Connection=True;TrustServerCertificate=True;"));

using (var context = new IndieGameDevelopmentHubContext())
{
    var newGame = new Tester
    {
        Name = "sda",
        Id = 23
    };// ENTITY FRAMEWORK IS CONNECTED!

    context.Testers.Add(newGame);
    context.SaveChanges();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} 

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
