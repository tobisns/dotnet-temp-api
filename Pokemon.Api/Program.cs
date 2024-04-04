
using Microsoft.EntityFrameworkCore;
using Pokemon.API.Extensions;
using Pokemon.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokemonDbContext>(
                options => options.UseNpgsql(builder.Configuration
                .GetConnectionString("PrimaryDbConnection")));

//Register Services
builder.Services.RegisterService();
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Clean Structured API Pokemon", Version = "v1" });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure CORS
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:3000") // Replace with your client application's origin
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials(); // Allow credentials
});

app.UseRouting();
app.MapControllers();

app.Run();