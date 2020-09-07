using System.Collections.ObjectModel;
using Tracker.Core.Common.WorkItems;
using Tracker.Core.Common.WorkTasks;
using Tracker.Ui.Model;
using Tracker.Ui.ViewModels;

namespace Tracker.Ui.Designer.UserControls
{
    public class WorkItemListData : WorkItemListViewModel
    {
        public WorkItemListData() : base(null, null, null)
        {
            WorkItems = new ObservableCollection<WorkItemListModel>(){
                { new WorkItemListModel(){ TaskId="1234", Description="Story Description",   Activity=WorkTaskActivity.None, Type=WorkItemType.Story,   BubbleColor = GetBubbleColor(WorkItemType.Story) } },
                { new WorkItemListModel(){ TaskId="2345", Description="Task Description",    Activity=WorkTaskActivity.None, Type=WorkItemType.Task,    BubbleColor = GetBubbleColor(WorkItemType.Task) } },
                { new WorkItemListModel(){ TaskId="3456", Description="Feature Description", Activity=WorkTaskActivity.None, Type=WorkItemType.Feature, BubbleColor = GetBubbleColor(WorkItemType.Feature) } },
                { new WorkItemListModel(){ TaskId="4567", Description="Vision Description",  Activity=WorkTaskActivity.None, Type=WorkItemType.Vision,  BubbleColor = GetBubbleColor(WorkItemType.Vision) } },
                { new WorkItemListModel(){ TaskId="5678", Description="Bug Description",     Activity=WorkTaskActivity.None, Type=WorkItemType.Bug,     BubbleColor = GetBubbleColor(WorkItemType.Bug) } },
                { new WorkItemListModel(){ TaskId="6789", Description="Unknown Description", Activity=WorkTaskActivity.None, Type=WorkItemType.Unknown, BubbleColor = GetBubbleColor(WorkItemType.Unknown) } }
            };
        }
    }
}
