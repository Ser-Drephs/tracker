using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tracker.Core.Abstraction.Business;
using Tracker.Core.Abstraction.Entities;
using Tracker.Core.Abstraction.Persistence;
using Tracker.Core.Domain.WorkTasks;
using Tracker.Core.Entities.WorkTasks;

namespace Tracker.Core.Business.WorkTasks
{
    public class WorkTaskCommand : ICommandHandler<WorkTask>
    {
        private readonly ILogger<WorkTaskCommand> logger;
        private readonly ITrackerDbContext trackerDbContext;
        private readonly IDomainEntityMapper<WorkTaskEntity, WorkTask> domainEntityMapper;

        public WorkTaskCommand(
            ILogger<WorkTaskCommand> logger, 
            ITrackerDbContext trackerDbContext,
            IDomainEntityMapper<WorkTaskEntity, WorkTask> domainEntityMapper)
        {
            this.logger             = logger;
            this.trackerDbContext   = trackerDbContext   ?? throw new ArgumentNullException(nameof(trackerDbContext));
            this.domainEntityMapper = domainEntityMapper ?? throw new ArgumentNullException(nameof(domainEntityMapper));
        }

        public Task<int> Create(WorkTask domainObj, CancellationToken cancellationToken)
        {
            logger.LogDebug($"Adding WorkTask {domainObj}");
            trackerDbContext.WorkTasks.Add(domainEntityMapper.MapToEntity(domainObj));
            return trackerDbContext.SaveChangesAsync(cancellationToken);
        }
        
        public IEnumerable<WorkTask> Read(CancellationToken cancellationToken)
        {
            logger.LogDebug("Read WorkTasks from db");
            return domainEntityMapper.MapToDomain(trackerDbContext.WorkTasks);
        }

        public Task<int> Update(WorkTask domainObj, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(WorkTask domainObj, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
