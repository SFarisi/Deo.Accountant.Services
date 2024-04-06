
namespace Deo.Accountant.Services.Common
{
    public class CacheService : ICacheService
    {
        public T GetData<T>(string key)
        {
            throw new NotImplementedException();
        }

        public object RemoveData(string key)
        {
            throw new NotImplementedException();
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            throw new NotImplementedException();
        }
    }
}
