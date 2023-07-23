using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Cache
{
    public interface ICacheManager : IDisposable
    {
        Task<T> GetAsync<T>(string key, Func<T> acquire, TimeSpan expiry);

        void Set(string key, object data, TimeSpan expiry);

        void Remove(string key);
    }
}
