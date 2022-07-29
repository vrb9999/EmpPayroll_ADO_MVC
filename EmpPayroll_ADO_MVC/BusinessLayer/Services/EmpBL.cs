using BusinessLayer.Interface;
using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmpBL : IEmpBL
    {
        IEmpRL empRL;
        public EmpBL(IEmpRL empRL)
        {
            this.empRL = empRL;
        }

        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                this.empRL.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return this.empRL.GetAllEmployees();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                return this.empRL.GetEmployeeData(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                this.empRL.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteEmployee(int? id)
        {
            try
            {
                this.empRL.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
