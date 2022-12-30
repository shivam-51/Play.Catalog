using System;
using System.Collections;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T: IEntity
    {
        private readonly IMongoCollection<T> dbCollection;

        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public MongoRepository(
        IMongoDatabase mongoDatabase, string collectionName)
        {
            //const string collectionName = "items";
            //Console.WriteLine(mongoDbSettings.Value.Host);
            //Console.WriteLine(mongoDbSettings.Value.Port);
            //var mongoClient = new MongoClient(
            //    mongoDbSettings.Value.ConnectionString);

            //var mongoDatabase = mongoClient.GetDatabase(
            //    mongoDbSettings.Value.DatabaseName);

            dbCollection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);

            return await dbCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await dbCollection.InsertOneAsync(entity);
        }


        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            FilterDefinition<T> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);

            await dbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, id);

            await dbCollection.DeleteOneAsync(filter);
        }
    }
}

