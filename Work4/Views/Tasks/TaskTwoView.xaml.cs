using System.Windows;
using System.Windows.Input;

namespace Work4.Views
{
    public partial class TaskTwoView : Window
    {
        public TaskTwoView() => InitializeComponent();

        private void ThisWindow_MouseLeftButtonDown(object sender,
            MouseButtonEventArgs e) => DragMove();
    }
}
