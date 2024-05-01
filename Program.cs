using Microsoft.EntityFrameworkCore;
using MinimalAPI_EF_Postgres;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgresContext>(options =>
            options.UseNpgsql("Host=localhost:15432;Database=postgres;Username=postgres;Password=test1234"));
            

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getusers", async (PostgresContext db) =>
{
    var test = await db.Users.ToListAsync();
    return test;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapPost("/insertuser", async (PostgresContext db, User user) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/users/{user.Id}", user);
})
.WithName("insertuser")
.WithOpenApi();


app.MapPut("/updateuser/{id}", async (PostgresContext db, int id, User user) =>
{
    var userToUpdate = await db.Users.FindAsync(id);

    if(userToUpdate is null) return Results.NotFound();

    userToUpdate.Username = user.Username;
    userToUpdate.Password = user.Password;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/deleteuser/{id}", async (PostgresContext db, int id) => 
{
    var userToDelete = await db.Users.FindAsync(id);

    if(userToDelete is not null)
    {
        db.Users.Remove(userToDelete);
        await db.SaveChangesAsync();
    }
    return Results.NotFound();
});


app.Run();

