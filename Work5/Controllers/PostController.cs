using System.Web.Mvc;
using Work5.Models;
using Work5.Models.Repository;

namespace Work5.Controllers
{
    public class PostController : Controller
    {
        private readonly IRepository<Post> _postRepository = new SQLPostRepository();

        [HttpGet]
        public ActionResult Read()
        {
            ViewBag.Posts = _postRepository.Read();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Posts = _postRepository.Read();

            return View();
        }

        [HttpPost]
        public string Create(Post post)
        {
            _postRepository.Create(post);

            return "Post has been created!";
        }
    }
}