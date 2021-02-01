using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.MongoDb
{
    public class MongoDb : IMongoDb
    {
        private IMongoDatabase _database;
        private MongoClientSettings settings;

        public MongoDb()
        {
            try
            {
                settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
                
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase("F-First");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public void Save<T>(T entity)
        {
            _database.GetCollection<T>(entity.GetType().Name).InsertOne(entity);
        }
    }
}
