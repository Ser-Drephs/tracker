using Newtonsoft.Json;
using System.Windows.Media;
using Tracker.Core.Common.WorkItems;
using Tracker.Core.Common.WorkTasks;

namespace Tracker.Ui.Model
{
    public class WorkItemListModel
    {
        public string TaskId { get; set; }
        public string Description { get; set; }
        public WorkTaskActivity Activity { get; set; }
        public WorkItemType Type { get; set; }

        [JsonIgnore]
        public Brush BubbleColor { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
