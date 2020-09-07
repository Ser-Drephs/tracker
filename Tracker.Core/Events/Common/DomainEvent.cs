using System;
using Tracker.Core.Abstraction.Dates;

namespace Tracker.Core.Events.Common
{
    public class DomainEvent
    {
        public DateTime Now { get; }

        public DomainEvent(ITimestampService timestampService)
        { 
            Now = (timestampService ?? throw new ArgumentNullException(nameof(timestampService))).Now;
        }
    }
}
