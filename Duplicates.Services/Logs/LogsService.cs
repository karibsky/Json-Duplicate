using System.Collections.Generic;
using System.Threading.Tasks;
using Duplicates.Data.Entities;
using Duplicates.Data.Repositories;

namespace Duplicates.Services.Logs
{
    public class LogsService : ILogsService
    {
        private readonly ILogsRepository _logsRepository;

        public LogsService(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public async Task<IEnumerable<Log>> GetAllAsync()
        {
            return await _logsRepository.GetAllAsync();
        }

        public async Task CreateAsync(Log log)
        {
            await _logsRepository.CreateAsync(log);
        }
    }
}