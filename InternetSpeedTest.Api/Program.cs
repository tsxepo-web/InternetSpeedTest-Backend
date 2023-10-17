using InternetSpeedTest.Infrastructure;
using InternetSpeedTest.Infrastructure.Abstract;
using InternetSpeedTest.Infrastructure.Models.Entities;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoConnectionString = builder.Configuration["SpeedTest:ConnectionString"];
var mongoDatabaseName = builder.Configuration["SpeedTest:DatabaseName"];
var mongoCollectionName = builder.Configuration["SpeedTest:CollectionName"];

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
var mongoCollection = mongoDatabase.GetCollection<User>(mongoCollectionName);
builder.Services.AddSingleton(mongoCollection);

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IStatsRepository, StatsRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("default",
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("default");
app.MapControllers();

app.Run();
