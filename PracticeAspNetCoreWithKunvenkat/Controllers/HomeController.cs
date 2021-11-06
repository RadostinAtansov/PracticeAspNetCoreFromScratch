
namespace PracticeAspNetCoreWithKunvenkat.Controller
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using PracticeAspNetCoreWithKunvenkat.Models;
    using PracticeAspNetCoreWithKunvenkat.ViewModel;
    using System;
    using System.IO;

    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
                              IWebHostEnvironment hostingEnvironment)
        {
            this._employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
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
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPat = uniqueFileName
                };

                _employeeRepository.AddEmployee(newEmployee);

                return RedirectToAction("details", new {id = newEmployee.Id });
            }
            return View();
        }

    }
}
