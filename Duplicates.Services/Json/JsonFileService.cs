using System.IO;
using System.Threading.Tasks;
using Duplicates.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Duplicates.Services.Json
{
    public class JsonFileService : IFileService
    {
        public async Task<TEntity> Deserialize<TEntity>(byte[] bytes, NamingStrategy namingStrategy)
        {
            using var sr = new StreamReader(new MemoryStream(bytes));
            return JsonConvert.DeserializeObject<TEntity>(await sr.ReadToEndAsync(), new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = namingStrategy
                }
            });
        }

        public string Serialize<TEntity>(TEntity collection, NamingStrategy namingStrategy)
        {
            return JsonConvert.SerializeObject(collection, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = namingStrategy
                }
            });
        }
    }
}