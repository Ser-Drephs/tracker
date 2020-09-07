using System;
using Tracker.Core.Abstraction.Dates;

namespace Tracker.Core.Dates
{
    public class TimestampService : ITimestampService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
