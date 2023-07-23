using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Cache
{
    public class RedisCacheManager : ICacheManager
    {
        private protected ConnectionMultiplexer _connection;
        private protected IDatabase _db;

        public RedisCacheManager(IConfiguration configuration)
        {
            var connectionString = configuration["CacheOptions:Url"];
            var dbNumber = configuration["CacheOptions:DefaultDbNumber"];

            if (connectionString is null || dbNumber is null)
            {
                throw new RedisConnectionException(ConnectionFailureType.UnableToConnect, "Redis connection string not defined!");
            }

            _connection = ConnectionMultiplexer.Connect(connectionString);
            _db = _connection.GetDatabase(Convert.ToInt32(dbNumber));
        }

        public async Task<T> GetAsync<T>(string key, Func<T> acquire, TimeSpan expiry)
        {
            var isSet = _db.KeyExists(key);
            if(isSet) 
            {
                var cacheValue = await _db.StringGetAsync(key);
                if(!cacheValue.HasValue)
                {
                    return default(T);
                }

                var deSerializeCacheValue = JsonConvert.DeserializeObject<T>(cacheValue);

                return deSerializeCacheValue ?? default(T);
            }

            var result = acquire();
            var serializeItem = JsonConvert.SerializeObject(result);

            await _db.StringSetAsync(key, serializeItem, expiry);

            return result;
        }

        public void Remove(string key)
        {
            _db.KeyDelete(key);
        }

        public void Set(string key, object data, TimeSpan expiry)
        {
            if (data is null)
            {
                return;
            }
            var serializeObject = JsonConvert.SerializeObject(data);
            _db.StringSet(key, serializeObject, expiry);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
