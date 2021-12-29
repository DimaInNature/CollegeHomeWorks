using System;
using System.Web.Mvc;
using Work5.Models;
using Work5.Models.Repository;

namespace Work5.Controllers
{
    public class MovementLogController : Controller
    {
        private readonly IRepository<MovementLog> _movementLogRepository = new SQLMovementLogRepository();
        private readonly IRepository<Post> _postRepository = new SQLPostRepository();
        private readonly IRepository<Employe> _employeRepository = new SQLEmployeRepository();

        [HttpGet]
        public ActionResult Read()
        {
            var logs = _movementLogRepository.Read();

            foreach (var item in logs)
            {
                item.Employe = _employeRepository.Read(item.EmployeId);
                item.Post = _postRepository.Read(item.PostId);
            }

            ViewBag.MovementLogs = logs;

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MovementLogs = _movementLogRepository.Read();
            ViewBag.Posts = _postRepository.Read();
            ViewBag.Employees = _employeRepository.Read();

            return View();
        }

        [HttpPost]
        public string Create(MovementLog log)
        {
            log.DateofCreation = DateTime.UtcNow;

            if (log.DateOfEmployment == default)
            {
                log.DateOfEmployment = DateTime.UtcNow;
            }

            if(log.Status == "Dismiss")
            {
                log.DateOfDismission = DateTime.UtcNow;
            }

            _movementLogRepository.Create(log);

            return "Movement log has been created!";
        }
    }
}