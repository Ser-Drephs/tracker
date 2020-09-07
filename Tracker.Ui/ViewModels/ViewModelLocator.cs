using Microsoft.Extensions.DependencyInjection;

namespace Tracker.Ui.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainViewModel>();
        public WorkItemListViewModel WorkItemListViewModel => App.ServiceProvider.GetRequiredService<WorkItemListViewModel>();
        public TaskOverviewViewModel TaskOverviewViewModel => App.ServiceProvider.GetRequiredService<TaskOverviewViewModel>();
    }
}
