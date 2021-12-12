using System;
using Work4.Data;
using Work4.Models;

namespace Work4.ViewModels.Base
{
    public abstract class BaseEmployeViewModel : BaseViewModel
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

        public string Surname
        {
            get => string.IsNullOrWhiteSpace(_surname)
               ? string.Empty
               : _surname;
            set
            {
                _surname = value is null
                    ? string.Empty
                    : value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        protected string _surname;

        public string Patronymic
        {
            get => string.IsNullOrWhiteSpace(_patronymic)
               ? string.Empty
               : _patronymic;
            set
            {
                _patronymic = value is null
                    ? string.Empty
                    : value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        protected string _patronymic;

        public string Gender
        {
            get => string.IsNullOrWhiteSpace(_gender)
               ? string.Empty
               : _gender;
            set
            {
                _gender = value is null
                    ? string.Empty
                    : value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        protected string _gender;

        public DateTime? BirthDay
        {
            get => _birthDay;
            set
            {
                _birthDay = value;
                OnPropertyChanged(nameof(BirthDay));
            }
        }

        protected DateTime? _birthDay;

        public string Address
        {
            get => string.IsNullOrWhiteSpace(_address)
               ? string.Empty
               : _address;
            set
            {
                _address = value is null
                    ? string.Empty
                    : value;
                OnPropertyChanged(nameof(Address));
            }
        }

        protected string _address;

        #endregion

        #region Repositories

        protected IRepository<Employe> _employeRepository;

        #endregion

    }
}
