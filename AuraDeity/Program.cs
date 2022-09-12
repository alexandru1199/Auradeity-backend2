using DataAccess;
using Interfaces.Commands;
using Interfaces.Queries;
using Interfaces.Queries.Services;
using Logic.Commands;
using Logic.Queries;
using Logic.Queries.Services;
using Microsoft.EntityFrameworkCore;

var MyPolicy = "Policy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AuraDeityContext>(dbOptions =>
{
    dbOptions.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddScoped<IAuthenticationCommand, AuthenticationCommand>();
builder.Services.AddScoped<IAuthenticationQuery, AuthenticationQuery>();
builder.Services.AddScoped<IJwtQueryService, JwtQueryService>();
builder.Services.AddScoped<IWeatherAPI,WeatherAPI>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyPolicy,
        policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
