using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from .env when on Docker env or appsettings when on local env
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

// Add EF Core with PostgreSQL
builder.Services.AddDbContext<TicketManagerDbContext>(options =>
    options.UseNpgsql(connectionString)
);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
