using DataBaseEf;
using LinkShorteningService.DiConfig;
using LinkShorteningService.Extension;
using Microsoft.EntityFrameworkCore;
using Servises.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(c =>
    // Set the comments path for the Swagger JSON and UI.
    c.IncludeXmlComments(
        Path.Combine(
            AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml")));

builder.Services.AddHttpContextAccessor();

builder.Services
    .AddDbContext<DbContext, ContextEf>(
        options => options
            .UseSqlServer(builder.Configuration.GetConnectionString(typeof(ContextEf).Name)));

builder.Services.AddModule<DiModule>();

builder.Services.AddOptions();
builder.Services.Configure<ServiseOptions>(builder.Configuration.GetSection(typeof(ServiseOptions).Name));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
