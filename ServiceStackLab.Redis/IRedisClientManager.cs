using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStackLab.Redis
{
    public interface IRedisClientManager
    {
 

        void GetDatabase(string connectionString, int dataBaseNumber);

        void GetDatabase(ConfigurationOptions configuraitonOptions, int dataBaseNumber);

        void Set<T>(T entity, string key, TimeSpan? expairationToken, When when = When.Always, CommandFlags flags = CommandFlags.None);

        void SetAsync<T>(T entity, string key, TimeSpan? expairationToken, When when = When.Always, CommandFlags flags = CommandFlags.None);

        bool Exist(string key, CommandFlags flags = CommandFlags.None);

        T Get<T>(string key, CommandFlags flags =  CommandFlags.None);

        T GetAsync<T>(string key);
        
        bool Delete(string key, CommandFlags flags = CommandFlags.None);

        bool DeleteAsync(string key, CommandFlags flags = CommandFlags.None);

        void Close();
        

        
    }
}
