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
    public class StructuralDivisionsUpdateViewModel : BaseStructuralDivisionsViewModel
    {
        public StructuralDivisionsUpdateViewModel()
        {
            InitializeRepositories();
            InitializeCommands();
            InitializeData();
        }

        #region Properties

        #region Commands

        public ICommand UpdateStructuralDivisionCommand { get; private set; }
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

        #endregion

        #region Commands

        private void UpdateStructuralDivision(object obj)
        {
            if (SelectedStructuralDivision != null)
            {
                var division = new StructuralDivision(SelectedStructuralDivision.Id, Name);

                _structuralDivisionsRepository.Update(division);

                InitializeData();

                MessageBox.Show("Structural division has been update", "Success",
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

        private void InitializeData()
        {
            StructuralDivisions = _structuralDivisionsRepository.Read().ToList();
        }

        private void InitializeCommands()
        {
            UpdateStructuralDivisionCommand = new DelegateCommandService(UpdateStructuralDivision);
            SelectStructuralDivisionCommand = new DelegateCommandService(SelectStructuralDivision);
        }

        private void InitializeRepositories()
        {
            _structuralDivisionsRepository = new SQLStructuralDivisionRepository();
        }

        #endregion

    }
}
