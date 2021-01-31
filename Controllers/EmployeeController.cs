using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssesmentTask.Models;
using Microsoft.AspNetCore.Authorization;

namespace AssesmentTask.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _empRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _empRepository = employeeRepository;
        }
        
        public IActionResult Index()
        {
            List<Employee> model = new List<Employee>();
            if (TempData["TData"] != null)
                model = TempData.Get<List<Employee>>("TData");
            else
                model = _empRepository.GetEmployees();
                
            return View(model);
        }
        
        public IActionResult CreateEmp()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Index([Bind] Employee emp)
        {
            _empRepository.CreateEmployee(emp);
            var model = _empRepository.GetEmployees();
            return View(model);
        }
        
        public IActionResult DeleteEmp(int id)
        {
            var model = _empRepository.GetEmployee(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public IActionResult Delete(int EmpNo)
        {
            List<Employee> objList = _empRepository.DeleteEmployee(EmpNo);
            TempData.Put("TData", objList);
            return RedirectToAction(nameof(Index));

        }
        
        public IActionResult EditEmp(int id)
        {
            var model = _empRepository.GetEmployee(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult EditEmp(int id, [Bind("EmpNo, FirstName,LastName,Email")] Employee emp)
        {
            if (id != emp.EmpNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                List<Employee> objList = _empRepository.UpdateEmployee(id, emp);
                TempData.Put("TData", objList);
                return RedirectToAction(nameof(Index));
            }
            
            return View(emp);
        }

    }
}
