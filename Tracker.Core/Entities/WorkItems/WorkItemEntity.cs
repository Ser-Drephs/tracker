using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Tracker.Core.Entities.WorkItems
{
    public class WorkItemEntity
    {
        [Key]
        public Guid WorkItemId { get; set; }
        [NotNull]
        public string TaskId { get; set; }
        public string Description { get; set; }
        public int WorkItemType { get; set; }
        public WorkItemEntity() { }
    }
}
