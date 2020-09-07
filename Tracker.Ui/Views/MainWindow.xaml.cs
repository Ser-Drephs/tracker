using System.ComponentModel;
using System.Windows;
using Tracker.Ui.Properties;

namespace Tracker.Ui.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Settings MainWindowSettings = Settings.Default;

        public MainWindow()
        {
            InitializeComponent();
            RestoreWindowLocations();
        }

        void RestoreWindowLocations()
        {
            if (MainWindowSettings.WindowWidth > 0)             this.Width = MainWindowSettings.WindowWidth;
            if (MainWindowSettings.WindowHeight > 0)            this.Height = MainWindowSettings.WindowHeight;
            if (MainWindowSettings.SideBarSplitterLocation > 0) this.SideBar.Width = new GridLength(MainWindowSettings.SideBarSplitterLocation);
            if (MainWindowSettings.WindowLocationX > 0)         this.Top = MainWindowSettings.WindowLocationX;
            if (MainWindowSettings.WindowLocationY > 0)         this.Left = MainWindowSettings.WindowLocationY;
            if (MainWindowSettings.WindowMaximizedState)        this.WindowState = WindowState.Maximized;
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MainWindowSettings.WindowMaximizedState        = this.WindowState == WindowState.Maximized;
            MainWindowSettings.SideBarSplitterLocation     = this.SideBar.ActualWidth;
            // Only save new size and location setting if the window was not in maximized state.
            // This keeps the location throughout the maximized state.
            if (this.WindowState != WindowState.Maximized)
            {
                MainWindowSettings.WindowHeight            = this.ActualHeight;
                MainWindowSettings.WindowWidth             = this.ActualWidth;
                MainWindowSettings.WindowLocationX         = this.Top;
                MainWindowSettings.WindowLocationY         = this.Left;
            }
            MainWindowSettings.Save();
        }
    }
}
