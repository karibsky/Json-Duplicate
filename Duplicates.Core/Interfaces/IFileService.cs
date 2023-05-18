using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Duplicates.Core.Interfaces
{
    public interface IFileService
    {
        Task<TEntity> Deserialize<TEntity>(byte[] bytes, NamingStrategy namingStrategy);
        string Serialize<TEntity>(TEntity collection, NamingStrategy namingStrategy);
    }
}