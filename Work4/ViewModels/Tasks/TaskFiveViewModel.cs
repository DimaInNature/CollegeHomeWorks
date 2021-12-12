using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Work4.Data;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Models.Struct;
using Work4.Services.Command;
using Work4.ViewModels.Base;
using Work4.Views;

namespace Work4.ViewModels.Tasks
{
    public class TaskFiveViewModel : BaseViewModel
    {
        public TaskFiveViewModel()
        {
            InitializeCommands();
            InitializeRepositories();
            InitializeData();
        }

        #region Properties

        #region Commands

        public ICommand ShowPreviousWindowClickCommand { get; private set; }

        #endregion

        #endregion

        #region Methods

        #region Commands

        private void ShowPreviousWindowClick(object obj) =>
            (Application.Current as App).DisplayWindow
                .Show(new TaskThreeViewModel(), obj as TaskFiveView);

        #endregion

        #region Data

        public List<PostStruct> Posts
        {
            get => _posts is null
                ? new List<PostStruct>()
                : _posts;
            set
            {
                _posts = value is null
                    ? new List<PostStruct>()
                    : value;
                OnPropertyChanged(nameof(Posts));
            }
        }

        private List<PostStruct> _posts;

        #endregion

        #region Repositories

        private IMovementLogRepository _movementLogRepository;

        private IRepository<Post> _postRepository;

        #endregion

        private void InitializeCommands()
        {
            ShowPreviousWindowClickCommand = new DelegateCommandService(ShowPreviousWindowClick);
        }

        private void InitializeRepositories()
        {
            _postRepository = new SQLPostRepository();
            _movementLogRepository = new SQLMovementLogRepository();
        }

        private void InitializeData()
        {
            var uniqPost = _postRepository.Read()
                .GroupBy(x => x.Name)
                .Select(x => x.FirstOrDefault())
                .ToList();

            var queryList = new List<PostStruct>();

            for (int i = 0; i < uniqPost.Count; i++)
            {
                var empCount = _movementLogRepository.Read()
                    .Where(x => x.PostId == uniqPost[i].Id)
                    .ToList()
                    .Count;

                var example = _movementLogRepository.Read()
                    .GroupBy(log => log.PostId)
                    

                var query = new PostStruct()
                {
                    Id = uniqPost[i].Id,
                    Name = uniqPost[i].Name,
                    Count = empCount
                };

                queryList.Add(query);
            }

            Posts = queryList
                .OrderBy(x => x.Name)
                .ToList();
        }

        #endregion

    }
}
