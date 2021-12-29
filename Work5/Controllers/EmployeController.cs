using System.Web.Mvc;
using Work5.Models;
using Work5.Models.Repository;

namespace Work5.Controllers
{
    public class EmployeController : Controller
    {
        private readonly IRepository<Employe> _employeRepository = new SQLEmployeRepository();

        [HttpGet]
        public ActionResult Read()
        {
            ViewBag.Employees = _employeRepository.Read();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Employees = _employeRepository.Read();

            return View();
        }

        [HttpPost]
        public string Create(Employe employe)
        {
            _employeRepository.Create(employe);

            return "Employe has been created!";
        }
    }
}