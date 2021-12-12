using Work4.Data;
using Work4.Models;

namespace Work4.ViewModels.Base
{
    public abstract class BaseStructuralDivisionsViewModel : BaseViewModel
    {

        #region Properties

        public int Id
        {
            get => _id < 0
                ? 1
                : _id;
            set
            {
                _id = value < 0
                    ? 0
                    : value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int _id;

        public string Name
        {
            get => string.IsNullOrWhiteSpace(_name)
               ? string.Empty
               : _name;
            set
            {
                _name = value is null
                    ? string.Empty
                    : value;
                OnPropertyChanged(nameof(Name));
            }
        }

        protected string _name;

        #endregion

        #region Repositories

        protected IRepository<StructuralDivision> _structuralDivisionsRepository;

        #endregion

    }
}
