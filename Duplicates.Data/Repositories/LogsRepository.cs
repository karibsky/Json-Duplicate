using System.Collections.Generic;
using System.Threading.Tasks;
using Duplicates.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Duplicates.Data.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly DuplicatesContext _context;

        public LogsRepository(DuplicatesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Log>> GetAllAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task CreateAsync(Log log)
        {
            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}