using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "Mary@pragim.com" },
                new Employee() { Id = 2, Name = "John", Department = Dept.Payroll, Email = "John@pragim.com" },
                new Employee() { Id = 3, Name = "Alley", Department = Dept.IT, Email = "Alley@pragim.com" }
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;     //to compute employee ID
            _employeeList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
             return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
