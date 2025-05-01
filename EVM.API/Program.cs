using EVM.API.Configurations;
using EVM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Stripe;
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
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection"))
);

StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

// TokenManager

// AddAuthentication

builder.Services.AddRepositories();
builder.Services.AddServices();

// AddEmailService

// AddCors
builder.Services.AddCors(b => b.AddDefaultPolicy(o =>
{
    o.WithOrigins("http://localhost:4200");
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

app.UseCors();
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
