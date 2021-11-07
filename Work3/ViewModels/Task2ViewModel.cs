using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Work3.Data;
using Work3.Models;
using Work3.Services.Command;
using Work3.ViewModels.Base;
using Work3.Views;

namespace Work3.ViewModels
{
    public sealed class Task2ViewModel : ViewModelBase
    {
        public Task2ViewModel()
        {
            InitialCommands();
            InitialDataCollections();
        }

        #region Properties

        #region Commands

        public ICommand FindReaderByFullNameButtonClickCommand { get; private set; }

        public ICommand SearchTwoAuthorItemClickCommand { get; private set; }

        public ICommand BackControlButtonClickCommand { get; private set; }

        public ICommand ShutdownButtonClickCommand { get; private set; }

        #endregion

        #region Search One

        public string SearchOneName
        {
            get =>
                string.IsNullOrWhiteSpace(_searchOneName)
                ? string.Empty
                : _searchOneName;
            set
            {
                _searchOneName = string.IsNullOrWhiteSpace(value)
                    ? _searchOneName
                    : value;
                OnPropertyChanged(nameof(SearchOneName));
            }
        }

        private string _searchOneName;

        public string SearchOneSurname
        {
            get =>
                string.IsNullOrWhiteSpace(_searchOneSurname)
                ? string.Empty
                : _searchOneSurname;
            set
            {
                _searchOneSurname = string.IsNullOrWhiteSpace(value)
                    ? _searchOneSurname
                    : value;
                OnPropertyChanged(nameof(SearchOneSurname));
            }
        }

        private string _searchOneSurname;

        public string SearchOnePatronymic
        {
            get =>
                string.IsNullOrWhiteSpace(_searchOnePatronymic)
                ? string.Empty
                : _searchOnePatronymic;
            set
            {
                _searchOnePatronymic = string.IsNullOrWhiteSpace(value)
                    ? _searchOnePatronymic
                    : value;
                OnPropertyChanged(nameof(SearchOnePatronymic));
            }
        }

        private string _searchOnePatronymic;

        public List<Reader> SearchOneResult
        {
            get => _searchOneResult is null
                ? new List<Reader>()
                : _searchOneResult;
            set
            {
                _searchOneResult = value is null
                    ? new List<Reader>()
                    : value;
                OnPropertyChanged(nameof(SearchOneResult));
            }
        }

        private List<Reader> _searchOneResult;

        #endregion

        #region Search Two

        public List<Author> SearchTwoAuthors
        {
            get => _searchTwoAuthors is null
                ? new List<Author>()
                : _searchTwoAuthors; 
            set
            {
                _searchTwoAuthors = value is null
                    ? new List<Author>()
                    : value;
                OnPropertyChanged(nameof(SearchTwoAuthors));
            }
        }

        private List<Author> _searchTwoAuthors;

        public List<Book> SearchTwoAuthorBooks
        {
            get => _searchTwoAuthorBooks is null
                ? new List<Book>()
                : _searchTwoAuthorBooks;
            set
            {
                _searchTwoAuthorBooks = value is null
                    ? new List<Book>()
                    : value;
                OnPropertyChanged(nameof(SearchTwoAuthorBooks));
            }
        }

        private List<Book> _searchTwoAuthorBooks;

        public Author SearchTwoSelectedAuthor
        {
            get => _searchTwoSelectedAuthor is null
                ? new Author()
                : _searchTwoSelectedAuthor;
            set
            {
                _searchTwoSelectedAuthor = value is null
                    ? new Author()
                    : value;
                OnPropertyChanged(nameof(SearchTwoSelectedAuthor));
            }
        }

        private Author _searchTwoSelectedAuthor;

        #endregion

        #endregion

        #region Methods

        #region Commands

        private void FindReaderByFullNameButtonClick(object obj)
        {
            if (!string.IsNullOrWhiteSpace(SearchOneName)
                && !string.IsNullOrWhiteSpace(SearchOneSurname))
            {
                SearchOneResult = ReaderCRUD
                    .ReadByFullName(SearchOneName, SearchOneSurname, SearchOnePatronymic);
            }
            else
            {
                MessageBox.Show("The fields were not filled in","Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchTwoAuthorItemClick(object obj)
        {
            if(SearchTwoSelectedAuthor != null)
            {
                SearchTwoAuthorBooks = BookCRUD
                    .ReadByIdAuthor(SearchTwoSelectedAuthor.Id);
            }
        }

        private void BackControlButtonClick(object obj)
        {
            (Application.Current as App).DisplayWindow
                .Show(new Task1ViewModel());
            (obj as Task2View).Close();
        }

        private void ShutdownButtonClick(object obj) =>
            Application.Current.Shutdown();

        #endregion

        private void InitialCommands()
        {
            FindReaderByFullNameButtonClickCommand =
                new DelegateCommandService(FindReaderByFullNameButtonClick);
            SearchTwoAuthorItemClickCommand =
                new DelegateCommandService(SearchTwoAuthorItemClick);
            BackControlButtonClickCommand =
                new DelegateCommandService(BackControlButtonClick);
            ShutdownButtonClickCommand =
                new DelegateCommandService(ShutdownButtonClick);
        }

        private void InitialDataCollections()
        {
            SearchTwoAuthors = AuthorCRUD.Read();
        }

        #endregion
    }
}