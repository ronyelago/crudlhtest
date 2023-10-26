using System.Text.Json.Serialization;
using LGApi.Infra;
using LGApi.Interfaces;
using LGApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationManager();

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<LgApiContext>(opt => 
    opt.UseNpgsql(configuration.GetConnectionString("LgApiConnectionString")));
// builder.Services.AddDbContext<LgApiContext>(opt => 
//     opt.UseNpgsql(Environment.GetEnvironmentVariable(@"LgApiConnectionString")));

builder.Services.AddScoped<LgApiContext>();
builder.Services.AddTransient<IContaRepository, ContaRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();
app.MapControllers();

app.Run();