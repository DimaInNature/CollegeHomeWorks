using System.Collections.Generic;
using System.Linq;
using Work4.Data.Repository;
using Work4.Models;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.Employees
{
    public class EmployeReadViewModel : BaseEmployeViewModel
    {
        public EmployeReadViewModel()
        {
            InitializeRepositories();
            InitializeData();
        }

        #region Properties

        #region Data

        public IReadOnlyList<Employe> Employees
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

        private IReadOnlyList<Employe> _employees;

        #endregion

        #endregion

        #region Methods

        private void InitializeData()
        {
            Employees = _employeRepository.Read().ToList();
        }

        private void InitializeRepositories()
        {
            _employeRepository = new SQLEmployeRepository();
        }

        #endregion

    }
}
