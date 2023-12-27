using Inventory_Management_System.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Contex>(options => {
    Console.WriteLine("Connection...");
    try
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        Console.WriteLine("Connection Confrim");
    }
    catch {
        Console.WriteLine("Connection Failed");
    }
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
