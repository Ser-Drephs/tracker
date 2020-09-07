using System;
using System.Diagnostics.CodeAnalysis;

namespace Tracker.Core.Domain.WorkItems
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class WorkItemEmptyException : Exception
    {
        public WorkItemEmptyException() : base("Work item does not contain any information.") { }
        public WorkItemEmptyException(string message) : base(message) { }
        public WorkItemEmptyException(string message, Exception inner) : base(message, inner) { }
        protected WorkItemEmptyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
