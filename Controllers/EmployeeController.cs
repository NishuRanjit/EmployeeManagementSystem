using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskEmployeeManagementSystem.Models;

namespace TaskEmployeeManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class EmployeeController : Controller
    {

        private static List<Employee> _staticEmployee = new List<Employee>();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View(_staticEmployee);
        }
        [HttpPost]
        public IActionResult Create(Employee employee,Manager manager, string employeetype)
        {
          

            Employee choosenemployee;
            if (employeetype == "Manager")
            {
                choosenemployee = new Manager
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    TeamSize = manager.TeamSize


                };
            }
            else
            {
                choosenemployee = employee;
            }
            choosenemployee.Bonus = choosenemployee.CalculateBonus();
            _staticEmployee.Add(choosenemployee);
            return RedirectToAction("Detail");
        }
    }       
      
    
}
