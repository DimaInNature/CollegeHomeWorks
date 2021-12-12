using System.Collections.Generic;
using System.Linq;
using Work4.Data.Repository;
using Work4.Models;
using Work4.ViewModels.Base;

namespace Work4.ViewModels.Posts
{
    public class PostReadViewModel : BasePostViewModel
    {
        public PostReadViewModel()
        {
            InitializeRepositories();
            InitializeData();
        }

        #region Properties

        #region Data

        public IReadOnlyList<Post> Posts
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

        private IReadOnlyList<Post> _posts;

        #endregion

        #endregion

        #region Methods

        private void InitializeData()
        {
            Posts = _postRepository.Read().ToList();
        }

        private void InitializeRepositories()
        {
            _postRepository = new SQLPostRepository();
        }

        #endregion

    }
}
