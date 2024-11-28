using System.ComponentModel.DataAnnotations;

namespace Asp.NetFirstCodeEF.Entities
{
    public class Employee
    {
  
        public int EmployeeID {  get; set; }

        public string ? EmployeesName {  get; set; }
        public int ? DepartmentId { get; set; }
        public string ? Address { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
