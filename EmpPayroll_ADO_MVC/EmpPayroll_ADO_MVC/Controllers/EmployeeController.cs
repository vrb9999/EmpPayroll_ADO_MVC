using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpPayroll_ADO_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpBL empBL;
        public EmployeeController(IEmpBL empBL)
        {
            this.empBL = empBL;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeModel> empList = new List<EmployeeModel>();
            empList = empBL.GetAllEmployees().ToList();
            return View(empList);
        }
        
        [HttpGet]
        public IActionResult GetEmployeeData(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = empBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult GetEmployeeData(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                empBL.GetEmployeeData(id);
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                empBL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = empBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                empBL.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = empBL.GetEmployeeData(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public IActionResult DeleteConfirmed(int? id)
        {
            empBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
