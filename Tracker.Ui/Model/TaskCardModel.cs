using Newtonsoft.Json;
using System;
using System.Windows.Media;
using Tracker.Core.Common.WorkItems;

namespace Tracker.Ui.Model
{
    public class TaskCardModel
    {
        public string StartTime => Start.ToString("t");
        public string Date      => Start.ToString("d");
        public string EndTime   => End.ToString("t");
        public DateTime Start { internal get; set; }
        public DateTime End { internal get; set; }
        public string TaskId { get; set; }
        public string Description { get; set; }
        public WorkItemType Type { get; set; }

        [JsonIgnore]
        public Brush BackgroundColor { get; set; } = new SolidColorBrush(Colors.Gray);

        [JsonIgnore]
        public Brush FontColor { get; set; } = new SolidColorBrush(Colors.Black);

        public TaskCardModel() { }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
