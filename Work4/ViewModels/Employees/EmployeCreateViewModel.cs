using System.Windows;
using System.Windows.Input;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Services.Command;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.Employees
{
    public class EmployeCreateViewModel : BaseEmployeViewModel
    {
        public EmployeCreateViewModel()
        {
            InitializeRepositories();
            InitializeCommands();
        }

        #region Properties

        #region Commands

        public ICommand CreateEmployeCommand { get; private set; }

        #endregion

        #endregion

        #region Commands

        private void CreateEmploye(object obj)
        {
            var employe = new Employe(Name, Surname, Patronymic, BirthDay, Gender, Address);

            _employeRepository.Create(employe);

            MessageBox.Show("Employe has been create", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            CreateEmployeCommand = new DelegateCommandService(CreateEmploye);
        }

        private void InitializeRepositories()
        {
            _employeRepository = new SQLEmployeRepository();
        }

        #endregion

    }
}
