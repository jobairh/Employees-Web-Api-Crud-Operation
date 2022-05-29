using Employee_Crud_Operation.Data.Models;
using Employee_Crud_Operation.Data.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddEmployee(EmployeeVM employee)
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
            await _context.SaveChangesAsync();
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            var allEmployee = await _context.Employees.ToListAsync();
            return allEmployee;
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            var _employee = await _context.Employees.FirstOrDefaultAsync(n => n.Id == employeeId);
            return _employee;
        }

        public async Task<Employee> UpdateEmployeeById(int employeeId, EmployeeVM employee)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.Id == employeeId);

            if (_employee != null)
            {
                _employee.Name = employee.Name;
                _employee.Gender = employee.Gender;
                _employee.Age = employee.Age;
                _employee.Designation = employee.Designation;
                _employee.Salary = employee.Salary;

                await _context.SaveChangesAsync();
            }
            return _employee;
        }

        public async Task DeleteEmployeeById(int employeeId)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.Id == employeeId);

            if (_employee != null)
            {
                _context.Employees.Remove(_employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
