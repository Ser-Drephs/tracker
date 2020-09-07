using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using Tracker.Core.Abstraction.Business;
using Tracker.Core.Common.WorkItems;
using Tracker.Core.Common.WorkTasks;
using Tracker.Core.Domain.WorkItems;
using Tracker.Core.Domain.WorkTasks;
using Tracker.Core.Events.WorkTasks;
using Tracker.Ui.Model;

namespace Tracker.Ui.ViewModels
{
    public class WorkItemListViewModel:ViewModelBase
    {
        private readonly ILogger<WorkItemListViewModel> logger;
        private readonly ICommandHandler<WorkTask> commandHandler;
        private readonly WorkTaskStartedEvent taskCreatedEvent;

        public ObservableCollection<WorkItemListModel> WorkItems { get; set; } = new ObservableCollection<WorkItemListModel>();

        public ICommand StartTaskCommand { get; }
        public ICommand AddWorkItemCommand { get; }

        private void GetData()
        {
            WorkItems.Add(new WorkItemListModel() { TaskId = "1234", Description = "Story Description",   Activity = WorkTaskActivity.None, Type = WorkItemType.Story,   BubbleColor = GetBubbleColor(WorkItemType.Story) });
            WorkItems.Add(new WorkItemListModel() { TaskId = "2345", Description = "Task Description",    Activity = WorkTaskActivity.None, Type = WorkItemType.Task,    BubbleColor = GetBubbleColor(WorkItemType.Task) });
            WorkItems.Add(new WorkItemListModel() { TaskId = "3456", Description = "Feature Description", Activity = WorkTaskActivity.None, Type = WorkItemType.Feature, BubbleColor = GetBubbleColor(WorkItemType.Feature) });
            WorkItems.Add(new WorkItemListModel() { TaskId = "4567", Description = "Vision Description",  Activity = WorkTaskActivity.None, Type = WorkItemType.Vision,  BubbleColor = GetBubbleColor(WorkItemType.Vision) });
            WorkItems.Add(new WorkItemListModel() { TaskId = "5678", Description = "Bug Description",     Activity = WorkTaskActivity.None, Type = WorkItemType.Bug,     BubbleColor = GetBubbleColor(WorkItemType.Bug) });
            WorkItems.Add(new WorkItemListModel() { TaskId = "6789", Description = "Unknown Description", Activity = WorkTaskActivity.None, Type = WorkItemType.Unknown, BubbleColor = GetBubbleColor(WorkItemType.Unknown) });
        }

        public WorkItemListViewModel(
            ILogger<WorkItemListViewModel> logger, 
            ICommandHandler<WorkTask> commandHandler,
            WorkTaskStartedEvent taskCreatedEvent)
        {
            this.logger = logger;
            this.commandHandler = commandHandler;
            this.taskCreatedEvent = taskCreatedEvent;
            StartTaskCommand = new RelayCommand<object>(async (item) => await StartTaskActivity(item));
            AddWorkItemCommand = new RelayCommand(async () => await AddWorkItemActivity());
            GetData();
        }        
        
        private System.Threading.Tasks.Task StartTaskActivity(object item)
        {
            // Melde an übersicht, dass eine neue Task angefangen hat!
            if (item.GetType() != typeof(WorkItemListModel)) return null;
            var workItemListModel = (WorkItemListModel)item;
            logger.LogDebug($"Starting work on {workItemListModel}");
            var workItemObject = WorkItem.Create(workItemListModel.TaskId, workItemListModel.Description, workItemListModel.Type);
            // todo Assign Activity
            var workTask = WorkTask.StartWork(workItemObject, 0);
            var result = commandHandler.Create(workTask, new System.Threading.CancellationToken());
            taskCreatedEvent.Raise(new WorkTaskEventArgs(workTask));
            return result;
        }

        private System.Threading.Tasks.Task AddWorkItemActivity()
        {
            logger.LogDebug("Add new work item.");
            return System.Threading.Tasks.Task.CompletedTask;
        }

        protected Brush GetBubbleColor(WorkItemType type)
        {
            return type switch
            {
                (WorkItemType.Vision)  => new SolidColorBrush(Colors.Orange),
                (WorkItemType.Feature) => new SolidColorBrush(Colors.BlueViolet),
                (WorkItemType.Story)   => new SolidColorBrush(Colors.DodgerBlue),
                (WorkItemType.Bug)     => new SolidColorBrush(Colors.Red),
                (WorkItemType.Task)    => new SolidColorBrush(Colors.Gold),
                _                      => new SolidColorBrush(Colors.Silver),
            };
        }
    }
}
