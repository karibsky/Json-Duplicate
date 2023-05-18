using System.Collections.Generic;
using System.Threading.Tasks;
using Duplicates.Data.Entities;

namespace Duplicates.Services.Logs
{
    public interface ILogsService
    {
        Task<IEnumerable<Log>> GetAllAsync();
        Task CreateAsync(Log log);
    }
}