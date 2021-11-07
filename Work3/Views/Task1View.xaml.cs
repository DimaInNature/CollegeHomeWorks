using System.Windows;
using System.Windows.Input;

namespace Work3.Views
{
    public partial class Task1View : Window
    {
        public Task1View() =>
            InitializeComponent();

        private void ThisWindow_MouseLeftButtonDown(object sender,
            MouseButtonEventArgs e) => DragMove();     
    }
}