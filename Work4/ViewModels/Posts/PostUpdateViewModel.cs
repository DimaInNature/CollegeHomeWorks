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
    public class PostUpdateViewModel : BasePostViewModel
    {
        public PostUpdateViewModel()
        {
            InitializeRepositories();
            InitializeData();
            InitializeCommands();
        }

        #region Properties

        #region Commands

        public ICommand UpdatePostCommand { get; private set; }
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

        #endregion

        #region Commands

        private void UpdatePost(object obj)
        {
            if (SelectedPost != null)
            {
                var post = new Post(SelectedPost.Id, Name, (int)Wage);

                _postRepository.Update(post);

                InitializeData();

                MessageBox.Show("Post has been update", "Success",
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

        private void InitializeData()
        {
            Posts = _postRepository.Read().ToList();
        }

        private void InitializeCommands()
        {
            UpdatePostCommand = new DelegateCommandService(UpdatePost);
            SelectPostCommand = new DelegateCommandService(SelectPost);
        }

        private void InitializeRepositories()
        {
            _postRepository = new SQLPostRepository();
        }

        #endregion

    }
}
