using Biblioteque.Repository;
using NuGet.Protocol.Core.Types;
using Biblioteque.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<BiblioContext>(); //a permis de solutionner le problème d'injection de dépendances



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BiblioContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

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
    name: "Livre",
    pattern: "{controller=Livres}/{action=Index}"
    );

app.Run();
