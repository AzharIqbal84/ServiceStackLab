using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ServiceStackLab.Data
{
    public class AppDocumentProvider : IAppDocumentProvider
    {

        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public string MongoDbHostAddress
        {
            get
            {
                return _client.Settings.Server.Host;
            }
        }

        public string MongoDbName
        {
            get
            {
                return _database.DatabaseNamespace.DatabaseName;
            }
        }

        public void Connect(string connectionString, string database)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(database);
        }

  
        public IMongoCollection<T> GetCollection<T>(string collectionName) where T : class
        {
            return _database.GetCollection<T>(collectionName);
        }

        public void DropCollecion(string collectionName)
        {
            _database.DropCollectionAsync(collectionName);
        }

        public void Insert<T>(T entity, string collectionName) 
        {
            //var collection = GetCollection<T>(collectionName);
            //collection.InsertOneAsync(entity);
        }

        public IMongoCollection<T> CreateCollection<T>(string collectionName)
        {
            throw new NotImplementedException();
        }

        public T Insert<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
