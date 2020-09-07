using System.Windows.Media;
using Tracker.Core.Common.WorkItems;
using Tracker.Ui.Model;

namespace Tracker.Ui.ViewModelHelper
{
    public static class TaskCardColors
    {
        public static SolidColorBrush GetBackgroundColor(WorkItemType workItemType)
        {
            var color = workItemType switch
            {
                WorkItemType.Vision  => new SolidColorBrush(Colors.Orange),
                WorkItemType.Feature => new SolidColorBrush(Colors.BlueViolet),
                WorkItemType.Story   => new SolidColorBrush(Colors.DodgerBlue),
                WorkItemType.Bug     => new SolidColorBrush(Colors.Red),
                WorkItemType.Task    => new SolidColorBrush(Colors.Gold),
                _                    => new SolidColorBrush(Colors.Silver),
            };
            color.Opacity = 0.7;
            return color;
        }

        public static Brush GetFontColor(WorkItemType workItemType)
        {
            return workItemType switch
            {
                WorkItemType.Feature => new SolidColorBrush(Colors.White),
                WorkItemType.Bug     => new SolidColorBrush(Colors.White),
                _                    => new SolidColorBrush(Colors.Black),
            };
        }
    }
}
