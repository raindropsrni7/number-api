using Microsoft.EntityFrameworkCore;
using NumberApp.Data;
using NumberApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Numbers"));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("api/numbers", async (AppDbContext db) =>
{
    var items = await db.Numbers.ToListAsync();

    return Results.Ok(items);
});

app.MapPost("api/numbers", async (AppDbContext db, NumItem numItem) =>
{
    await db.Numbers.AddAsync(numItem);
    await db.SaveChangesAsync();

    return Results.Created($"/api/numbers/{numItem.Id}", numItem);
});

app.Run();

