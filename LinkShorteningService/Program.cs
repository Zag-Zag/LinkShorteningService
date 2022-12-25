using DataBaseEf;
using LinkShorteningService.DiConfig;
using LinkShorteningService.Extension;
using Microsoft.EntityFrameworkCore;
using Servises.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
