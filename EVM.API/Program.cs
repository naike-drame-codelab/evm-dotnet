using EVM.API.Configurations;
using EVM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.IncludeFields = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EventVenueManagerContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// TokenManager
// AddAuthentication

builder.Services.AddRepositories();
builder.Services.AddServices();

// AddEmailService
// AddCors
builder.Services.AddCors(b => b.AddDefaultPolicy(o =>
{
    o.AllowAnyOrigin();
    o.AllowAnyMethod();
    o.AllowAnyHeader(); 
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
