using ManheimWebApi.Configuration;
using ManheimWebApi.Middlewares;
using ManheimWebApi.Repositories;
using ManheimWebApi.Repositories.interfaces;
using MongoDB.Driver;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});
// Add services to the container.
var mogoSettings=builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();

builder.Services.AddSingleton<MongoDBSettings>(mogoSettings!);
builder.Services.AddSingleton<IMongoClient>(new MongoClient(mogoSettings!.ConnectionString));

builder.Services.AddSingleton<MongoDbService>();

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()  // Set minimum log level
//    .WriteTo.Console()
//    .WriteTo.File("C:\\Users\\abhijith\\source\\repos\\ASP.Net\\ConsoleApp1\\ManheimWebApi\\logs\\app.log", rollingInterval: RollingInterval.Day) // Log warnings and above to file
//    .CreateLogger();



//Registering Global Exception service
builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

// Register the repository correctly
builder.Services.AddScoped<IUserRepository, UserRepository>();  //  Register the main interface


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//using global exception hanling middleware    
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Example logging
//app.Use(async (context, next) =>
//{
//    Log.Information("Handling request: {Path}", context.Request.Path);
//    await next();
//    Log.Information("Finished handling request.");
//});

// Enable serving static files from wwwroot
app.UseStaticFiles();

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
