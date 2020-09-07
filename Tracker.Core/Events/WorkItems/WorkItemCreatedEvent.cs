using System;
using Tracker.Core.Abstraction.Dates;
using Tracker.Core.Domain.WorkItems;
using Tracker.Core.Events.Common;

namespace Tracker.Core.Events.WorkItems
{
    public class WorkItemCreatedEvent : DomainEvent
    {
        public WorkItem WorkItem { get; }

        public WorkItemCreatedEvent(ITimestampService timestampService, WorkItem workItem) : base(timestampService)
        {
            if (workItem == null) throw new ArgumentNullException(nameof(workItem));
            WorkItem = workItem;
        }
    }
}
