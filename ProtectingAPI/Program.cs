using AspNetCoreRateLimit;
using ProtectingAPI.StartupConfig;


var builder = WebApplication.CreateBuilder(args); //beginning of dependencies injection

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();

builder.Services.AddMemoryCache();

builder.AddRateLimitServices(); 



var app = builder.Build(); // end of dependencies injection, after this line, no more calls.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.UseIpRateLimiting();

app.Run();
