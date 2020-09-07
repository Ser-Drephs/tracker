using System;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Core.Entities.WorkTasks
{
    public class WorkTaskEntity
    {
        [Key]
        public Guid WorkTaskId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string TaskId { get; set; }
        public string Description { get; set; }
        public int WorkItemType { get; set; }
        public int Activity { get; set; }

        public WorkTaskEntity() { }
    }
}
