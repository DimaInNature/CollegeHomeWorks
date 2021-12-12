using System.Collections.Generic;
using System.Linq;
using Work4.Data.Repository;
using Work4.Models;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.StructuralDivisions
{
    public class StructuralDivisionsReadViewModel : BaseStructuralDivisionsViewModel
    {
        public StructuralDivisionsReadViewModel()
        {
            InitializeRepositories();
            InitializeData();
        }

        #region Properties

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

        #endregion

        #endregion

        #region Methods

        private void InitializeData()
        {
            StructuralDivisions = _structuralDivisionsRepository.Read().ToList();
        }

        private void InitializeRepositories()
        {
            _structuralDivisionsRepository = new SQLStructuralDivisionRepository();
        }

        #endregion

    }
}
