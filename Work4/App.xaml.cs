using System.Windows;
using Work4.Services;
using Work4.ViewModels;
using Work4.ViewModels.Tasks;
using Work4.Views;

namespace Work4
{
    public partial class App : Application
    {
        public DisplayWindowService DisplayWindow { get; private set; } = new DisplayWindowService();

        public App()
        {
            RegisterWindows();
        }

        private void RegisterWindows()
        {
            DisplayWindow.RegisterWindow<TaskCRUDViewModel, TaskCRUDView>();
            DisplayWindow.RegisterWindow<TaskTwoViewModel, TaskTwoView>();
            DisplayWindow.RegisterWindow<TaskThreeViewModel, TaskThreeView>();
            DisplayWindow.RegisterWindow<TaskFiveViewModel, TaskFiveView>();
        }
    }
}
