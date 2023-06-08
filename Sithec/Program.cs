using Microsoft.EntityFrameworkCore;
using Sithec.Interfaces;
using Sithec.Models;
using Sithec.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMathService, MathService>();
builder.Services.AddScoped<IHumanService, HumanService>();


var connectionStrings = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<SithecDBContext>(options => options.UseSqlServer(connectionStrings));
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
