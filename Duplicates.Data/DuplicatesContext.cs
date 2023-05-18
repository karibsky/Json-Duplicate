using Duplicates.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Duplicates.Data
{
    public class DuplicatesContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        
        public DuplicatesContext(DbContextOptions<DuplicatesContext> options) : base(options)
        {
        }
    }
}