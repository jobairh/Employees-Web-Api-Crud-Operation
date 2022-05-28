using Employee_Crud_Operation.Data.Models;
using Employee_Crud_Operation.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Crud_Operation.Data.Services
{
    public class EmployeesService
    {
        public AppDbContext _context;
        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddEmployee(EmployeeVM employee)
        {
            var _employee = new Employee()
            {
                Name = employee.Name,
                Gender = employee.Gender,
                Age = employee.Age,
                Designation = employee.Designation,
                Salary = employee.Salary

            };

            _context.Employees.Add(_employee);
            _context.SaveChanges();
        }
        public List<Employee> GetAllEmployees()
        {
            var allEmployee = _context.Employees.ToList();
            return allEmployee;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.Id == employeeId);
            return _employee;
        }

        public Employee UpdateEmployeeById(int employeeId, EmployeeVM employee)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.Id == employeeId);

            if (_employee != null)
            {
                _employee.Name = employee.Name;
                _employee.Gender = employee.Gender;
                _employee.Age = employee.Age;
                _employee.Designation = employee.Designation;
                _employee.Salary = employee.Salary;

                _context.SaveChanges();
            }
            return _employee;
        }

        public void DeleteEmployeeById(int employeeId)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.Id == employeeId);

            if (_employee != null)
            {
                _context.Employees.Remove(_employee);
                _context.SaveChanges();
            }
        }
    }
}
