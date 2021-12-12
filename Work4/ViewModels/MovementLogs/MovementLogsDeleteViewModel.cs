using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Services.Command;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.MovementLogs
{
    public class MovementLogsDeleteViewModel : BaseMovementLogsViewModel
    {
        public MovementLogsDeleteViewModel()
        {
            InitializeRepositories();
            InitializeCommands();
            InitializeData();
        }

        #region Properties

        #region Commands

        public ICommand DeleteMovementLogCommand { get; private set; }
        public ICommand SelectMovementLogCommand { get; private set; }

        #endregion

        #region Data

        public List<Employe> Employees
        {
            get => _employees is null
                ? new List<Employe>()
                : _employees;
            set
            {
                _employees = value is null
                    ? new List<Employe>()
                    : value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        private List<Employe> _employees;

        public List<Post> Posts
        {
            get => _posts is null
                ? new List<Post>()
                : _posts;
            set
            {
                _posts = value is null
                    ? new List<Post>()
                    : value;
                OnPropertyChanged(nameof(Posts));
            }
        }

        private List<Post> _posts;

        public List<StructuralDivision> StructuralDivisions
        {
            get => _structuralDivisions is null
                ? new List<StructuralDivision>()
                : _structuralDivisions;
            set
            {
                _structuralDivisions = value is null
                    ? new List<StructuralDivision>()
                    : value;
                OnPropertyChanged(nameof(StructuralDivisions));
            }
        }

        private List<StructuralDivision> _structuralDivisions;

        public List<MovementLog> MovementLogs
        {
            get => _movementLogs is null
                ? new List<MovementLog>()
                : _movementLogs;
            set
            {
                _movementLogs = value is null
                    ? new List<MovementLog>()
                    : value;
                OnPropertyChanged(nameof(MovementLogs));
            }
        }

        private List<MovementLog> _movementLogs;

        #endregion

        #region Selected

        public MovementLog SelectedMovementLog
        {
            get => _selectedMovementLog;
            set
            {
                _selectedMovementLog = value;
                OnPropertyChanged(nameof(SelectedMovementLog));
            }
        }

        private MovementLog _selectedMovementLog;

        #endregion

        #endregion

        #region Commands

        private void DeleteMovementLog(object obj)
        {
            if (SelectedMovementLog != null)
            {
                _movementLogRepository.Delete(SelectedMovementLog);

                InitializeData();

                MessageBox.Show("Movement log has been deleted", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Movement log is not selected", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SelectMovementLog(object obj)
        {
            if (SelectedMovementLog != null)
            {
                (Id, EmployeId, StructuralDivisionId, PostId, WorkStatus, Salary, Rate, OrderNumber, DateOfEmployment) =
                    (SelectedMovementLog.Id, SelectedMovementLog.EmployeId, SelectedMovementLog.StructuralDivisionId,
                    SelectedMovementLog.PostId, SelectedMovementLog.WorkStatus, SelectedMovementLog.Salary,
                    SelectedMovementLog.Rate, SelectedMovementLog.OrderNumber, SelectedMovementLog.DateOfEmployment);

                Employees = new List<Employe>
                {
                    _employeRepository.Read(SelectedMovementLog.EmployeId)
                };

                StructuralDivisions = new List<StructuralDivision>
                {
                    _structuralDivisionRepository.Read(SelectedMovementLog.StructuralDivisionId)
                };

                Posts = new List<Post>
                {
                    _postRepository.Read(SelectedMovementLog.PostId)
                };
            }
        }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            DeleteMovementLogCommand = new DelegateCommandService(DeleteMovementLog);
            SelectMovementLogCommand = new DelegateCommandService(SelectMovementLog);
        }

        private void InitializeData()
        {
            MovementLogs = _movementLogRepository.Read().ToList();
        }

        private void InitializeRepositories()
        {
            _postRepository = new SQLPostRepository();
            _structuralDivisionRepository = new SQLStructuralDivisionRepository();
            _employeRepository = new SQLEmployeRepository();
            _movementLogRepository = new SQLMovementLogRepository();
        }

        #endregion

    }
}
