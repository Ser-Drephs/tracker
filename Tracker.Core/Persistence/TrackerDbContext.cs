using Microsoft.EntityFrameworkCore;
using Tracker.Core.Abstraction.Persistence;
using Tracker.Core.Entities.WorkItems;
using Tracker.Core.Entities.WorkTasks;

namespace Tracker.Core.Persistence
{
    public class TrackerDbContext : DbContext, ITrackerDbContext
    {
        public DbSet<WorkItemEntity> WorkItems { get; set; }

        public DbSet<WorkTaskEntity> WorkTasks { get; set; }

        public TrackerDbContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=tracker.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrackerDbContext).Assembly);

    }
}
