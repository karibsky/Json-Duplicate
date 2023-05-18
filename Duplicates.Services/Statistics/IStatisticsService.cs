using System.Collections.Generic;
using Duplicates.Data.Entities;

namespace Duplicates.Services.Statistics
{
    public interface IStatisticsService
    { 
        IEnumerable<Statistic> GetStatisticsWithoutDuplicate(IEnumerable<Statistic> collection);
    }
}