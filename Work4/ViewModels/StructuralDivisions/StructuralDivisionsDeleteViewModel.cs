using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Services.Command;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.StructuralDivisions
{
    public class StructuralDivisionsDeleteViewModel : BaseStructuralDivisionsViewModel
    {
        public StructuralDivisionsDeleteViewModel()
        {
            InitializeRepositories();
            InitializeCommands();
            InitializeData();
        }

        #region Properties

        #region Commands

        public ICommand DeleteStructuralDivisionCommand { get; private set; }
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

        #endregion

        #region Selected

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

        private IMovementLogRepository _movementLogRepository;

        #endregion

        #endregion

        #region Commands

        private void DeleteStructuralDivision(object obj)
        {
            if (SelectedStructuralDivision != null)
            {
                _structuralDivisionsRepository.Delete(SelectedStructuralDivision);
                _movementLogRepository.Delete(SelectedStructuralDivision);

                InitializeData();

                MessageBox.Show("Structural division has been deleted", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Structural division is not selected", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SelectStructuralDivision(object obj)
        {
            if (SelectedStructuralDivision != null)
            {
                (Id, Name) = (SelectedStructuralDivision.Id, SelectedStructuralDivision.Name);
            }
        }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            DeleteStructuralDivisionCommand = new DelegateCommandService(DeleteStructuralDivision);
            SelectStructuralDivisionCommand = new DelegateCommandService(SelectStructuralDivision);
        }

        private void InitializeData()
        {
            StructuralDivisions = _structuralDivisionsRepository.Read().ToList();
        }

        private void InitializeRepositories()
        {
            _structuralDivisionsRepository = new SQLStructuralDivisionRepository();
            _movementLogRepository = new SQLMovementLogRepository();
        }

        #endregion

    }
}
