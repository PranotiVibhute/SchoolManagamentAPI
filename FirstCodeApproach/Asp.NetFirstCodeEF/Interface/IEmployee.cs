using Asp.NetFirstCodeEF.Entities;

namespace Asp.NetFirstCodeEF.Interface
{
    public interface IEmployee
    {
            Task<List<Employee>> GetAllEmployee();
            Task<Employee?> GetEmployeesByID(int id);
            Task<Employee?> AddEmployee(Employee obj);
            Task<Employee?> UpdateEmployee(int id, Employee obj);
            Task<bool> DeleteEmployeByID(int id);


        
    }
}
