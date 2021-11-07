using System.Windows;
using Work3.Services;
using Work3.ViewModels;
using Work3.Views;

namespace Work3
{
    public partial class App : Application
    {
        public DisplayWindowService DisplayWindow { get; private set; } = new DisplayWindowService();

        public App() => RegisterWindows();

        private void RegisterWindows()
        {
            DisplayWindow.RegisterWindow<Task1ViewModel, Task1View>();
            DisplayWindow.RegisterWindow<Task2ViewModel, Task2View>();
        }
    }
}