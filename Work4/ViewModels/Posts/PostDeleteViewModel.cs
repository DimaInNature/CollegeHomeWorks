using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Services.Command;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.Posts
{
    public class PostDeleteViewModel : BasePostViewModel
    {
        public PostDeleteViewModel()
        {
            InitializeRepositories();
            InitializeCommands();
            InitializeData();
        }

        #region Properties

        #region Commands

        public ICommand DeletePostCommand { get; private set; }
        public ICommand SelectPostCommand { get; private set; }

        #endregion

        #region Data

        public List<Post> Posts
        {
            get => _posts is null
                ? new List<Post>()
                : _posts;
            set
            {
                _posts = value is null
                    ? new List<Post>()
                    : value;
                OnPropertyChanged(nameof(Posts));
            }
        }

        private List<Post> _posts;

        #endregion

        #region Selected

        public Post SelectedPost
        {
            get => _selectedPost;
            set
            {
                _selectedPost = value;
                OnPropertyChanged(nameof(SelectedPost));
            }
        }

        private Post _selectedPost;

        #endregion

        #region Repositories

        private IMovementLogRepository _movementLogRepository;

        #endregion

        #endregion

        #region Commands

        private void DeletePost(object obj)
        {
            if (SelectedPost != null)
            {
                _postRepository.Delete(SelectedPost);
                _movementLogRepository.Delete(SelectedPost);

                InitializeData();

                MessageBox.Show("Post has been deleted", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Post is not selected", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SelectPost(object obj)
        {
            if (SelectedPost != null)
            {
                (Id, Name, Wage) = (SelectedPost.Id, SelectedPost.Name, SelectedPost.Wage);
            }
        }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            DeletePostCommand = new DelegateCommandService(DeletePost);
            SelectPostCommand = new DelegateCommandService(SelectPost);
        }

        private void InitializeData()
        {
            Posts = _postRepository.Read().ToList();
        }

        private void InitializeRepositories()
        {
            _postRepository = new SQLPostRepository();
            _movementLogRepository = new SQLMovementLogRepository();
        }

        #endregion

    }
}
