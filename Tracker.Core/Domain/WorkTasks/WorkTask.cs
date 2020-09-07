using System;
using System.Diagnostics.CodeAnalysis;
using Tracker.Core.Common.WorkTasks;
using Tracker.Core.Domain.WorkItems;

namespace Tracker.Core.Domain.WorkTasks
{
    public struct WorkTask 
    {
        public Guid WorkTaskId { get; internal set; }
        public WorkItem WorkItem { get; internal set; }
        public DateTime Start { get; internal set; }
        public DateTime? End { get; internal set; }
        public WorkTaskActivity Activity { get; internal set; }

        internal WorkTask(Guid workTaskId, WorkItem workItem, DateTime start, DateTime? end, WorkTaskActivity activity)
        {
            WorkTaskId = workTaskId == Guid.Empty ? throw new WorkTaskGuidEmptyException() : workTaskId;
            WorkItem = workItem.IsEmpty() ? throw new WorkItemEmptyException() : workItem;
            Start = start;
            End = end;
            Activity = activity;
        }

        public static WorkTask StartWork(WorkItem workItem, WorkTaskActivity activity)
            => new WorkTask(Guid.NewGuid(), workItem, DateTime.Now, null, activity);

        public WorkTask EndWork() 
            => new WorkTask(this.WorkTaskId, this.WorkItem, this.Start, DateTime.Now, this.Activity);

        #region Comparer
        public override bool Equals(object obj)
        {
            return obj is WorkTask task &&
                  WorkItem.Equals(task.WorkItem) &&
                  Activity == task.Activity;
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return HashCode.Combine(WorkTaskId);
        }

        public static bool operator ==(WorkTask left, WorkTask right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(WorkTask left, WorkTask right)
        {
            return !(left == right);
        }
        #endregion
    }
}
