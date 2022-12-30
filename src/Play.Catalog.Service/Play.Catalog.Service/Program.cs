using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

// Add services to the container.

builder.Services.Configure<MongoDbSettings>( builder.Configuration.GetSection("MongoDb"));

// TODO: Complete singleton registery for DI.
//builder.Services.AddSingleton<IRepository<Item>, MongoRepository <Item>>();
builder.Services.AddMongo().AddMongoRepository<Item>("items");


//builder.Services.AddSingleton<MongoRepository<Item>>(provider => new MongoRepository<Item>( collectionName: "jnksdf"));



builder.Services.AddControllers(
    options =>
    {
        options.SuppressAsyncSuffixInActionNames = false;
    }
).AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

