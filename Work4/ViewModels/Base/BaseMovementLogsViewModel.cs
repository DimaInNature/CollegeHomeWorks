using System;
using Work4.Data;
using Work4.Data.Repository;
using Work4.Models;

namespace Work4.ViewModels.Base
{
    public class BaseMovementLogsViewModel : BaseViewModel
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

        public int? EmployeId
        {
            get => _employeId < 0
                ? 1
                : _employeId;
            set
            {
                _employeId = value < 0
                    ? 0
                    : value;
                OnPropertyChanged(nameof(EmployeId));
            }
        }

        private int? _employeId;

        public int? StructuralDivisionId
        {
            get => _structuralDivisionId < 0
                ? 1
                : _structuralDivisionId;
            set
            {
                _structuralDivisionId = value < 0
                    ? 0
                    : value;
                OnPropertyChanged(nameof(StructuralDivisionId));
            }
        }

        private int? _structuralDivisionId;

        public int? PostId
        {
            get => _postId < 0
                ? 1
                : _postId;
            set
            {
                _postId = value < 0
                    ? 0
                    : value;
                OnPropertyChanged(nameof(PostId));
            }
        }

        private int? _postId;

        public double? Rate
        {
            get => _rate;
            set
            {
                _rate = value < 0
                    ? 0
                    : value;
                OnPropertyChanged(nameof(Rate));
            }
        }

        protected double? _rate;

        public double? Salary
        {
            get => _salary;
            set
            {
                _salary = value < 0
                        ? 0
                        : value;
                OnPropertyChanged(nameof(Salary));
            }
        }

        protected double? _salary;

        public string WorkStatus
        {
            get => string.IsNullOrWhiteSpace(_workStatus)
               ? string.Empty
               : _workStatus;
            set
            {
                _workStatus = value is null
                    ? string.Empty
                    : value;
                OnPropertyChanged(nameof(WorkStatus));
            }
        }

        protected string _workStatus;

        public string OrderNumber
        {
            get => string.IsNullOrWhiteSpace(_orderNumber)
               ? string.Empty
               : _orderNumber;
            set
            {
                _orderNumber = value is null
                    ? string.Empty
                    : value;
                OnPropertyChanged(nameof(OrderNumber));
            }
        }

        protected string _orderNumber;

        public DateTime? DateOfEmployment
        {
            get => _dateOfEmployment;
            set
            {
                _dateOfEmployment = value;
                OnPropertyChanged(nameof(DateOfEmployment));
            }
        }

        protected DateTime? _dateOfEmployment;

        #endregion

        #region Repositories

        protected IRepository<Post> _postRepository;

        protected IRepository<StructuralDivision> _structuralDivisionRepository;

        protected IRepository<Employe> _employeRepository;

        protected IMovementLogRepository _movementLogRepository;

        #endregion

    }
}
