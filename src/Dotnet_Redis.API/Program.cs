using System.Reflection;
using Microsoft.OpenApi.Models;
using Dotnet_Redis.API.Data;
using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IConnectionMultiplexer>(options => ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisDbConnectionString")));
builder.Services.AddScoped<IPlatformRepo, RedisPlatformRepo>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TodoItem WebAPI",
        Description = "An ASP.NET Core Web API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Open API Author",
            Url = new Uri("https://RecurringTaskManagement.com/")
        }
    });

    // Swagger XML Documentation File
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
