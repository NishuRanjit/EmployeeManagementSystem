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
            return View(_staticEmployee);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee, Manager manager, string employeetype)
        {

            
            try
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
                    choosenemployee = new Employee
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Salary = employee.Salary,
                    };
                }

                choosenemployee.Bonus = choosenemployee.CalculateBonus();
               
                _staticEmployee.Add(choosenemployee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
           
        }
        
        
        
                [HttpGet]
        public IActionResult IndividualDetail(int id)
        {
            Employee empfound = null;
            foreach (var emp in _staticEmployee)
            {
                if (emp.Id == id)
                {
                    empfound = emp;
                    break;
                }
            }
                return View("Detail",empfound);
            
        }
        [HttpPost]
        public IActionResult IndividualDetail(int id, string name, int salary, int teamsize)
        {
            try
            {
                foreach (var emp in _staticEmployee)
                {
                    if (emp.Id == id)
                    {
                        emp.Name = name;
                        emp.Salary = salary;


                        Manager manager = emp as Manager;
                        if (manager != null)
                        {
                            manager.TeamSize = teamsize;
                        }

                        emp.Bonus = emp.CalculateBonus();
                        break;
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Detail");
            }
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            Employee empfound = null;
            foreach (var emp in _staticEmployee)
            {
                if (emp.Id == id)
                {
                    empfound = emp;
                    break;
                }
            }
                if (empfound != null)
                {
                    _staticEmployee.Remove(empfound); 
                }
            
                return RedirectToAction("Index");
            
        }
    }
      
    
}
