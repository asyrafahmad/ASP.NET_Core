using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        //readonly = good practice to prevents accidently assigning another value to the this private field(_employeeRepository) inside another method within this HomeController
        private readonly IEmployeeRepository _employeeRepository;

        // define constuctor parameter for HomeController
        public HomeController(IEmployeeRepository employeeRepository)                       // its called constructor injection because we inject IEmployeeRepository into HomeController
        {
            _employeeRepository = employeeRepository;
        }
        
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id?? 1),
                PageTitle = "Employee Details" 
            };

            return View(homeDetailsViewModel);
        }
    }
}
