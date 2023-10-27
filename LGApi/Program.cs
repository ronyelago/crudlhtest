using System.Text.Json.Serialization;
using LGApi.Infra;
using LGApi.Interfaces;
using LGApi.Middlewares;
using LGApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<LgApiContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("LgApiConnectionString"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// builder.Services.AddDbContext<LgApiContext>(opt =>
// {
//     opt.UseNpgsql(Environment.GetEnvironmentVariable("LgApiConnectionString"));
//     opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
// });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<LgApiContext>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<RequestSerilogMiddleware>();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();
app.MapControllers();

app.Run();