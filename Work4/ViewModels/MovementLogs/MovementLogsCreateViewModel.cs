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
    public class MovementLogsCreateViewModel : BaseMovementLogsViewModel
    {
        public MovementLogsCreateViewModel()
        {
            InitializeRepositories();
            InitializeCommands();
            InitializeData();
        }

        #region Properties

        #region Commands

        public ICommand CreateMovementLogCommand { get; private set; }

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

        #endregion

        #endregion

        #region Commands

        private void CreateMovementLog(object obj)
        {
            if (SelectedEmploye != null && SelectedStructuralDivision != null && SelectedPost != null)
            {
                Salary = Rate + SelectedPost.Wage;

                var log = new MovementLog(SelectedEmploye.Id, SelectedStructuralDivision.Id, SelectedPost.Id,
                Convert.ToDouble(Rate), Convert.ToDouble(Salary), DateOfEmployment, OrderNumber, WorkStatus);
                _movementLogRepository.Create(log);

                MessageBox.Show("Movement log has been create", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("The user, position, or department was not selected", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            CreateMovementLogCommand = new DelegateCommandService(CreateMovementLog);
        }

        private void InitializeData()
        {
            Employees = _employeRepository.Read().ToList();
            StructuralDivisions = _structuralDivisionRepository.Read().ToList();
            Posts = _postRepository.Read().ToList();
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
