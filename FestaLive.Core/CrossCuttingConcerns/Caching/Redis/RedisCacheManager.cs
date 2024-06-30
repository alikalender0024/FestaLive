using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Text;

namespace FestaLive.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        public void Add(string key, object data, int duration)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration=DateTime.Now.AddSeconds(30),
                SlidingExpiration=TimeSpan.FromSeconds(5)
            };

            _distributedCache.Set(key, SerializeObject(data), options);
        }

        public T Get<T>(string key)
        {
            var cachedData = _distributedCache.Get(key);
            return cachedData == null ? default : DeserializeObject<T>(cachedData);
        }

        public object Get(string key)
        {
            return _distributedCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _distributedCache.Get(key) != null;
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            // Redis üzerinde pattern ile eşleşen anahtarları kaldırmak için spesifik bir işlem yapmanız gerekebilir.
            // Bu işlem, örneğin StackExchange.Redis gibi bir kütüphane ile gerçekleştirilebilir.
            // Ancak bu kısım, kullanılan Redis kütüphanesine bağlı olarak değişebilir.
            throw new NotImplementedException("RemoveByPattern is not implemented for RedisCacheManager.");
        }

        // Nesneyi JSON'a dönüştürme
        private byte[] SerializeObject(object obj)
        {
            if (obj == null)
                return null;

            string jsonString = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        // JSON'u nesneye dönüştürme
        private T DeserializeObject<T>(byte[] data)
        {
            if (data == null)
                return default;

            string jsonString = Encoding.UTF8.GetString(data);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
