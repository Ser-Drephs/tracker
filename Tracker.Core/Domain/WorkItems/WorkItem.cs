using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Tracker.Core.Common.WorkItems;

namespace Tracker.Core.Domain.WorkItems
{
    public struct WorkItem
    {
        public Guid WorkItemId { get; internal set; }
        public string TaskId { get; internal set; }
        public string Description { get; internal set; }
        public WorkItemType WorkItemType { get; internal set; }

        internal WorkItem(Guid workitemId, string taskId, string description, WorkItemType workItemType)
        {
            WorkItemId = workitemId;
            TaskId = taskId ?? throw new ArgumentNullException(nameof(taskId));
            Description = description;
            WorkItemType = workItemType;
        }

        public static WorkItem Create(string taskId, string description)
            => new WorkItem(Guid.NewGuid(), taskId, description, 0);

        public static WorkItem Create(string taskId, string description, WorkItemType workItemType)
            => new WorkItem(Guid.NewGuid(), taskId, description, workItemType);

        public bool IsEmpty()
            => WorkItemId == Guid.Empty && TaskId == null;

        public override string ToString()
            => JsonConvert.SerializeObject(this);

        #region Comparer
        public override bool Equals(object obj)
        {
            return obj is WorkItem item &&
                   TaskId == item.TaskId &&
                   WorkItemType == item.WorkItemType;
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return HashCode.Combine(TaskId, WorkItemType);
        }

        public static bool operator ==(WorkItem left, WorkItem right)
        {
            return EqualityComparer<WorkItem>.Default.Equals(left, right);
        }

        public static bool operator !=(WorkItem left, WorkItem right)
        {
            return !(left == right);
        }
        #endregion
    }
}
