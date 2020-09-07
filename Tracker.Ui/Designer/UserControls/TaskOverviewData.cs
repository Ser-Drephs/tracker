using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tracker.Core.Common.WorkItems;
using Tracker.Core.Events.WorkTasks;
using Tracker.Ui.Model;
using Tracker.Ui.ViewModelHelper;
using Tracker.Ui.ViewModels;

namespace Tracker.Ui.Designer.UserControls
{
    public class TaskOverviewData : TaskOverviewViewModel
    {
        public TaskOverviewData() : base(null, null, null, new WorkTaskStartedEvent())
        {
            Tasks = new ObservableCollection<TaskCardModel>(){
                { new TaskCardModel(){ Start = DateTime.Now, End = DateTime.Now.AddMinutes(39), TaskId = "1234", Description = "Feature Description", Type = WorkItemType.Feature, BackgroundColor = TaskCardColors.GetBackgroundColor(WorkItemType.Feature), FontColor = TaskCardColors.GetFontColor(WorkItemType.Feature)} },
                { new TaskCardModel(){ Start = DateTime.Now, End = DateTime.Now.AddMinutes(41), TaskId = "2345", Description = "Bug Description",     Type = WorkItemType.Bug,     BackgroundColor = TaskCardColors.GetBackgroundColor(WorkItemType.Bug),     FontColor = TaskCardColors.GetFontColor(WorkItemType.Bug) } },
                { new TaskCardModel(){ Start = DateTime.Now, End = DateTime.Now.AddMinutes(23), TaskId = "3456", Description = "Story Description",   Type = WorkItemType.Story,   BackgroundColor = TaskCardColors.GetBackgroundColor(WorkItemType.Story),   FontColor = TaskCardColors.GetFontColor(WorkItemType.Story) } },
                { new TaskCardModel(){ Start = DateTime.Now, End = DateTime.Now.AddMinutes(54), TaskId = "4567", Description = "Task Description",    Type = WorkItemType.Task,    BackgroundColor = TaskCardColors.GetBackgroundColor(WorkItemType.Task),    FontColor = TaskCardColors.GetFontColor(WorkItemType.Task) } },
                { new TaskCardModel(){ Start = DateTime.Now, End = DateTime.Now.AddMinutes(12), TaskId = "5678", Description = "Unknown Description", Type = WorkItemType.Unknown, BackgroundColor = TaskCardColors.GetBackgroundColor(WorkItemType.Unknown), FontColor = TaskCardColors.GetFontColor(WorkItemType.Unknown) } },
                { new TaskCardModel(){ Start = DateTime.Now, End = DateTime.Now.AddMinutes(37), TaskId = "6789", Description = "Vision Description",  Type = WorkItemType.Vision,  BackgroundColor = TaskCardColors.GetBackgroundColor(WorkItemType.Vision),  FontColor = TaskCardColors.GetFontColor(WorkItemType.Vision) } }
            };
        }
    }
}
