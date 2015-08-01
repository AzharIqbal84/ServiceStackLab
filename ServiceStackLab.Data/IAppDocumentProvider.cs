using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ServiceStackLab.Data
{
    public interface IAppDocumentProvider
    {
        string MongoDbHostAddress { get; }
        string MongoDbName { get; }

        void Connect(string connectionString, string database);

        IMongoCollection<T> CreateCollection<T>(string collectionName);

        void DropCollecion(string collectionName);

        T Insert<T>(T entity);



    }
}
