using ManheimWebApi.Configuration;
using ManheimWebApi.Repositories;
using ManheimWebApi.Repositories.interfaces;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mogoSettings=builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();

builder.Services.AddSingleton<MongoDBSettings>(mogoSettings!);
builder.Services.AddSingleton<IMongoClient>(new MongoClient(mogoSettings!.ConnectionString));

builder.Services.AddSingleton<MongoDbService>();
// Register the repository correctly
builder.Services.AddScoped<IUserRepository, UserRepository>();  //  Register the main interface


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
