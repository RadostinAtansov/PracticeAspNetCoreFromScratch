
namespace PracticeAspNetCoreWithKunvenkat.Controller
{

    using Microsoft.AspNetCore.Mvc;
    using PracticeAspNetCoreWithKunvenkat.Models;
    using PracticeAspNetCoreWithKunvenkat.ViewModel;

    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }


        [Route("~/Home")]
        [Route("~/")]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetEmployees();
            return View(model);
        }

        [Route("{id?}")]
        public ViewResult Details(int? id)
        {

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            Employee newEmployee = _employeeRepository.AddEmployee(employee);

            return RedirectToAction("details", new { newEmployee.Id });
        }

    }
}
