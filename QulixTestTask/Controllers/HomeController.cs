using System.Web.Mvc;
using System;
using QulixTestTask.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace QulixTestTask.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddCompany(Company company)
        { //этот и следующий HttpPost - это братья-близнецы, надо прописать интерфейс и наследовать его для Employee и Company, чтоб не дублировать код. 
            //Присвоение для sqlExpression должно быть внутри сответствующей модели
            int number;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            String sqlExpression = String.Format("INSERT INTO Companies (company_name, company_type, people) VALUES ('{0}', '{1}', {2} )",
                    company.CompanyName, company.CompanyType, company.People);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                number = command.ExecuteNonQuery();
            }
            return View();
        }

        [HttpGet]
        public ViewResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddEmployee(Employee employee)
        {
            int number; // в последсвии хотелось добавить проверку значения на 0 и success message != 0  
            String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            String sqlExpression = String.Format("INSERT INTO Employees (first_name, last_name, patronymic, recruitment_date, position, company_name) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}' )",
                    employee.FirstName, employee.LastName, employee.Patronymic, employee.RecruitmentDate, employee.Position, employee.Company);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                number = command.ExecuteNonQuery();
            }
            return View();
        }


        public ViewResult ShowEmployees()
        {
            List<Employee> emloyeesList = new List<Employee>();
            String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            String sqlExpression = String.Format("SELECT * FROM Employees");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) 
                {
                    //выглядит не слишком элегантно, но как "правильно" прочитать список из БД я не знаю
                    while (reader.Read()) 
                    {
                        Employee newEmployee = new Employee(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetDateTime(4),
                            reader.GetString(5),
                            reader.GetString(6)
                            );

                        emloyeesList.Add(newEmployee);
                    }
                }
            }

            return View("ShowEmployees", emloyeesList);
        }
    }
}