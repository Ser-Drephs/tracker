using System;
using Tracker.Core.Domain.WorkTasks;

namespace Tracker.Core.Events.WorkTasks
{
    public class WorkTaskEventArgs : EventArgs
    {
        public WorkTaskEventArgs(WorkTask workTask)
        {
            WorkTask = workTask;
        }

        public WorkTask WorkTask { get; }
    }
}
