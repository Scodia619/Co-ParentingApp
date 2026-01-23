using Co_ParentingApp.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Co_ParentingApp.Application.Microsoft.Extensions.DependencyInjection;
using Co_ParentingApp.Infrastructure.Microsoft.Extensions.DependencyInjection;
using Co_ParentingApp.API.Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Co_ParentingApp.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services
    .AddCoParentingAppApi()
    .AddCoParentingAppApplication()
    .AddCoParentingAppInfrastructure();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:8081",
                "http://localhost:19006"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString;

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
if (!string.IsNullOrEmpty(dbHost))
{
    // Production on Render
    var builderNpgsql = new NpgsqlConnectionStringBuilder
    {
        Host = dbHost,
        Port = int.Parse(Environment.GetEnvironmentVariable("DB_PORT") ?? "5432"),
        Database = Environment.GetEnvironmentVariable("DB_NAME"),
        Username = Environment.GetEnvironmentVariable("DB_USER"),
        Password = Environment.GetEnvironmentVariable("DB_PASSWORD"),
        SslMode = SslMode.Require,
        TrustServerCertificate = true
    };
    connectionString = builderNpgsql.ToString();
}
else
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/api/chathub");

app.Run();
