using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Tracker.Core.Entities.WorkItems;
using Tracker.Core.Entities.WorkTasks;

namespace Tracker.Core.Abstraction.Persistence
{
    public interface ITrackerDbContext
    {
        DbSet<WorkItemEntity> WorkItems { get; }
        DbSet<WorkTaskEntity> WorkTasks { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    }
}
