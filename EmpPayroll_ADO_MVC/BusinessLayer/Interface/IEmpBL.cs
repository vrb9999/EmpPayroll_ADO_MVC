using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmpBL
    {
        public void AddEmployee(EmployeeModel employee);
        public List<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeData(int? id);
        public void UpdateEmployee(EmployeeModel employee);
        public void DeleteEmployee(int? id);
    }
}
