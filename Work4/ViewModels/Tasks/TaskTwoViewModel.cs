using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Work4.Data;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Services.Command;
using Work4.Struct;
using Work4.ViewModels.Base;
using Work4.Views;

namespace Work4.ViewModels.Tasks
{
    public class TaskTwoViewModel : BaseViewModel
    {
        public TaskTwoViewModel()
        {
            InitializeCommands();
            InitializeRepositories();
            InitializeData();
        }

        #region Properties

        #region Commands

        public ICommand ShowNextWindowClickCommand { get; private set; }

        #endregion

        #region Data

        public List<EmployeStruct> Employees
        {
            get => _employees is null
                ? new List<EmployeStruct>()
                : _employees;
            set
            {
                _employees = value is null
                    ? new List<EmployeStruct>()
                    : value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        private List<EmployeStruct> _employees;

        #endregion

        #region Repositories

        private IRepository<Employe> _employeRepository;

        private IMovementLogRepository _movementLogRepository;

        #endregion

        #endregion

        #region Methods

        #region Commands

        private void ShowNextWindowClick(object obj) =>
            (Application.Current as App).DisplayWindow
                .Show(new TaskThreeViewModel(), obj as TaskTwoView);

        #endregion

        private void InitializeCommands()
        {
            ShowNextWindowClickCommand = new DelegateCommandService(ShowNextWindowClick);
        }

        private void InitializeRepositories()
        {
            _employeRepository = new SQLEmployeRepository();
            _movementLogRepository = new SQLMovementLogRepository();
        }

        private void InitializeData()
        {
            var idList = _movementLogRepository.Read()
                .Where(e => e.WorkStatus == "Work")
                .Select(w => w.EmployeId)
                .ToList();

            var expList = _movementLogRepository.Read()
                .Where(e => e.WorkStatus == "Work")
                .Select(w => w.DateOfEmployment)
                .ToList();

            List<Employe> employeList = new List<Employe>();

            List<EmployeStruct> queryList = new List<EmployeStruct>();

            for (int i = 0; i < idList.Count; i++)
            {
                var employe = _employeRepository.Read(idList[i]);
                employeList.Add(employe);
            }

            for (int i = 0; i < employeList.Count; i++)
            {
                var employe = new EmployeStruct()
                {
                    Id = employeList[i].Id,
                    Name = employeList[i].Name,
                    Surname = employeList[i].Surname,
                    Address = employeList[i].Address,
                    BirthDay = employeList[i].BirthDay,
                    Gender = employeList[i].Gender,
                    Patronymic = employeList[i].Patronymic,
                    WorkExperience = DateTime.Now.Year - expList[i].Value.Year
                };

                queryList.Add(employe);
            }

            Employees = queryList
                .OrderByDescending(d => d.WorkExperience)
                .ToList();
        }

        #endregion

    }
}