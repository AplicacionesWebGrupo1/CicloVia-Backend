
using CicloViaPlatform.Routes;
using CicloViaPlatform.Routes.Domain.Repositories;
using CicloViaPlatform.Routes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using CicloViaPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using CicloViaPlatform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using CicloViaPlatform.Shared.Domain.Repositories;
using CicloViaPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// configure lower case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// configure kebab case route naming convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify if the connection string is not null or empty
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
}

// Configure Database Context and Logging Level
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });
else  if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
    }); 

// configure dependency injection

// shared bounded context injection configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Routes Bounded Context Injection Configuration
builder.Services.AddScoped<IRouteDistanceRepository,RouteDistanceRepository>();


var app = builder.Build();

//verify if the database is created and apply migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();
