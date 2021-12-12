using Work4.Data;
using Work4.Models;

namespace Work4.ViewModels.Base
{
    public abstract class BasePostViewModel : BaseViewModel
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

        public int? Wage
        {
            get => _wage < 0
               ? 0
               : _wage;
            set
            {
                _wage = value < 0
                    ? 0
                    : value;
                OnPropertyChanged(nameof(Wage));
            }
        }

        protected int? _wage;

        #endregion

        #region Repositories

        protected IRepository<Post> _postRepository;

        #endregion
    }
}
