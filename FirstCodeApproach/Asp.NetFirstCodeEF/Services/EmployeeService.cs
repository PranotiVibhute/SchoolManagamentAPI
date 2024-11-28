using Asp.NetFirstCodeEF.Context;
using Asp.NetFirstCodeEF.Entities;
using Asp.NetFirstCodeEF.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetFirstCodeEF.Services
{
    public class EmployeeService : IEmployee
    {private readonly SchoolDbContext _dbContext;
        public EmployeeService(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _dbContext.Employees.ToListAsync();
        }
        
        public async Task<Employee?> GetEmployeesByID(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeID == id);
        }
        public async Task<Employee?> AddEmployee(Employee obj)
        {
            var addEmployee = new Employee()
            {
                EmployeesName = obj.EmployeesName,
                DepartmentId = obj.DepartmentId,
                Address = obj.Address,
                CreatedDate = DateTime.Now,

            };

            _dbContext.Employees.Add(addEmployee);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? addEmployee : null;
        }

        public async Task<Employee?> UpdateEmployee(int id, Employee obj)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(index => index.EmployeeID == id);
            if (employee != null)
            {
                employee.EmployeesName = obj.EmployeesName;
                employee.DepartmentId = obj.DepartmentId;
                
                employee.Address = obj.Address;
                employee.CreatedDate = DateTime.Now;

                var result = await _dbContext.SaveChangesAsync();
                return result >= 0 ? employee : null;
            }
            return null;
        }
        public async Task<bool> DeleteEmployeByID(int id)
        {
            var hero = await _dbContext.Employees.FirstOrDefaultAsync(index => index.EmployeeID == id);
            if (hero != null)
            {
                _dbContext.Employees.Remove(hero);
                var result = await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
