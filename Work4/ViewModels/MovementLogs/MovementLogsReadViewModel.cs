using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Services.Command;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.MovementLogs
{
    public class MovementLogsReadViewModel : BaseMovementLogsViewModel
    {
        public MovementLogsReadViewModel()
        {
            InitializeRepositories();
            InitializeData();
            InitializeCommands();
        }

        #region Properties

        #region Commands

        public ICommand SelectMovementLogCommand { get; private set; }

        #endregion

        #region Data

        public IReadOnlyList<StructuralDivision> StructuralDivisions
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

        private IReadOnlyList<StructuralDivision> _structuralDivisions;

        public IReadOnlyList<Employe> Employees
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

        private IReadOnlyList<Employe> _employees;

        public IReadOnlyList<Post> Posts
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

        private IReadOnlyList<Post> _posts;

        public IReadOnlyList<MovementLog> MovementLogs
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

        private IReadOnlyList<MovementLog> _movementLogs;

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

        private void SelectMovementLog(object obj)
        {
            if (SelectedMovementLog != null)
            {
                (Id, EmployeId, StructuralDivisionId, WorkStatus, Salary, Rate, OrderNumber, DateOfEmployment) =
                    (SelectedMovementLog.Id, SelectedMovementLog.EmployeId, SelectedMovementLog.StructuralDivisionId,
                    SelectedMovementLog.WorkStatus, SelectedMovementLog.Salary, SelectedMovementLog.Rate,
                    SelectedMovementLog.OrderNumber, SelectedMovementLog.DateOfEmployment);

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

        private void InitializeData()
        {
            MovementLogs = _movementLogRepository.Read().ToList();
        }

        private void InitializeCommands()
        {
            SelectMovementLogCommand = new DelegateCommandService(SelectMovementLog);
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
