using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tracker.Core.Abstraction.Business;
using Tracker.Core.Abstraction.Entities;
using Tracker.Core.Abstraction.Persistence;
using Tracker.Core.Domain.WorkItems;
using Tracker.Core.Entities.WorkItems;

namespace Tracker.Core.Business.WorkItems
{
    public class WorkItemCommand : ICommandHandler<WorkItem>
    {
        private readonly ILogger<WorkItemCommand> logger;
        private readonly ITrackerDbContext trackerDbContext;
        private readonly IDomainEntityMapper<WorkItemEntity, WorkItem> domainEntityMapper;

        public WorkItemCommand(
            ILogger<WorkItemCommand> logger,
            ITrackerDbContext trackerDbContext, 
            IDomainEntityMapper<WorkItemEntity, WorkItem> domainEntityMapper)
        {
            this.logger             = logger;
            this.trackerDbContext   = trackerDbContext   ?? throw new ArgumentNullException(nameof(trackerDbContext));
            this.domainEntityMapper = domainEntityMapper ?? throw new ArgumentNullException(nameof(domainEntityMapper));
        }

        public Task<int> Create(WorkItem domainObj, CancellationToken cancellationToken)
        {
            logger.LogDebug($"Adding work item {domainObj}");
            trackerDbContext.WorkItems.Add(domainEntityMapper.MapToEntity(domainObj));
            return trackerDbContext.SaveChangesAsync(cancellationToken);
        }

        public IEnumerable<WorkItem> Read(CancellationToken cancellationToken)
        {
            logger.LogDebug("Read work items from db");
            return domainEntityMapper.MapToDomain(trackerDbContext.WorkItems);
        }

        public Task<int> Update(WorkItem domainObj, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(WorkItem domainObj, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }        
    }
}
