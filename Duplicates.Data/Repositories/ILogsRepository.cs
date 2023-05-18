using System.Collections.Generic;
using System.Threading.Tasks;
using Duplicates.Data.Entities;

namespace Duplicates.Data.Repositories
{
    public interface ILogsRepository
    {
        Task<IEnumerable<Log>> GetAllAsync();
        Task CreateAsync(Log log);
    }
}