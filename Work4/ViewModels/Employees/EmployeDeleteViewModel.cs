using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Services.Command;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.Employees
{
    public class EmployeDeleteViewModel : BaseEmployeViewModel
    {
        public EmployeDeleteViewModel()
        {
            InitializeRepositories();
            InitializeCommands();
            InitializeData();
        }

        #region Properties

        #region Commands

        public ICommand DeleteEmployeCommand { get; private set; }
        public ICommand SelectEmployeCommand { get; private set; }

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

        #endregion

        #region Repositories

        private IMovementLogRepository _movementLogRepository;

        #endregion

        #endregion

        #region Commands

        private void DeleteEmploye(object obj)
        {
            if (SelectedEmploye != null)
            {
                _employeRepository.Delete(SelectedEmploye);
                _movementLogRepository.Delete(SelectedEmploye);

                InitializeData();

                MessageBox.Show("Employee has been deleted", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Employee is not selected", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SelectEmploye(object obj)
        {
            if (SelectedEmploye != null)
            {
                (Id, Name, Surname, Patronymic, Gender, BirthDay, Address) =
                (SelectedEmploye.Id, SelectedEmploye.Name, SelectedEmploye.Surname, SelectedEmploye.Patronymic,
                SelectedEmploye.Gender, SelectedEmploye.BirthDay, SelectedEmploye.Address);
            }
        }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            DeleteEmployeCommand = new DelegateCommandService(DeleteEmploye);
            SelectEmployeCommand = new DelegateCommandService(SelectEmploye);
        }

        private void InitializeData()
        {
            Employees = _employeRepository.Read().ToList();
        }

        private void InitializeRepositories()
        {
            _employeRepository = new SQLEmployeRepository();
            _movementLogRepository = new SQLMovementLogRepository();
        }

        #endregion

    }
}
