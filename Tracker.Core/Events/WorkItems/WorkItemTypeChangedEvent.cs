using System;
using Tracker.Core.Abstraction.Dates;
using Tracker.Core.Domain.WorkItems;
using Tracker.Core.Events.Common;

namespace Tracker.Core.Events.WorkItems
{
    public class WorkItemTypeChangedEvent: DomainEvent
    {
        public WorkItem WorkItem { get; }

        public WorkItemTypeChangedEvent(ITimestampService timestampService, WorkItem workItem) : base(timestampService)
        {
            if (workItem == null) throw new ArgumentNullException(nameof(workItem));
            WorkItem = workItem;
        }
    }
}
