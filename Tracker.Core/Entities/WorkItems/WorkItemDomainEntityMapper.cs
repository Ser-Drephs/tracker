using Mapster;
using System.Collections.Generic;
using System.Linq;
using Tracker.Core.Abstraction.Entities;
using Tracker.Core.Domain.WorkItems;

namespace Tracker.Core.Entities.WorkItems
{
    public class WorkItemDomainEntityMapper : IDomainEntityMapper<WorkItemEntity, WorkItem>
    {
        private readonly TypeAdapterConfig config = new TypeAdapterConfig();
        public WorkItemDomainEntityMapper() => ApplyConfigurarion();

        public WorkItem MapToDomain(WorkItemEntity dbentity) => dbentity.Adapt<WorkItem>(config);

        public IEnumerable<WorkItem> MapToDomain(IEnumerable<WorkItemEntity> dbentities) => dbentities.Select(e => MapToDomain(e)).ToList();

        public WorkItemEntity MapToEntity(WorkItem domainObject) => domainObject.Adapt<WorkItemEntity>(config);

        public IEnumerable<WorkItemEntity> MapToEntity(IEnumerable<WorkItem> domainObjects) => domainObjects.Select(e => MapToEntity(e)).ToList();
        
        private void ApplyConfigurarion() { }
    }
}
