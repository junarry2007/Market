using MarketPlus.Api.Middleware;
using MarketPlus.Application;
using MarketPlus.Infrastructure;
using MarketPlus.Infrastructure.Cache;
using MarketPlus.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Agregar cache
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
//Cache
builder.Services.AddScoped(typeof(ICacheService<>), typeof(CacheService<>));

var app = builder.Build();

//Configure Migration and database
using (var scope = app.Services.CreateScope())
{
    ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.UseMiddleware<RequestTimeMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    var dictionary = new Dictionary<bool, string>();
    dictionary.Add(true, "Active");
    dictionary.Add(false, "Inactive");

    var cacheService = scope.ServiceProvider.GetRequiredService<ICacheService<Dictionary<bool, string>>>();

    cacheService.Set("States", dictionary, TimeSpan.FromMinutes(5));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
