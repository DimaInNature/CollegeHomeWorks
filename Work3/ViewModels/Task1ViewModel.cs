using System;
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
    public sealed class Task1ViewModel : ViewModelBase
    {
        public Task1ViewModel()
        {
            InitialCommands();
            InitialDataCollections();
        }

        #region Properties

        #region Book

        private const int _minAgeValue = 12;
        private const int _maxAgeValue = 18;

        #region Create

        public string BookName
        {
            get => 
                string.IsNullOrWhiteSpace(_bookName)
                ? string.Empty
                : _bookName;
            set
            {
                _bookName = value is null
                    ? _bookName
                    : value;
                OnPropertyChanged(nameof(BookName));
            }
        }

        private string _bookName;

        public string BookGenre
        {
            get =>
                string.IsNullOrWhiteSpace(_bookGenre)
                ? string.Empty
                : _bookGenre;
            set
            {
                _bookGenre = value is null
                    ? _bookGenre
                    : value;
                OnPropertyChanged(nameof(BookGenre));
            }
        }

        private string _bookGenre;

        public int BookAgeRestriction
        {
            get =>
                _bookAgeRestriction >= _minAgeValue &&
                _bookAgeRestriction <= _maxAgeValue
                ? _bookAgeRestriction
                : _minAgeValue;
            set
            {
                
                _bookAgeRestriction =
                    value >= _minAgeValue &&
                    value <= _maxAgeValue
                    ? value
                    : _minAgeValue;
                OnPropertyChanged(nameof(BookAgeRestriction));
            }
        }

        private int _bookAgeRestriction;

        #endregion

        #region Update

        public string UpdateBookName
        {
            get =>
                string.IsNullOrWhiteSpace(_updateBookName)
                ? string.Empty
                : _updateBookName;
            set
            {
                _updateBookName = value is null
                    ? _updateBookName
                    : value;
                OnPropertyChanged(nameof(UpdateBookName));
            }
        }

        private string _updateBookName;

        public string UpdateBookGenre
        {
            get => 
                string.IsNullOrWhiteSpace(_updateBookGenre)
                ? string.Empty
                : _updateBookGenre;
            set
            {
                _updateBookGenre = value is null
                    ? _updateBookGenre
                    : value;
                OnPropertyChanged(nameof(UpdateBookGenre));
            }
        }

        private string _updateBookGenre;

        public int UpdateBookAgeRestriction
        {
            get =>
                _updateBookAgeRestriction >= _minAgeValue &&
                _updateBookAgeRestriction <= _maxAgeValue
                ? _updateBookAgeRestriction
                : _minAgeValue;
            set
            {
                _updateBookAgeRestriction =
                    value >= _minAgeValue &&
                    value <= _maxAgeValue
                    ? value
                    : _minAgeValue;
                OnPropertyChanged(nameof(UpdateBookAgeRestriction));
            }
        }

        private int _updateBookAgeRestriction;

        #endregion

        #region Selected Item

        public Book CreateReaderSelectedBookItem
        {
            get => _createReaderSelectedBookItem is null
                ? new Book()
                : _createReaderSelectedBookItem;
            set
            {
                _createReaderSelectedBookItem = value is null
                    ? new Book()
                    : value;
                OnPropertyChanged(nameof(CreateReaderSelectedBookItem));
            }
        }

        private Book _createReaderSelectedBookItem;

        public Book UpdateBookSelectedItem
        {
            get => _updateBookSelectedItem is null
                ? new Book()
                : _updateBookSelectedItem;
            set
            {
                _updateBookSelectedItem = value is null
                    ? new Book()
                    : value;
                OnPropertyChanged(nameof(UpdateBookSelectedItem));
            }
        }

        private Book _updateBookSelectedItem;

        public Book DeleteBookSelectedItem
        {
            get => _deleteBookSelectedItem is null
                ? new Book()
                : _deleteBookSelectedItem;
            set
            {
                _deleteBookSelectedItem = value is null
                    ? new Book()
                    : value;
                OnPropertyChanged(nameof(DeleteBookSelectedItem));
            }
        }

        private Book _deleteBookSelectedItem;

        #endregion

        #endregion

        #region Reader

        #region Create

        public string ReaderName
        {
            get =>
                string.IsNullOrWhiteSpace(_readerName)
                ? string.Empty
                : _readerName;
            set
            {
                _readerName = value is null
                    ? _readerName
                    : value;
                OnPropertyChanged(nameof(ReaderName));
            }
        }

        private string _readerName;

        public string ReaderSurname
        {
            get => 
                string.IsNullOrWhiteSpace(_readerSurname)
                ? string.Empty
                : _readerSurname;
            set
            {
                _readerSurname = value is null
                    ? _readerSurname
                    : value;
                OnPropertyChanged(nameof(ReaderSurname));
            }
        }

        private string _readerSurname;

        public string ReaderPatronymic
        {
            get =>
                string.IsNullOrWhiteSpace(_readerPatronymic)
                ? string.Empty
                : _readerPatronymic;
            set
            {
                _readerPatronymic = value is null
                    ? _readerPatronymic
                    : value;
                OnPropertyChanged(nameof(ReaderPatronymic));
            }
        }

        private string _readerPatronymic;

        public string ReaderPhone
        {
            get => 
                string.IsNullOrWhiteSpace(_readerPhone)
                ? string.Empty
                : _readerPhone;
            set
            {
                _readerPhone = value is null
                    ? _readerPhone
                    : value;
                OnPropertyChanged(nameof(ReaderPhone));
            }
        }

        private string _readerPhone;

        public DateTime ReaderBirthDay
        {
            get => _readerBirthDay;
            set => _readerBirthDay = value;
        }

        private DateTime _readerBirthDay = new DateTime(DateTime.UtcNow.Year,
            DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0, DateTimeKind.Utc);

        #endregion

        #region Update

        public string UpdateReaderName
        {
            get =>
                string.IsNullOrWhiteSpace(_updateReaderName)
                ? string.Empty
                : _updateReaderName;
            set
            {
                _updateReaderName = value is null
                    ? _updateReaderName
                    : value;
                OnPropertyChanged(nameof(UpdateReaderName));
            }
        }

        private string _updateReaderName;

        public string UpdateReaderSurname
        {
            get =>
                string.IsNullOrWhiteSpace(_updateReaderSurname)
                ? string.Empty
                : _updateReaderSurname;
            set
            {
                _updateReaderSurname = value is null
                    ? _updateReaderSurname
                    : value;
                OnPropertyChanged(nameof(UpdateReaderSurname));
            }
        }

        private string _updateReaderSurname;

        public string UpdateReaderPatronymic
        {
            get =>
                string.IsNullOrWhiteSpace(_updateReaderPatronymic)
                ? string.Empty
                : _updateReaderPatronymic;
            set
            {
                _updateReaderPatronymic = value is null
                    ? _updateReaderPatronymic
                    : value;
                OnPropertyChanged(nameof(UpdateReaderPatronymic));
            }
        }

        private string _updateReaderPatronymic;

        public string UpdateReaderPhone
        {
            get => 
                string.IsNullOrWhiteSpace(_updateReaderPhone)
                ? string.Empty
                : _updateReaderPhone;
            set
            {
                _updateReaderPhone = value is null
                    ? _updateReaderPhone
                    : value;
                OnPropertyChanged(nameof(UpdateReaderPhone));
            }
        }

        private string _updateReaderPhone;

        #endregion

        #region Selected Item

        public Reader UpdateReaderSelectedItem
        {
            get => _updateReaderSelectedItem is null
                ? new Reader()
                : _updateReaderSelectedItem;
            set
            {
                _updateReaderSelectedItem = value is null
                    ? new Reader()
                    : _updateReaderSelectedItem;
                OnPropertyChanged(nameof(UpdateReaderSelectedItem));
            }
        }

        private Reader _updateReaderSelectedItem;

        public Reader DeleteReaderSelectedItem
        {
            get => _deleteReaderSelectedItem is null
                ? new Reader()
                : _deleteReaderSelectedItem;
            set
            {
                _deleteReaderSelectedItem = value is null
                    ? new Reader()
                    : _deleteReaderSelectedItem;
                OnPropertyChanged(nameof(DeleteReaderSelectedItem));
            }
        }

        private Reader _deleteReaderSelectedItem;

        #endregion

        #endregion

        #region Author

        #region Create

        public string AuthorName
        {
            get => 
                string.IsNullOrWhiteSpace(_authorName)
                ? string.Empty
                : _authorName;
            set
            {
                _authorName = string.IsNullOrWhiteSpace(value)
                    ? _authorName
                    : value;
                OnPropertyChanged(nameof(AuthorName));
            }
        }

        private string _authorName;

        public string AuthorSurname
        {
            get =>
                string.IsNullOrWhiteSpace(_authorSurname)
                ? string.Empty
                : _authorSurname;
            set
            {
                _authorSurname = string.IsNullOrWhiteSpace(value)
                    ? _authorSurname
                    : value;
                OnPropertyChanged(nameof(AuthorSurname));
            }
        }

        private string _authorSurname;

        public string AuthorPatronymic
        {
            get =>
                string.IsNullOrWhiteSpace(_authorPatronymic)
                ? string.Empty
                : _authorPatronymic;
            set
            {
                _authorPatronymic = string.IsNullOrWhiteSpace(value)
                    ? _authorPatronymic
                    : value;
                OnPropertyChanged(nameof(AuthorPatronymic));
            }
        }

        private string _authorPatronymic;

        #endregion

        #region Selected Item

        public Author CreateAuthorSelectedItem
        {
            get => _createAuthorSelectedItem is null
                ? new Author()
                : _createAuthorSelectedItem;
            set
            {
                _createAuthorSelectedItem = value is null
                    ? _createAuthorSelectedItem
                    : value;
                OnPropertyChanged(nameof(CreateAuthorSelectedItem));
            }
        }

        private Author _createAuthorSelectedItem;

        public Author DeleteAuthorSelectedItem
        {
            get => _deleteAuthorSelectedItem is null
                ? new Author()
                : _deleteAuthorSelectedItem;
            set
            {
                _deleteAuthorSelectedItem = value is null
                    ? _deleteAuthorSelectedItem
                    : value;
                OnPropertyChanged(nameof(DeleteAuthorSelectedItem));
            }
        }

        private Author _deleteAuthorSelectedItem;

        #endregion

        #endregion

        #region Commands

        public ICommand CreateBookButtonClickCommand { get; private set; }
        public ICommand UpdateBookButtonClickCommand { get; private set; }
        public ICommand UpdateBookSelectedItemClickCommand { get; private set; }
        public ICommand DeleteBookButtonClickCommand { get; private set; }
        public ICommand CreateReaderButtonClickCommand { get; private set; }
        public ICommand UpdateReaderButtonClickCommand { get; private set; }
        public ICommand UpdateReaderSelectedItemClickCommand { get; private set; }
        public ICommand DeleteReaderClickCommand { get; private set; }
        public ICommand CreateAuthorButtonClickCommand { get; private set; }
        public ICommand DeleteAuthorButtonClickCommand { get; private set; }
        public ICommand ShutdownButtonClickCommand { get; private set; }
        public ICommand ShowSearchWindowButtonClickCommand { get; private set; }

        #endregion

        #region Data Collections

        public List<Book> Books
        {
            get => _books is null 
                ? new List<Book>()
                : _books;
            set
            {
                _books = value is null
                    ? new List<Book>()
                    : value;
                OnPropertyChanged(nameof(Books));
            }
        }

        private List<Book> _books;

        public List<Reader> Readers
        {
            get => _readers is null
                ? new List<Reader>()
                : _readers;
            set
            {
                _readers = value is null
                    ? new List<Reader>()
                    : value;
                OnPropertyChanged(nameof(Readers));
            }
        }
        private List<Reader> _readers;

        public List<Author> Authors
        {
            get => _authors is null 
                ? new List<Author>()
                : _authors;
            set
            {
                _authors = value is null
                    ? new List<Author>()
                    : value;
                OnPropertyChanged(nameof(Authors));
            }
        }

        private List<Author> _authors;

        #endregion

        #endregion

        #region Methods

        #region Commands

        private void CreateBookButtonClick(object obj)
        {
            if(!string.IsNullOrWhiteSpace(BookName) && !string.IsNullOrWhiteSpace(BookGenre)
                && BookAgeRestriction >= 12 && CreateAuthorSelectedItem != null)
            {
                var newBook = new Book(BookName, BookGenre,
                    BookAgeRestriction, CreateAuthorSelectedItem.Id);

                BookCRUD.Create(newBook);

                Books = BookCRUD.Read();

                MessageBox.Show("Book has been created", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("The fields were not filled in", "Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }

        private void UpdateBookButtonClick(object obj)
        {
            if(UpdateBookSelectedItem != null)
            {
                var newBook = new Book(UpdateBookSelectedItem.Id, UpdateBookName,
                    UpdateBookGenre, UpdateBookAgeRestriction,
                    UpdateBookSelectedItem.IdAuthor);

                BookCRUD.Update(newBook);

                Books = BookCRUD.Read();

                MessageBox.Show("Book has been update", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Book is not selected","Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateBookSelectedItemClick(object obj)
        {
            if (UpdateBookSelectedItem != null)
            {
                (UpdateBookName, UpdateBookGenre, UpdateBookAgeRestriction) =
                    (UpdateBookSelectedItem.Name, UpdateBookSelectedItem.Genre,
                    UpdateBookSelectedItem.AgeRestriction);
            }
        }

        private void DeleteBookButtonClick(object obj)
        {
            if(DeleteBookSelectedItem != null)
            {
                BookCRUD.Delete(DeleteBookSelectedItem.Id);

                Books = BookCRUD.Read();

                MessageBox.Show("Book has been deleted", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Book is not selected", "Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateReaderButtonClick(object obj)
        {
            if(!string.IsNullOrWhiteSpace(ReaderName) && !string.IsNullOrWhiteSpace(ReaderSurname) &&
                !string.IsNullOrWhiteSpace(ReaderPhone) && CreateReaderSelectedBookItem != null)
            {
                Reader newReader = new Reader(ReaderName, ReaderSurname, ReaderPatronymic,
                        ReaderBirthDay, ReaderPhone, CreateReaderSelectedBookItem);

                if(CreateReaderSelectedBookItem.AgeRestriction < newReader.Years)
                {
                    ReaderCRUD.Create(newReader);

                    Readers = ReaderCRUD.Read();

                    MessageBox.Show("Reader has been created", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Age restrictions are not met", "Input Error",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }                       
            }
            else
            {
                MessageBox.Show("The fields were not filled in", "Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateReaderButtonClick(object obj)
        {
            if (UpdateReaderSelectedItem != null)
            {
                Reader newReader = new Reader(UpdateReaderSelectedItem.Id, UpdateReaderName, 
                    UpdateReaderSurname, UpdateReaderPatronymic, UpdateReaderSelectedItem.BirthDay,
                    UpdateReaderPhone, UpdateReaderSelectedItem.Book);

                ReaderCRUD.Update(newReader);

                Readers = ReaderCRUD.Read();

                MessageBox.Show("Reader has been deleted", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Reader is not select", "Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateReaderSelectedItemClick(object obj)
        {
            if (UpdateReaderSelectedItem != null)
            {
                (UpdateReaderName, UpdateReaderSurname,
                    UpdateReaderPatronymic, UpdateReaderPhone) =
                    (UpdateReaderSelectedItem.Name, UpdateReaderSelectedItem.Surname,
                    UpdateReaderSelectedItem.Patronymic, UpdateReaderSelectedItem.Phone);
            }
        }

        private void DeleteReaderButtonClick(object obj)
        {
            if (DeleteReaderSelectedItem != null)
            {
                ReaderCRUD.Delete(DeleteReaderSelectedItem.Id);

                Readers = ReaderCRUD.Read();

                MessageBox.Show("Reader has been deleted", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Reader is not selected", "Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateAuthorButtonClick(object obj)
        {
            if (!string.IsNullOrWhiteSpace(AuthorName) &&
                !string.IsNullOrWhiteSpace(AuthorSurname))
            {
                var newAuthor = new Author(AuthorName,
                    AuthorSurname, AuthorPatronymic);

                AuthorCRUD.Create(newAuthor);

                Authors = AuthorCRUD.Read();

                MessageBox.Show("Author has been created", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("The fields were not filled in", "Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteAuthorButtonClick(object obj)
        {
            if (DeleteAuthorSelectedItem != null)
            {
                AuthorCRUD.Delete(DeleteAuthorSelectedItem.Id);
                BookCRUD.DeleteByIdAuthor(DeleteAuthorSelectedItem.Id);

                Authors = AuthorCRUD.Read();
                Books = BookCRUD.Read();

                MessageBox.Show("Author has been deleted", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Author is not selected", "Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowSearchWindowButtonClick(object obj)
        {
            (Application.Current as App).DisplayWindow
                .Show(new Task2ViewModel());
            (obj as Task1View)
                .Close();
        }

        private void ShutdownButtonClick(object obj) =>
            Application.Current.Shutdown();

        #endregion

        private void InitialCommands()
        {
            CreateBookButtonClickCommand =
                new DelegateCommandService(CreateBookButtonClick);
            UpdateBookButtonClickCommand =
                new DelegateCommandService(UpdateBookButtonClick);
            UpdateBookSelectedItemClickCommand =
                new DelegateCommandService(UpdateBookSelectedItemClick);
            DeleteBookButtonClickCommand =
                new DelegateCommandService(DeleteBookButtonClick);
            CreateReaderButtonClickCommand =
                new DelegateCommandService(CreateReaderButtonClick);
            UpdateReaderButtonClickCommand =
                new DelegateCommandService(UpdateReaderButtonClick);
            UpdateReaderSelectedItemClickCommand =
                new DelegateCommandService(UpdateReaderSelectedItemClick);
            DeleteReaderClickCommand =
                new DelegateCommandService(DeleteReaderButtonClick);
            CreateAuthorButtonClickCommand =
                new DelegateCommandService(CreateAuthorButtonClick);
            DeleteAuthorButtonClickCommand =
                new DelegateCommandService(DeleteAuthorButtonClick);
            ShutdownButtonClickCommand =
                new DelegateCommandService(ShutdownButtonClick);
            ShowSearchWindowButtonClickCommand =
                new DelegateCommandService(ShowSearchWindowButtonClick);
        }

        private void InitialDataCollections()
        {
            Books = BookCRUD.Read();
            Authors = AuthorCRUD.Read();
            Readers = ReaderCRUD.Read();
        }

        #endregion
    }
}