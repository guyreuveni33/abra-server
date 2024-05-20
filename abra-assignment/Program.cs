using abra_assignment;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Adjust if your React app runs on a different port
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddSingleton<MongoDbContext>();
var mongoSettings = builder.Configuration.GetSection("MongoSettings");
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
    new MongoClient(mongoSettings["ConnectionString"]));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
 
}

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:3000") // Adjust the port if your client is running somewhere else
        .AllowAnyMethod()
        .AllowAnyHeader());
app.MapControllers();
 

app.Run();