using Mapster;
using System.Collections.Generic;
using System.Linq;
using Tracker.Core.Abstraction.Entities;
using Tracker.Core.Common.WorkItems;
using Tracker.Core.Domain.WorkItems;
using Tracker.Core.Domain.WorkTasks;

namespace Tracker.Core.Entities.WorkTasks
{
    public class WorkTaskDomainEntityMapper : IDomainEntityMapper<WorkTaskEntity, WorkTask>
    {
        private readonly TypeAdapterConfig config = new TypeAdapterConfig();

        public WorkTaskDomainEntityMapper() => ApplyConfigurarion();

        public WorkTask MapToDomain(WorkTaskEntity dbentity) => dbentity.Adapt<WorkTask>(config);

        public IEnumerable<WorkTask> MapToDomain(IEnumerable<WorkTaskEntity> dbentities) => dbentities.Select(e => MapToDomain(e));

        public WorkTaskEntity MapToEntity(WorkTask domainObject) => domainObject.Adapt<WorkTaskEntity>(config);

        public IEnumerable<WorkTaskEntity> MapToEntity(IEnumerable<WorkTask> domainObjects) => domainObjects.Select(d => MapToEntity(d));

        private void ApplyConfigurarion()
        {
            config.NewConfig<WorkTask, WorkTaskEntity>()
                .Map(d => d.TaskId, e => e.WorkItem.TaskId)
                .Map(d => d.Description, e => e.WorkItem.Description)
                .Map(d => d.WorkItemType, e => e.WorkItem.WorkItemType);

            config.NewConfig<WorkTaskEntity, WorkTask>()
                .Map(e => e.WorkItem, d => WorkItem.Create(d.TaskId, d.Description, (WorkItemType)d.WorkItemType));
        }
    }
}
