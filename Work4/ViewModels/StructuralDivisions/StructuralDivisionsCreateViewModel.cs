using System.Windows;
using System.Windows.Input;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Services.Command;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.StructuralDivisions
{
    public class StructuralDivisionsCreateViewModel : BaseStructuralDivisionsViewModel
    {
        public StructuralDivisionsCreateViewModel()
        {
            InitializeRepositories();
            InitializeCommands();
        }

        #region Properties

        #region Commands

        public ICommand CreateStructuralDivisionCommand { get; private set; }

        #endregion

        #endregion

        #region Commands

        private void CreateStructuralDivision(object obj)
        {
            var division = new StructuralDivision(Name);

            _structuralDivisionsRepository.Create(division);

            MessageBox.Show("Structural division has been create", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            CreateStructuralDivisionCommand = new DelegateCommandService(CreateStructuralDivision);
        }

        private void InitializeRepositories()
        {
            _structuralDivisionsRepository = new SQLStructuralDivisionRepository();
        }

        #endregion

    }
}
