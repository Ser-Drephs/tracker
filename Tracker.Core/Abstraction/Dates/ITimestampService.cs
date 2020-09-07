using System;

namespace Tracker.Core.Abstraction.Dates
{
    public interface ITimestampService
    {
        DateTime Now { get; }
    }
}
