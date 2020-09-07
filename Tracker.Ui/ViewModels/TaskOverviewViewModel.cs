using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Tracker.Core.Abstraction.Business;
using Tracker.Core.Abstraction.Model;
using Tracker.Core.Common.WorkItems;
using Tracker.Core.Domain.WorkTasks;
using Tracker.Core.Events.WorkTasks;
using Tracker.Ui.Model;
using Tracker.Ui.ViewModelHelper;

namespace Tracker.Ui.ViewModels
{
    public class TaskOverviewViewModel : ViewModelBase
    {
        private readonly ILogger<WorkItemListViewModel> logger;
        private readonly ICommandHandler<WorkTask> commandHandler;
        private readonly IDomain2ModelMapper<TaskCardModel, WorkTask> modelEntityMapper;

        public ObservableCollection<TaskCardModel> Tasks { get; set; } = new ObservableCollection<TaskCardModel>();
        public string SelectionDate { get; set; }

        public ICommand RefreshCommand { get; }


        public TaskOverviewViewModel(
            ILogger<WorkItemListViewModel> logger,
            ICommandHandler<WorkTask> commandHandler,
            IDomain2ModelMapper<TaskCardModel, WorkTask> modelEntityMapper,
            WorkTaskStartedEvent taskCreatedEvent)
        {
            this.logger = logger;
            this.commandHandler = commandHandler;
            this.modelEntityMapper = modelEntityMapper;
            taskCreatedEvent.RaiseTaskCreatedEvent += RefreshView;
            RefreshCommand = new RelayCommand(async () => await RefreshActivities());
            ReadActivities();
        }

        private void RefreshView(object sender, EventArgs e)
        {
            if(e.GetType() != typeof(WorkTaskEventArgs)) { return; }
            var args = e as WorkTaskEventArgs;
            RefreshActivity(args.WorkTask);
        }

        private Task RefreshActivities()
        {
            ReadActivities();
            return Task.CompletedTask;
        }

        private void ReadActivities()
        {
            logger.LogDebug("Refreshing local model from database");
            var selectedDate = !string.IsNullOrEmpty(SelectionDate) ? DateTime.Parse(SelectionDate) : DateTime.Today;
            Tasks = new ObservableCollection<TaskCardModel>();
            modelEntityMapper.MapToModel(commandHandler.Read(new CancellationToken()).Where(x => x.Start.Date == selectedDate.Date))
                             .ToList()
                             .ForEach(m => Tasks.Add(m));
            RaisePropertyChanged("Tasks");
        }

        private Task RefreshActivity(WorkTask addedWorkTask)
        {
            logger.LogDebug($"Add WorkTask with TaskId'{addedWorkTask.WorkTaskId}' to Tasks Collection");
            Tasks.Add(modelEntityMapper.MapToModel(addedWorkTask));
            RaisePropertyChanged("Tasks");
            return Task.CompletedTask;
        }
    }
}
