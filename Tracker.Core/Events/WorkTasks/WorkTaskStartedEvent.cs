using System;

namespace Tracker.Core.Events.WorkTasks
{
    public class WorkTaskStartedEvent
    {
        public event EventHandler RaiseTaskCreatedEvent;

        public void Raise(WorkTaskEventArgs e) 
        {
            OnRaiseTaskCreatedEvent(e);
        }

        protected virtual void OnRaiseTaskCreatedEvent(EventArgs e) 
            => RaiseTaskCreatedEvent?.Invoke(this, e);
    }
}
