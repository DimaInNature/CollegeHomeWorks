using System.Windows;
using System.Windows.Input;

namespace Work3.Views
{
    public partial class Task2View : Window
    {
        public Task2View() =>
            InitializeComponent();
        private void ThisWindow_MouseLeftButtonDown(object sender,
            MouseButtonEventArgs e) => DragMove();
    }
}