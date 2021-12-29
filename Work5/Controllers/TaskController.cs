using System;
using System.Linq;
using System.Web.Mvc;
using Work5.Models;
using Work5.Models.Repository;
using Work5.Models.Struct;

namespace Work5.Controllers
{
    public class TaskController : Controller
    {
        private readonly IRepository<Post> _postRepository = new SQLPostRepository();
        private readonly IRepository<Employe> _employeRepository = new SQLEmployeRepository();
        private readonly IRepository<MovementLog> _movementLogRepository = new SQLMovementLogRepository();

        [HttpGet]
        public ActionResult One()
        {
            ViewBag.Posts = _postRepository.Read();

            return View();
        }

        [HttpPost]
        public ActionResult One(string postName)
        {
            var posts = _postRepository.Read()
                .Where(post => post.Name == postName);

            var movementLogs = _movementLogRepository.Read();

            var employees = _employeRepository.Read();

            var logResult = movementLogs.Join(posts,
                log => log.PostId,
                post => post.Id,
                (log, post) => new MovementLog
                {
                    EmployeId = log.EmployeId,
                    PostId = post.Id
                });

            var employeResult = logResult.Join(employees,
                log => log.EmployeId,
                employe => employe.Id,
                (log, employe) => new Employe
                {
                    Id = employe.Id,
                    Name = employe.Name,
                    Surname = employe.Surname,
                    Patronymic = employe.Patronymic,
                    Gender = employe.Gender,
                    BirthDay = employe.BirthDay
                })
                .GroupBy(x => x.Id)
                .Select(x => x.FirstOrDefault())
                .Distinct();

            ViewBag.Employees = employeResult;
            ViewBag.InputPostName = postName;

            return View("OneResult");
        }

        [HttpGet]
        public ActionResult Two()
        {
            ViewBag.Employees = _employeRepository.Read();

            return View();
        }

        [HttpPost]
        public ActionResult Two(int employeId)
        {
            var movementLogs = _movementLogRepository.Read()
                .Where(log => log.EmployeId == employeId);

            var posts = _postRepository.Read();

            var result = movementLogs
                .Join(posts,
                log => log.PostId,
                post => post.Id,
                (log, post) => new TaskTwoQuery
                {
                    Name = post.Name,
                    Salary = post.Wage + log.Rate,
                    DateOfEmployment = log.DateOfEmployment
                });

            ViewBag.Posts = result;

            return View("TwoResult");
        }

        [HttpGet]
        public ActionResult Three() => View();

        [HttpPost]
        public ActionResult Three(DateTime firstDate, DateTime secondDate)
        {
            var movementLogs = _movementLogRepository.Read();

            var employees = _employeRepository.Read();

            var result = employees.Join(movementLogs,
                employee => employee.Id,
                log => log.Id,
                (employe, log) => new TaskThreeQuery
                {
                    Name = employe.Name,
                    Gender = employe.Gender,
                    BirthDay = employe.BirthDay,
                    Patronymic = employe.Patronymic,
                    Surname = employe.Surname,
                    DateOfEmployment = log.DateOfEmployment
                })
                .Where(x => x.DateOfEmployment > firstDate && x.DateOfEmployment < secondDate);

            ViewBag.Employees = result;

            return View("ThreeResult");
        }

        [HttpGet]
        public ActionResult Four()
        {
            var posts = _postRepository.Read();

            var movementLogs = _movementLogRepository.Read();

            var namesAndSalaries = movementLogs.Join(posts,
                log => log.PostId,
                post => post.Id,
                (log, post) => new
                {
                    post.Name,
                    Salary = post.Wage + log.Rate
                });

            var result = namesAndSalaries
                .GroupBy(x => x.Name)
                .Select(x => new TaskFourQuery
                {
                    Name = x.Key,
                    MinRate = x.Min(x2 => x2.Salary),
                    MaxRate = x.Max(x2 => x2.Salary)
                });

            ViewBag.Posts = result;

            return View();
        }

        [HttpGet]
        public ActionResult Five()
        {
            var employees = _employeRepository.Read()
                .GroupBy(x => x.Id)
                .Select(x => x.FirstOrDefault())
                .Distinct();

            ViewBag.Employees = employees;

            return View();
        }

        [HttpPost]
        public ActionResult Five(int employeId)
        {
            var movementLogs = _movementLogRepository.Read()
                .Where(log => log.EmployeId == employeId);

            var posts = _postRepository.Read();

            int index = 1;

            var result = movementLogs
                .Join(posts,
                log => log.PostId,
                post => post.Id,
                (log, post) => new TaskFiveQuery
                {
                    Number = index++,
                    Status = log.Status,
                    Post = _postRepository.Read(log.PostId),
                    Employe = _employeRepository.Read(employeId),
                    DateOfEmployment = log.DateOfEmployment,
                    DateOfDismission = log.DateOfDismission,
                    DateofCreation = log.DateofCreation,
                    Description = log.Description
                })
                .OrderBy(x => x.DateofCreation);
 
            ViewBag.MovementLogs = result;

            return View("FiveResult");
        }
    }
}