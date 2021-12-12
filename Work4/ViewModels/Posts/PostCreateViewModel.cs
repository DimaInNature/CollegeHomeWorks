using System.Windows;
using System.Windows.Input;
using Work4.Data.Repository;
using Work4.Models;
using Work4.Services.Command;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.Posts
{
    public class PostCreateViewModel : BasePostViewModel
    {
        public PostCreateViewModel()
        {
            InitializeRepositories();
            InitializeCommands();
        }

        #region Properties

        #region Commands

        public ICommand CreatePostCommand { get; private set; }

        #endregion

        #endregion

        #region Commands

        private void CreatePost(object obj)
        {
            var post = new Post(Name, (int)Wage);

            _postRepository.Create(post);

            MessageBox.Show("Post has been create", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            CreatePostCommand = new DelegateCommandService(CreatePost);
        }

        private void InitializeRepositories()
        {
            _postRepository = new SQLPostRepository();
        }

        #endregion

    }
}
