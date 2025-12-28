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
      
        private static List<Employee> _staticEmployee=new List<Employee>();
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmployeeData(Employee employee)
        {
            var empdata = new Employee();
            empdata.Id = employee.Id;
            empdata.Name=employee.Name;
            empdata.Role=employee.Role;
            empdata.Salary=employee.Salary;
            empdata.Bonus=employee.Bonus;

            if (employee != null)
            {
                _staticEmployee.Add(employee);
            }
       return RedirectToAction("Index"); }
    }
}
