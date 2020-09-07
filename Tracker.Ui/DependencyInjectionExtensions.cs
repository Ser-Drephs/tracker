using Microsoft.Extensions.DependencyInjection;
using Tracker.Core.Abstraction.Business;
using Tracker.Core.Abstraction.Dates;
using Tracker.Core.Abstraction.Entities;
using Tracker.Core.Abstraction.Model;
using Tracker.Core.Abstraction.Persistence;
using Tracker.Core.Business.WorkItems;
using Tracker.Core.Business.WorkTasks;
using Tracker.Core.Dates;
using Tracker.Core.Domain.WorkItems;
using Tracker.Core.Domain.WorkTasks;
using Tracker.Core.Entities.WorkTasks;
using Tracker.Core.Entities.WorkItems;
using Tracker.Core.Events.WorkTasks;
using Tracker.Core.Persistence;
using Tracker.Ui.Model;
using Tracker.Ui.ViewModels;
using Tracker.Ui.Views;
using Tracker.Ui.Views.UserControls;

namespace Tracker.Ui
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddAdditionalInjections(this IServiceCollection services) =>
            services.AddSingleton<ITimestampService, TimestampService>();

        public static IServiceCollection AddDbContext(this IServiceCollection services) =>
            services.AddSingleton<ITrackerDbContext, TrackerDbContext>()
                    .AddDbContext<TrackerDbContext>();

        public static IServiceCollection AddDomainEntityMapper(this IServiceCollection services) =>
            services.AddSingleton<IDomainEntityMapper<WorkItemEntity, WorkItem>, WorkItemDomainEntityMapper>()
                    .AddSingleton<IDomainEntityMapper<WorkTaskEntity, WorkTask>, WorkTaskDomainEntityMapper>();

        public static IServiceCollection AddModelEntityMapper(this IServiceCollection services) =>
            services.AddSingleton<IDomain2ModelMapper<TaskCardModel, WorkTask>, WorkTask2TaskCardMapper>();

        public static IServiceCollection AddBusinessLayer(this IServiceCollection services) =>
            services.AddSingleton<ICommandHandler<WorkItem>, WorkItemCommand>()
                    .AddSingleton<ICommandHandler<Core.Domain.WorkTasks.WorkTask>, WorkTaskCommand>();

        public static IServiceCollection AddViewModels(this IServiceCollection services) =>
            services.AddSingleton<MainViewModel>()
                    .AddSingleton<WorkItemListViewModel>()
                    .AddSingleton<TaskOverviewViewModel>();

        public static IServiceCollection AddViews(this IServiceCollection services) =>
            services.AddTransient<MainWindow>()
                    .AddTransient<WorkItemList>()
                    .AddTransient<TaskOverview>();

        public static IServiceCollection AddEvents(this IServiceCollection services) =>
            services.AddSingleton<WorkTaskStartedEvent>();
    }
}
