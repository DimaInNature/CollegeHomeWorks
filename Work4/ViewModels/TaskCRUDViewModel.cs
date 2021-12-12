using System.Windows;
using System.Windows.Input;
using Work4.Services.Command;
using Work4.ViewModels.Base;
using Work4.ViewModels.Tasks;
using Work4.Views;
using Work4.Views.Employees;
using Work4.Views.MovementLogs;
using Work4.Views.Posts;
using Work4.Views.StructuralDivisions;

namespace Work4.ViewModels
{
    public class TaskCRUDViewModel : BaseViewModel
    {
        public TaskCRUDViewModel()
        {
            InitializeCommands();
            InitializeFrames();
        }

        #region Propeties

        #region Commands

        public ICommand EmployeCreateButtonClick { get; private set; }
        public ICommand EmployeReadButtonClick { get; private set; }
        public ICommand EmployeUpdateButtonClick { get; private set; }
        public ICommand EmployeDeleteButtonClick { get; private set; }

        public ICommand MovementLogsCreateButtonClick { get; private set; }
        public ICommand MovementLogsReadButtonClick { get; private set; }
        public ICommand MovementLogsUpdateButtonClick { get; private set; }
        public ICommand MovementLogsDeleteButtonClick { get; private set; }

        public ICommand PostCreateButtonClick { get; private set; }
        public ICommand PostReadButtonClick { get; private set; }
        public ICommand PostUpdateButtonClick { get; private set; }
        public ICommand PostDeleteButtonClick { get; private set; }

        public ICommand StructuralDivisionsCreateButtonClick { get; private set; }
        public ICommand StructuralDivisionsReadButtonClick { get; private set; }
        public ICommand StructuralDivisionsUpdateButtonClick { get; private set; }
        public ICommand StructuralDivisionsDeleteButtonClick { get; private set; }

        public ICommand TaskButtonClick { get; private set; }

        #endregion

        #region Frames

        public object EmployeFrameSource
        {
            get => _employeFrameSource;
            set
            {
                _employeFrameSource = value;
                OnPropertyChanged(nameof(EmployeFrameSource));
            }
        }

        private object _employeFrameSource;

        public object MovementLogsFrameSource
        {
            get => _movementLogsFrameSource;
            set
            {
                _movementLogsFrameSource = value;
                OnPropertyChanged(nameof(MovementLogsFrameSource));
            }
        }

        private object _movementLogsFrameSource;

        public object PostsFrameSource
        {
            get => _postsFrameSource;
            set
            {
                _postsFrameSource = value;
                OnPropertyChanged(nameof(PostsFrameSource));
            }
        }

        private object _postsFrameSource;

        public object StructuralDivisionFrameSource
        {
            get => _structuralDivisionFrameSource;
            set
            {
                _structuralDivisionFrameSource = value;
                OnPropertyChanged(nameof(StructuralDivisionFrameSource));
            }
        }

        private object _structuralDivisionFrameSource;

        #endregion

        #endregion

        #region Methods

        #region Commands

        #region Employe

        private void EmployeCreateButtonClickCommand(object obj) => 
            EmployeFrameSource = new EmployeCreateView();

        private void EmployeReadButtonClickCommand(object obj) =>
            EmployeFrameSource = new EmployeReadView();

        private void EmployeUpdateButtonClickCommand(object obj) => 
            EmployeFrameSource = new EmployeUpdateView();

        private void EmployeDeleteButtonClickCommand(object obj) =>
            EmployeFrameSource = new EmployeDeleteView();

        #endregion

        #region Movement Logs

        private void MovementLogsCreateButtonClickCommand(object obj) =>
            MovementLogsFrameSource = new MovementLogsCreateView();

        private void MovementLogsReadButtonClickCommand(object obj) =>
            MovementLogsFrameSource = new MovementLogsReadView();

        private void MovementLogsUpdateButtonClickCommand(object obj) =>
            MovementLogsFrameSource = new MovementLogsUpdateView();

        private void MovementLogsDeleteButtonClickCommand(object obj) =>
            MovementLogsFrameSource = new MovementLogsDeleteView();

        #endregion

        #region Post

        private void PostCreateButtonClickCommand(object obj) =>
            PostsFrameSource = new PostCreateView();

        private void PostReadButtonClickCommand(object obj) =>
            PostsFrameSource = new PostReadView();

        private void PostUpdateButtonClickCommand(object obj) =>
            PostsFrameSource = new PostUpdateView();

        private void PostDeleteButtonClickCommand(object obj) =>
            PostsFrameSource = new PostDeleteView();

        #endregion

        #region Employe

        private void StructuralDivisionsCreateButtonClickCommand(object obj) =>
            StructuralDivisionFrameSource = new StructuralDivisionsCreateView();

        private void StructuralDivisionsReadButtonClickCommand(object obj) =>
            StructuralDivisionFrameSource = new StructuralDivisionsReadView();

        private void StructuralDivisionsUpdateButtonClickCommand(object obj) =>
            StructuralDivisionFrameSource = new StructuralDivisionsUpdateView();

        private void StructuralDivisionsDeleteButtonClickCommand(object obj) =>
            StructuralDivisionFrameSource = new StructuralDivisionsDeleteView();

        #endregion

        private void TaskButtonClickCommand(object obj) =>
            (Application.Current as App).DisplayWindow
               .Show(new TaskTwoViewModel(), obj as TaskCRUDView);
        
        #endregion

        private void InitializeCommands()
        {
            EmployeCreateButtonClick = new DelegateCommandService(EmployeCreateButtonClickCommand);
            EmployeReadButtonClick = new DelegateCommandService(EmployeReadButtonClickCommand);
            EmployeUpdateButtonClick = new DelegateCommandService(EmployeUpdateButtonClickCommand);
            EmployeDeleteButtonClick = new DelegateCommandService(EmployeDeleteButtonClickCommand);

            MovementLogsCreateButtonClick = new DelegateCommandService(MovementLogsCreateButtonClickCommand);
            MovementLogsReadButtonClick = new DelegateCommandService(MovementLogsReadButtonClickCommand);
            MovementLogsUpdateButtonClick = new DelegateCommandService(MovementLogsUpdateButtonClickCommand);
            MovementLogsDeleteButtonClick = new DelegateCommandService(MovementLogsDeleteButtonClickCommand);

            PostCreateButtonClick = new DelegateCommandService(PostCreateButtonClickCommand);
            PostReadButtonClick = new DelegateCommandService(PostReadButtonClickCommand);
            PostUpdateButtonClick = new DelegateCommandService(PostUpdateButtonClickCommand);
            PostDeleteButtonClick = new DelegateCommandService(PostDeleteButtonClickCommand);

            StructuralDivisionsCreateButtonClick = new DelegateCommandService(StructuralDivisionsCreateButtonClickCommand);
            StructuralDivisionsReadButtonClick = new DelegateCommandService(StructuralDivisionsReadButtonClickCommand);
            StructuralDivisionsUpdateButtonClick = new DelegateCommandService(StructuralDivisionsUpdateButtonClickCommand);
            StructuralDivisionsDeleteButtonClick = new DelegateCommandService(StructuralDivisionsDeleteButtonClickCommand);

            TaskButtonClick = new DelegateCommandService(TaskButtonClickCommand);
        }

        private void InitializeFrames()
        {
            EmployeFrameSource = new EmployeCreateView();
            MovementLogsFrameSource = new MovementLogsCreateView();
            PostsFrameSource = new PostCreateView();
            StructuralDivisionFrameSource = new StructuralDivisionsCreateView();
        }

        #endregion

    }
}
