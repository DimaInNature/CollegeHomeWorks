using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Work4.Data;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Services.Command;
using Work4.ViewModels.Base;
using Work4.Views;

namespace Work4.ViewModels.Tasks
{
    public class TaskThreeViewModel : BaseViewModel
    {
        public TaskThreeViewModel()
        {
            InitializeCommands();
            InitializeRepositories();
            InitializeData();
        }

        #region Properties

        #region Commands

        public ICommand ShowPreviousWindowClickCommand { get; private set; }

        public ICommand ShowNextWindowClickCommand { get; private set; }

        public ICommand SelectStructuralDivisionCommand { get; private set; }

        #endregion

        #region Data

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

        #region Select

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

        #region Repositories

        private IRepository<StructuralDivision> _structuralDivisionRepository;

        private IRepository<Employe> _employeRepository;

        private IMovementLogRepository _movementLogRepository;

        #endregion

        #endregion

        #region Methods

        #region Commands

        private void ShowPreviousWindowClick(object obj) =>
            (Application.Current as App).DisplayWindow
                .Show(new TaskTwoViewModel(), obj as TaskThreeView);

        private void ShowNextWindowClick(object obj) =>
            (Application.Current as App).DisplayWindow
                .Show(new TaskFiveViewModel(), obj as TaskThreeView);

        private void SelectStructuralDivision(object obj)
        {
            var divisionByName = _structuralDivisionRepository.Read()
                .FirstOrDefault(a => a.Name == SelectedStructuralDivision.Name);

            var empList = new List<Employe>();

            var empId = _movementLogRepository.Read()
                .Where(w => w.StructuralDivisionId == divisionByName.Id)
                .Select(w => w.EmployeId)
                .ToList();

            for (int i = 0; i < empId.Count; i++)
            {
                var employe = _employeRepository.Read()
                    .FirstOrDefault(w => w.Id == empId[i]);

                empList.Add(employe);
            }

            Employees = empList
                .OrderBy(n => n.Name)
                .ToList();
        }

        #endregion

        private void InitializeCommands()
        {
            ShowPreviousWindowClickCommand = new DelegateCommandService(ShowPreviousWindowClick);
            ShowNextWindowClickCommand = new DelegateCommandService(ShowNextWindowClick);
            SelectStructuralDivisionCommand = new DelegateCommandService(SelectStructuralDivision);
        }

        private void InitializeData()
        {
            var divisions = _structuralDivisionRepository.Read()
                .GroupBy(x => x.Name)
                .Select(s => s.FirstOrDefault())
                .ToList();

            StructuralDivisions = divisions;
        }

        private void InitializeRepositories()
        {
            _structuralDivisionRepository = new SQLStructuralDivisionRepository();
            _employeRepository = new SQLEmployeRepository();
            _movementLogRepository = new SQLMovementLogRepository();
        }

        #endregion

    }
}
