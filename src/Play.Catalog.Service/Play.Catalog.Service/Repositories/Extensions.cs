using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Settings;
using Microsoft.Extensions.Options;

namespace Play.Catalog.Service.Repositories
{
	public static class Extensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
		{
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            services.AddSingleton(provider =>
            {
                //var configuration = provider.GetRequiredService<IConfiguration>();
                //var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
                var mongoDbSettings = provider.GetRequiredService<IOptions<MongoDbSettings>>();
                var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
                return mongoClient.GetDatabase("Catalog");
            });
            return services;
        }
        public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services, string collectionName) where T : IEntity
        {


            services.AddSingleton<IRepository<T>>(provider =>
            {
                var database = provider.GetService<IMongoDatabase>();
                return new MongoRepository<T>(database, collectionName);
            });
            return services;
        } 
    }
}

