using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace ServiceStackLab.Redis
{
    public class RedisClientManager : IRedisClientManager
    {
        private static readonly JavaScriptSerializer JsonSerializer = new JavaScriptSerializer();
        private   ConnectionMultiplexer Connection { get; set; }
        private IDatabase DataBase { get; set; } 


        public string Host {
            get
            {
                //@Todo: 
                throw new NotImplementedException();
            }
        }
        public int Database
        {
            get { return DataBase.Database; }
        }


      
        public RedisClientManager() { }
        public RedisClientManager(string connectionString, int dataBaseNumber)
        {
            Connection = ConnectionMultiplexer.Connect(connectionString);
            DataBase = Connection.GetDatabase(dataBaseNumber);
        }

        public RedisClientManager(ConfigurationOptions configuraitonOptions, int dataBaseNumber)
        {
            Connection = ConnectionMultiplexer.Connect(configuraitonOptions);
            DataBase = Connection.GetDatabase(dataBaseNumber);
        }

        public void GetDatabase(string connectionString, int dataBaseNumber)
        {
            Connection = ConnectionMultiplexer.Connect(connectionString);
            DataBase = Connection.GetDatabase(dataBaseNumber);                
        }

        public void GetDatabase(ConfigurationOptions configuraitonOptions, int dataBaseNumber)
        {
            Connection = ConnectionMultiplexer.Connect(configuraitonOptions);
            DataBase = Connection.GetDatabase(dataBaseNumber);
        }
         

        public void Set<T>(T entity, string key, TimeSpan? expairationToken = null, When when = When.Always, CommandFlags flags = CommandFlags.None)
        {
            DataBase.StringSet(key, JsonSerializer.Serialize(entity) , expairationToken,when,flags);
        }

        public void SetAsync<T>(T entity, string key, TimeSpan? expairationToken = null, When when = When.Always, CommandFlags flags = CommandFlags.None)
        {
            DataBase.StringSetAsync(key, JsonSerializer.Serialize(entity), expairationToken,when,flags);
        }

        public void Close()
        {
            Connection.Close();
        }

        public bool Exist(string key, CommandFlags flags = CommandFlags.None)
        {
            return DataBase.KeyExists(key,flags);
        }

        public T Get<T>(string key, CommandFlags flags = CommandFlags.None)
        {
            /* Get cached value from Redis */
            var cachedContent = DataBase.StringGet(key, flags);

            /* check cachedContent has value, if yes, deserialize and return the cachedContent */
            if (cachedContent.HasValue)
                return JsonSerializer.Deserialize<T>(cachedContent);
            
            /* if cachedContent is null,  return defult(T) */
            return default(T);
        }

        public T GetAsync<T>(string key)
        {
            
            throw new NotImplementedException();
        }

        public bool Delete(string key, CommandFlags flags = CommandFlags.None)
        {
            return DataBase.KeyDelete(key, flags);
        }

        public bool DeleteAsync(string key, CommandFlags flags = CommandFlags.None)
        {
            throw new NotImplementedException();
            //return DataBase.KeyDeleteAsync()
        }
    }
}
