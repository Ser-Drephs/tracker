using System;
using System.Diagnostics.CodeAnalysis;

namespace Tracker.Core.Domain.WorkTasks
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class WorkTaskGuidEmptyException : Exception
    {
        public WorkTaskGuidEmptyException(): base("Work task Guid is empty.") { }
        public WorkTaskGuidEmptyException(string message) : base(message) { }
        public WorkTaskGuidEmptyException(string message, Exception inner) : base(message, inner) { }
        protected WorkTaskGuidEmptyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
