using DatabaseLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmpRL : IEmpRL
    {
        private readonly string connectionString;
        public EmpRL(IConfiguration configuartion)
        {
            connectionString = configuartion.GetConnectionString("EmpPayroll_ADO_MVC");
        }
        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                }
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
                List<EmployeeModel> lstemployee = new List<EmployeeModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();

                        employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                        employee.EmpName = Convert.ToString(rdr["EmpName"]);
                        employee.ProfileImage = Convert.ToString(rdr["ProfileImage"]);
                        employee.Gender = Convert.ToString(rdr["Gender"]);
                        employee.Department = Convert.ToString(rdr["Department"]);
                        employee.Salary = Convert.ToInt32(rdr["Salary"]);
                        employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        employee.Notes = Convert.ToString(rdr["Notes"]);

                        lstemployee.Add(employee);
                    }
                    con.Close();
                }
                return lstemployee;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Employee WHERE EmpId= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                        employee.EmpName = Convert.ToString(rdr["EmpName"]);
                        employee.ProfileImage = Convert.ToString(rdr["ProfileImage"]);
                        employee.Gender = Convert.ToString(rdr["Gender"]);
                        employee.Department = Convert.ToString(rdr["Department"]);
                        employee.Salary = Convert.ToInt32(rdr["Salary"]);
                        employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        employee.Notes = Convert.ToString(rdr["Notes"]);
                    }
                }
                return employee;
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                }
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", id);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
