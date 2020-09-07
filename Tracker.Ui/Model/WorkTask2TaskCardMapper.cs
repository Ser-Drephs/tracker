using Mapster;
using System.Collections.Generic;
using System.Linq;
using Tracker.Core.Abstraction.Model;
using Tracker.Core.Domain.WorkTasks;
using Tracker.Ui.ViewModelHelper;

namespace Tracker.Ui.Model
{
    public class WorkTask2TaskCardMapper : IDomain2ModelMapper<TaskCardModel, WorkTask>
    {
        private readonly TypeAdapterConfig config = new TypeAdapterConfig();
        public WorkTask2TaskCardMapper() => ApplyConfigurarion();

        public TaskCardModel MapToModel(WorkTask entity) => entity.Adapt<TaskCardModel>(config);

        public IEnumerable<TaskCardModel> MapToModel(IEnumerable<WorkTask> entities) => entities.Select(e => MapToModel(e));

        private void ApplyConfigurarion()
        {
            config.NewConfig<WorkTask, TaskCardModel>()
                .ConstructUsing(d => new TaskCardModel() { 
                    FontColor       = TaskCardColors.GetFontColor(d.WorkItem.WorkItemType), 
                    BackgroundColor = TaskCardColors.GetBackgroundColor(d.WorkItem.WorkItemType) })
                .Map(d => d.Description, e => e.WorkItem.Description)
                .Map(d => d.TaskId,      e => e.WorkItem.TaskId)
                .Map(d => d.Type,        e => e.WorkItem.WorkItemType)
                .Map(d => d.Start,       e => e.Start)
                .Map(d => d.End,         e => e.End);
        }
    }
}
