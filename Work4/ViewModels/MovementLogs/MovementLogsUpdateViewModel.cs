using System;
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
    public class MovementLogsUpdateViewModel : BaseMovementLogsViewModel
    {
        public MovementLogsUpdateViewModel()
        {
            InitializeRepositories();
            InitializeCommands();
            InitializeData();
        }

        #region Properties

        #region Commands

        public ICommand UpdateMovementLogCommand { get; private set; }
        public ICommand SelectMovementLogCommand { get; private set; }

        #endregion

        #region Data

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

        public Employe SelectedEmploye
        {
            get => _selectedEmploye;
            set
            {
                _selectedEmploye = value;
                OnPropertyChanged(nameof(SelectedEmploye));
            }
        }

        private Employe _selectedEmploye;

        public StructuralDivision SelectedStructuralDivision
        {
            get => _selectedStructuralDivision;
            set
            {
                _selectedStructuralDivision = value;
                OnPropertyChanged(nameof(SelectedStructuralDivision));
            }
        }

        private StructuralDivision _selectedStructuralDivision;

        public Post SelectedPost
        {
            get => _selectedPost;
            set
            {
                _selectedPost = value;
                OnPropertyChanged(nameof(SelectedPost));
            }
        }

        private Post _selectedPost;

        #endregion

        #region Indexes

        public int? EmployeIndex
        {
            get => _employeIndex;

            set
            {
                _employeIndex = value;
                OnPropertyChanged(nameof(EmployeIndex));
            }
        }

        private int? _employeIndex;

        public int? PostIndex
        {
            get => _postIndex;

            set
            {
                _postIndex = value;
                OnPropertyChanged(nameof(PostIndex));
            }
        }

        private int? _postIndex;

        public int? StructuralDivisionIndex
        {
            get => _structuralDivisionIndex;

            set
            {
                _structuralDivisionIndex = value;
                OnPropertyChanged(nameof(StructuralDivisionIndex));
            }
        }

        private int? _structuralDivisionIndex;

        #endregion

        #endregion

        #region Commands

        private void UpdateMovementLog(object obj)
        {
            if (SelectedMovementLog != null && SelectedPost != null &&
                SelectedEmploye != null && SelectedStructuralDivision != null)
            {
                Salary = Rate + SelectedPost.Wage;

                var log = new MovementLog(SelectedMovementLog.Id, SelectedEmploye.Id, SelectedStructuralDivision.Id,
                    SelectedPost.Id, Convert.ToDouble(Rate), Convert.ToDouble(Salary), DateOfEmployment, OrderNumber, WorkStatus);

                _movementLogRepository.Update(log);

                InitializeData();

                MessageBox.Show("Movement log has been update", "Success",
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
            (Id, EmployeId, StructuralDivisionId, PostId, WorkStatus, Salary, Rate, OrderNumber, DateOfEmployment) =
                (SelectedMovementLog.Id, SelectedMovementLog.EmployeId, SelectedMovementLog.StructuralDivisionId,
                SelectedMovementLog.PostId, SelectedMovementLog.WorkStatus, SelectedMovementLog.Salary,
                SelectedMovementLog.Rate, SelectedMovementLog.OrderNumber, SelectedMovementLog.DateOfEmployment);

            Employees = _employeRepository.Read().ToList();
            StructuralDivisions = _structuralDivisionRepository.Read().ToList();
            Posts = _postRepository.Read().ToList();

            Indexator();
        }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            UpdateMovementLogCommand = new DelegateCommandService(UpdateMovementLog);
            SelectMovementLogCommand = new DelegateCommandService(SelectMovementLog);
        }

        private void Indexator()
        {
            int indexCounter = 0;

            foreach (var item in Employees)
            {
                if (item.Id == EmployeId)
                {
                    EmployeIndex = indexCounter;
                    SelectedEmploye = Employees[indexCounter];
                }
                indexCounter++;
            }

            indexCounter = 0;

            foreach (var item in StructuralDivisions)
            {
                if (item.Id == StructuralDivisionId)
                {
                    StructuralDivisionIndex = indexCounter;
                    SelectedStructuralDivision = StructuralDivisions[indexCounter];
                }
                indexCounter++;
            }

            indexCounter = 0;

            foreach (var item in Posts)
            {
                if (item.Id == PostId)
                {
                    PostIndex = indexCounter;
                    SelectedPost = Posts[indexCounter];
                }
                indexCounter++;
            }
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
