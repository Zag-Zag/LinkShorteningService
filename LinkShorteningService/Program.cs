using DataBaseEf;
using LinkShorteningService.DiConfig;
using LinkShorteningService.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Di
builder.Services
    .AddDbContext<DbContext, ContextEf>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddModule<DiModule>();

var app = builder.Build();

//builder.Services.Configure<LinkShorteningConfiguration>(app. .GetSection("LinkShorteningConfiguration"));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
